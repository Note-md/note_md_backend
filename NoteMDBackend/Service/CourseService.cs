using Microsoft.EntityFrameworkCore;
using NoteMDBackend.Entity;

namespace NoteMDBackend.Service
{

    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();

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
    }
}
