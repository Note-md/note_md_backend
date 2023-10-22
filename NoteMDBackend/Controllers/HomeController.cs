using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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


    public async Task<IActionResult> Index()
    {
        var homeViewModel = new HomeViewModel();

        homeViewModel.courses = await _courseService.GetCoursesAsync();

        return View(homeViewModel);
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