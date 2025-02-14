using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Identity;

public class UserRegistrationRequest
{
    [Required]
    [EmailAddress]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Range(typeof(DateTime), new DateTime(DateTime.Now.AddYears(-125).Ticks),
        new DateTime(DateTime.Now.AddYears(-125).Ticks)),
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public DateTime DateOfBirth { get; set; }
}
