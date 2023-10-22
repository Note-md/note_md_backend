using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NoteMDBackend.Entity;
using NoteMDBackend.Models;
using NoteMDBackend.Service;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;

namespace NoteMDBackend.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ICourseService _courseService;

    private readonly IOpenAIService _openAiService;

    public HomeController(ILogger<HomeController> logger, ICourseService courseService, IOpenAIService openAIService)
    {
        _logger = logger;
        _courseService = courseService;
        _openAiService = openAIService;

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

        ViewBag.SelectedCourseId = selectedCourse.Id;

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

    [HttpPost]
    public async Task<JsonResult> TextboxChanged(string textboxValue)
    {
        // Your logic here
        var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
        {
            Messages = new List<ChatMessage>
            {
                ChatMessage.FromSystem("You are a helpful assistant for student who help to genrate content from title. You can genrate anything related to title Directly give output in Markdown"),
                ChatMessage.FromUser($"The title is {textboxValue}"),
            },
            Model = OpenAI.ObjectModels.Models.ChatGpt3_5Turbo,
            MaxTokens = 50//optional
        });
        if (completionResult.Successful)
        {
            Console.WriteLine(completionResult.Choices.First().Message.Content);
            
            return Json(new { result = completionResult.Choices.First().Message.Content });
        }

        return Json(new { });
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

    [HttpGet("[controller]/[action]/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var note = await _courseService.GetNoteByIdAsync(id);
        var viewModel = new EditNoteViewModel
        {
            Course = note.Course,
            Title = note.Title,
            Markdown = note.Markdown
        };
        return View(viewModel);
    }

    [HttpPost("[controller]/[action]/{id}")]
    public async Task<IActionResult> Edit(Guid id, EditNoteViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var note = await _courseService.GetNoteByIdAsync(id);
        note.Title = viewModel.Title;
        note.Markdown = viewModel.Markdown;
        await _courseService.EditNoteAsync(note);
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