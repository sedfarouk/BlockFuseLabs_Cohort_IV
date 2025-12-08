using System.ComponentModel.DataAnnotations;

public record TaskCreateDto(
    [property: Required] string Title, 
    string? Description, 
    DateTime? DueDate
);