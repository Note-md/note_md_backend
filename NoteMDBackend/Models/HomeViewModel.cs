using NoteMDBackend.Entity;

namespace NoteMDBackend.Models
{
    public class HomeViewModel
    {

        public List<Course> Courses { get; set; }

        public List<Note> Notes { get; set; }

        public int SelectedCourseId { get; set; }

    }
}
