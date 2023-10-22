using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteMDBackend.Entity;

public class NoteLike
{
    [Key] public int Id { get; set; }

    [Required] [ForeignKey(nameof(User))] public string CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Active";

    [Required] [ForeignKey(nameof(Note))] public Guid NoteId { get; set; }

    public Note Note { get; set; }
    public User User { get; set; }
}