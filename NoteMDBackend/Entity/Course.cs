using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteMDBackend.Entity;

public class Course
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(50)] public string Name { get; set; }

    [Required] [MaxLength(50)] public string Code { get; set; }

    [Required] public string Description { get; set; }

    [Required] [ForeignKey(nameof(User))] public string CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Active";

    public User User { get; set; }
}