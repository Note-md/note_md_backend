using Microsoft.AspNetCore.Mvc;
using NoteMDBackend.Service;

namespace NoteMDBackend.Controllers;

public class AuthController: Controller
{
    
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    [Route("api/auth/register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        
        var response = await _authService.RegisterAsync(request);
        // Add uid to session
        HttpContext.Session.SetString("uid", response.Uid);
        
        return RedirectToAction("Index", "Home");
    }
    
}
