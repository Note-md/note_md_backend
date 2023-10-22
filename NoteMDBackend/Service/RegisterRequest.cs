using System.ComponentModel.DataAnnotations;

namespace NoteMDBackend.Service;

public class RegisterRequest
{
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
    public string EmailID { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        ErrorMessage = "Invalid Password Format")]
    public string Password { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name Format")]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Last Name Format")]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Phone Number Format")]
    public string ImageURL { get; set; }
    
    [Required]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Phone Number Format")]
    public string Description { get; set; }

    public string ProgramEnrolled { get; set; }
    
    public string? Designation { get; set; }
}