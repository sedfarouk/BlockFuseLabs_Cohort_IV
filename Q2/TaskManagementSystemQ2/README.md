# Task Management System (Q2)

This is a minimal ASP.NET Core 8.0 minimal-API for managing tasks as expected in the BlockFuse Cohort IV test - Question 2.

Features implemented
- Create task (POST /tasks): title (required), description (optional), dueDate (optional)
# Task Management System (Q2)

This is a minimal ASP.NET Core 8.0 minimal-API for managing tasks as expected in the BlockFuse Cohort IV test - Question 2.

Features implemented
- Create task (POST /tasks): title (required), description (optional), dueDate (optional)
- List tasks (GET /tasks)
- Mark task as completed (PATCH /tasks/{id}/complete)
- Delete task (DELETE /tasks/{id})

Validation
- `title` is required and must be non-empty.
- `dueDate` is parsed as a DateTime (ISO format recommended).

Database
- Default: SQLite local file `taskmanagement.db` (no external setup required).
- Optional: PostgreSQL. To use Postgres, change `ConnectionStrings:DefaultConnection` in `appsettings.json` to your Postgres connection string.

How to run locally

1. From the `TaskManagementSystemQ2` directory, restore and run:

```bash
cd Q2/TaskManagementSystemQ2
dotnet restore
dotnet run
```

2. The API will be available at `https://localhost:5001` (or the port shown in the console).

3. Use curl or HTTP client to test endpoints. Examples:

Create task:

```bash
curl -k -X POST https://localhost:5001/tasks \
  -H "Content-Type: application/json" \
  -d '{"title":"Buy milk","description":"From the store","dueDate":"2025-12-31T00:00:00Z"}'
```

List tasks:

```bash
curl -k https://localhost:5001/tasks
```

Mark completed:

```bash
curl -k -X PATCH https://localhost:5001/tasks/1/complete
```

Delete:

```bash
curl -k -X DELETE https://localhost:5001/tasks/1
```

Swagger snapshots

Below are screenshots taken from the Swagger UI during development. They show the available endpoints and example responses for create, list, complete and delete operations.

### API endpoints (Swagger)
![API endpoints](/Q2/TaskManagementSystemQ2/api_endpoints_swagger.png)

### Create task (response)
![Create task response](/Q2/TaskManagementSystemQ2/create_task.png)

### List tasks (response)
![List tasks response](/Q2/TaskManagementSystemQ2/get_all_tasks.png)

### Mark task as completed (response)
![Mark task as completed response](/Q2/TaskManagementSystemQ2/mark_task_as_completed.png)

### Delete task (response)
![Delete task response](/Q2/TaskManagementSystemQ2/delete_task.png)

Notes
- The project uses EF Core. For a production setup you should use migrations and a managed Postgres instance.
- Responses are clean JSON with appropriate HTTP status codes.

Next improvements (optional):
- Add paging/filtering, search by title.
- Add user authentication and ownership.
- Add migrations and CI pipeline.
