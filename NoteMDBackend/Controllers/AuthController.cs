using Microsoft.AspNetCore.Mvc;
using NoteMDBackend.Models;
using NoteMDBackend.Service;

namespace NoteMDBackend.Controllers;

public class AuthController : Controller
{

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        try
        {
            var response = await _authService.LoginAsync(request);
            HttpContext.Session.SetString("uid", response.Uid);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            // Add error message to ModelState
            ModelState.AddModelError("LoginFailed", "Login failed");

            return View(request);
        }
    }

    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        try
        {
            var response = await _authService.RegisterAsync(request);
            HttpContext.Session.SetString("uid", response.Uid);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            return View(request);
        }
    }

}
