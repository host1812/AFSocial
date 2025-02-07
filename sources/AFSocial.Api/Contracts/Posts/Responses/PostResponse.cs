using AFSocial.Domain.Aggregates.UserProfileAggregate;

namespace AFSocial.Api.Contracts.Posts.Responses;

public class PostResponse
{
    /// <summary>
    /// Gets the unique identifier for the post.
    /// </summary>
    public Guid PostId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the unique identifier for the user profile associated with the post.
    /// </summary>
    public Guid UserProfileId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the text content of the post.
    /// </summary>
    public string TextContent { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the post was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets the date and time when the post was last modified.
    /// </summary>
    public DateTime LastModified { get; set; } = DateTime.Now;
}
