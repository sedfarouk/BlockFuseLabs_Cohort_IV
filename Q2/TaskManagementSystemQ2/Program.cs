using Microsoft.EntityFrameworkCore;
using TaskManagementSystemQ2.Data;
using TaskManagementSystemQ2.Model;

// Helpers
static TaskDto TodoDto(TaskItem t) => new(t.Id, t.Title, t.Description, t.DueDate, t.IsCompleted, t.CreatedAt, t.CompletedAt);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB: default to SQLite for local dev. To use Postgres, set
// ConnectionStrings:DefaultConnection in appsettings.json to a postgres connection string
var configuration = builder.Configuration;
var defaultConn = configuration.GetConnectionString("DefaultConnection")
                  ?? "Data Source=taskmanagement.db";

if (defaultConn.StartsWith("Host=") || defaultConn.StartsWith("Server="))
{
    // assume Postgres-style connection
    builder.Services.AddDbContext<AppDbContext>(opts =>
        opts.UseNpgsql(defaultConn));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(opts =>
        opts.UseSqlite(defaultConn));
}

var app = builder.Build();

// Ensure DB created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Create task
app.MapPost("/tasks", async (TaskCreateDto input, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(input.Title))
        return Results.BadRequest(new { error = "Title is required." });

    var task = new TaskItem
    {
        Title = input.Title.Trim(),
        Description = input.Description,
        DueDate = input.DueDate
    };

    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    return Results.Created($"/tasks/{task.Id}", TodoDto(task));
});

// List tasks
app.MapGet("/tasks", async (AppDbContext db) =>
{
    var tasks = await db.Tasks.OrderBy(t => t.Id).ToListAsync();
    return Results.Ok(tasks.Select(TodoDto));
});

// Mark task as completed (PATCH)
app.MapMethods("/tasks/{id:int}/complete", new[] { "PATCH" }, async (int id, AppDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound(new { error = "Task not found." });
    if (task.IsCompleted) return Results.BadRequest(new { error = "Task already completed." });

    task.IsCompleted = true;
    task.CompletedAt = DateTime.UtcNow;
    await db.SaveChangesAsync();
    return Results.Ok(TodoDto(task));
});

// Delete task
app.MapDelete("/tasks/{id:int}", async (int id, AppDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound(new { error = "Task not found." });

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


