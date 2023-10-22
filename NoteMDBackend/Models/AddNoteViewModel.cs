using NoteMDBackend.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NoteMDBackend.Models
{
    public class AddNoteViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Note Heading")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Note Contents")]
        public string Markdown { get; set; }

        [NotMapped]
        public Course? Course { get; set; }
    }

}
