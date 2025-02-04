using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.UserProfiles.Requests;

public record UserProfileCreateUpdate
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    public string CurrentCity { get; set; } = string.Empty;
}
