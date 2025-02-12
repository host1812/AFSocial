using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Posts.Requests;

public class PostCommentCreateRequest
{
    [Required]
    public string Text { get; set; } = string.Empty;
    
    [Required]
    public Guid UserProfileId { get; set; }
}
