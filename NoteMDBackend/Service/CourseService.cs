using Microsoft.EntityFrameworkCore;
using NoteMDBackend.Entity;

namespace NoteMDBackend.Service
{

    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync();
        Task<List<Note>> GetNotesAsync(int courseID);

        Task<Note> AddNoteAsync(Note note);

        Task<Note> GetNoteByIdAsync(Guid id);

        Task<Course> AddCourseAsync(Course course);

        Task<Course> GetCourseByIdAsync(int id);

        Task<Note> EditNoteAsync(Note note);

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
            return _context.Notes
                .Where(n => n.CourseId == courseID)
                .Include(n => n.Course)
                .Include(n => n.User)
                .OrderBy(n => n.Title).ToListAsync();
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public Task<Course> GetCourseByIdAsync(int id)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Note> AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public Task<Note> GetNoteByIdAsync(Guid id)
        {
            return _context.Notes
                .Include(n => n.Course)
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Note> EditNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

    }
}
