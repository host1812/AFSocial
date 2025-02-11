using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Posts.Requests;

public class PostUpdateRequest
{
    [Required]
    public Guid PostId { get; set; }
    
    [Required]
    public string Text { get; set; } = string.Empty;
}
