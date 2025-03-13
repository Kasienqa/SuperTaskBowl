using System.ComponentModel.DataAnnotations;

namespace SuperTaskBowl.DTOs;

public class TaskUpdateDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime DueDate { get; set; }

    public bool IsCompleted { get; set; }
}
