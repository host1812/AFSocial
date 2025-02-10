using AFSocial.Domain.Aggregates.UserProfileAggregate;
using System.ComponentModel.DataAnnotations;

namespace AFSocial.Api.Contracts.Posts.Requests;

public class PostCreateRequest
{
    /// <summary>
    /// Gets the unique identifier for the user profile associated with the post.
    /// </summary>
    [Required]
    public Guid UserProfileId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the text content of the post.
    /// </summary>
    [Required]
    [MaxLength(1024)]
    public string TextContent { get; set; } = string.Empty;
}
