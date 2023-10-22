using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NoteMDBackend.Entity;
using NoteMDBackend.Models;
using NoteMDBackend.Service;

namespace NoteMDBackend.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICourseService _courseService;

    public HomeController(ILogger<HomeController> logger, ICourseService courseService)
    {
        _logger = logger;
        _courseService = courseService;

    }

    public async Task<ActionResult> Sidebar()
    {
        var courses = await _courseService.GetCoursesAsync();
        return PartialView("_Sidebar", courses);
    }

    public async Task<IActionResult> Index(int? id)
    {
        var courses = await _courseService.GetCoursesAsync();

        var selectedCourse = courses.FirstOrDefault(c => c.Id == id) ?? courses.FirstOrDefault();

        var notes = await _courseService.GetNotesAsync(selectedCourse.Id);
        var viewModel = new HomeViewModel
        {
            Courses = courses,
            Notes = notes,
            SelectedCourseId = selectedCourse.Id
        };
        return View(viewModel);
    }

    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> Add(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        var addNoteViewModel = new AddNoteViewModel
        {
            Course = course
        };
        return View(addNoteViewModel);
    }

    [HttpPost("[controller]/[action]/{id}")]
    public async Task<IActionResult> Add(int id, AddNoteViewModel viewModel)
    {

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var course = await _courseService.GetCourseByIdAsync(id);

        var note = new Note
        {
            Title = viewModel.Title,
            Markdown = viewModel.Markdown,
            CreatedBy = "1",
            CourseId = course.Id
        };

        note.Course = course;
        await _courseService.AddNoteAsync(note);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}