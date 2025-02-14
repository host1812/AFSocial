using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Identity;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
