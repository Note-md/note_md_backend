using FirebaseAdmin.Auth;
using NoteMDBackend.Models;

namespace NoteMDBackend.Service;


public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);
}

public class AuthService : IAuthService
{
    public Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var record = FirebaseAuth.DefaultInstance.GetUserByEmailAsync(request.EmailID);
        var response = new LoginResponse()
        {
            Uid = record.Result.Uid
        };
        return Task.FromResult(response);
    }

    public Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        
        var record = FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
        {
            Email = request.EmailID,
            Password = request.Password
        });
        
        var response = new RegisterResponse()
        {
            Uid = record.Result.Uid
        };
        
        return Task.FromResult(response);
    }
    
    
    
}