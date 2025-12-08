public record TaskDto(
    int Id, 
    string Title, 
    string? Description, 
    DateTime? DueDate, 
    bool IsCompleted, 
    DateTime CreatedAt, 
    DateTime? CompletedAt
);
