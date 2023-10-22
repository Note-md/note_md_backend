using HeyRed.MarkdownSharp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteMDBackend.Entity;

public class Note
{
    [Key] public Guid Id { get; set; }

    [Required][MaxLength(50)] public string Title { get; set; }

    [Required] public string Markdown { get; set; }

    [Required][ForeignKey(nameof(User))] public string CreatedBy { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.Now;

    public DateTimeOffset UpdatedAt { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Active";

    public string Visibility { get; set; } = "Public";

    [ForeignKey(nameof(Course))] public int CourseId { get; set; }

    public Course Course { get; set; }
    public User User { get; set; }

    [NotMapped]
    public string FormattedMarkdown
    {
        get
        {
            var options = new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = true,
                LinkEmails = true,
                QuoteSingleLine = true,
                StrictBoldItalic = true,

            };

            var mark = new Markdown(options);

            return mark.Transform(Markdown);
        }
    }

}