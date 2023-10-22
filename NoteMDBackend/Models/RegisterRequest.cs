using System.ComponentModel.DataAnnotations;

namespace NoteMDBackend.Models;

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
    public string ImageURL { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string ProgramEnrolled { get; set; }

    [Required]
    public string? Designation { get; set; }
}