using Microsoft.EntityFrameworkCore;
using NoteMDBackend.Entity;

namespace NoteMDBackend.Service
{

    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();
        Task<List<Note>> GetNotesAsync(int courseID);

    }
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            return _context.Courses.OrderBy(c => c.Name).ToListAsync();
        }

        public Task<List<Note>> GetNotesAsync(int courseID)
        {
            return _context.Notes.Where(n => n.CourseId == courseID).OrderBy(n => n.Title).ToListAsync();
        }
    }
}
