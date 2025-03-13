using System.ComponentModel.DataAnnotations;

namespace SuperTaskBowl.DTOs;

public class TaskCreateDto
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DueDate { get; set; }
}
