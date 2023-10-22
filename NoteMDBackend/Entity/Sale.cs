using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteMDBackend.Entity;

public class Sale
{
    [Key] public Guid Id { get; set; }

    [Required] public string UserId { get; set; }

    [Required]
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    public Product Product { get; set; }
    public User User { get; set; }
}