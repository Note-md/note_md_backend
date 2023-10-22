using System.ComponentModel.DataAnnotations;

namespace NoteMDBackend.Entity;

public class User
{
    [Key] public string Id { get; set; }

    [Required] [MaxLength(50)] public string Username { get; set; }

    [Required] [MaxLength(50)] public string FirstName { get; set; }

    [Required] [MaxLength(50)] public string LastName { get; set; }

    [Required] public string ImageURL { get; set; }

    [Required] public string Description { get; set; }

    [Required] [MaxLength(50)] public string ProgramEnrolled { get; set; }

    [Required] public string Designation { get; set; } = "Student";

    [Required] public string Status { get; set; } = "Active";

    [Required] public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    [Required] public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;
}