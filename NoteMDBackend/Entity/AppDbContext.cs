using Microsoft.EntityFrameworkCore;

namespace NoteMDBackend.Entity;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<NoteLike> NoteLikes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = "1",
                Username = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                ImageURL = "https://i.imgur.com/6VBx3io.png",
                Description = "Admin",
                ProgramEnrolled = "Admin",
                Designation = "Admin",
                Status = "Active"
            }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = "C#",
                Code = "C#",
                Description = "C#",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 2,
                Name = "Java",
                Code = "Java",
                Description = "Java",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 3,
                Name = "Python",
                Code = "Python",
                Description = "Python",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 4,
                Name = "C++",
                Code = "C++",
                Description = "C++",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 5,
                Name = "JavaScript",
                Code = "JavaScript",
                Description = "JavaScript",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 6,
                Name = "PHP",
                Code = "PHP",
                Description = "PHP",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 7,
                Name = "HTML",
                Code = "HTML",
                Description = "HTML",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 8,
                Name = "CSS",
                Code = "CSS",
                Description = "CSS",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 9,
                Name = "SQL",
                Code = "SQL",
                Description = "SQL",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 10,
                Name = "Ruby",
                Code = "Ruby",
                Description = "Ruby",
                CreatedBy = "1",
                Status = "Active"
            },
            new Course
            {
                Id = 11,
                Name = "Swift",
                Code = "Swift",
                Description = "Swift",
                CreatedBy = "1",
                Status = "Active"
            }
        );

        modelBuilder.Entity<Note>().HasData(
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "C#",
                Markdown = "C#",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 1
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "Java",
                Markdown = "Java",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 2
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "Python",
                Markdown = "Python",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 3
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "C++",
                Markdown = "C++",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 4
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "JavaScript",
                Markdown = "JavaScript",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 5
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "PHP",
                Markdown = "PHP",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 6
            },
            new Note
            {
                Id = Guid.NewGuid(),
                Title = "HTML",
                Markdown = "HTML",
                CreatedBy = "1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = "Active",
                Visibility = "Public",
                CourseId = 7
            });
    }
}