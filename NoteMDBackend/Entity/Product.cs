using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteMDBackend.Entity;

public class Product
{
    [Key] public Guid Id { get; set; }

    [Required] [ForeignKey(nameof(User))] public string UserId { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] [ForeignKey(nameof(Note))] public Guid NoteId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;
    public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Active";

    public Note Note { get; set; }
    public User User { get; set; }
}