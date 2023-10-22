using NoteMDBackend.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NoteMDBackend.Models
{
    public class EditNoteViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Markdown { get; set; }

        [NotMapped]
        public Course? Course { get; set; }
    }

}
