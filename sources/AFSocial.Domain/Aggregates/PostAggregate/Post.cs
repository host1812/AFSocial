using AFSocial.Domain.Aggregates.UserProfileAggregate;
using AFSocial.Domain.Exceptions;
using AFSocial.Domain.Validators.PostValidators;

namespace AFSocial.Domain.Aggregates.PostAggregate;
/// <summary>
/// Represents a post in the social media application.
/// </summary>
public class Post
{
    private readonly List<PostComment> comments = [];
    private readonly List<PostInteraction> interactions = [];

    private Post()
    {
    }

    /// <summary>
    /// Gets the unique identifier for the post.
    /// </summary>
    public Guid PostId { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the unique identifier for the user profile associated with the post.
    /// </summary>
    public Guid UserProfileId { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the user profile associated with the post.
    /// </summary>
    public UserProfile? UserProfile { get; private set; }

    /// <summary>
    /// Gets the text content of the post.
    /// </summary>
    public string TextContent { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the date and time when the post was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    /// <summary>
    /// Gets the date and time when the post was last modified.
    /// </summary>
    public DateTime LastModified { get; private set; } = DateTime.Now;

    /// <summary>
    /// Gets the comments associated with the post.
    /// </summary>
    public IEnumerable<PostComment> Comments { get => comments; }

    /// <summary>
    /// Gets the interactions associated with the post.
    /// </summary>
    public IEnumerable<PostInteraction> Interactions { get => interactions; }

    /// <summary>
    /// Creates a new post.
    /// </summary>
    /// <param name="userProfileId">The ID of the user profile creating the post.</param>
    /// <param name="textContent">The text content of the post.</param>
    /// <returns>A new instance of <see cref="Post"/>.</returns>
    /// <exception cref="PostNotValidException">Thrown when the post is not valid.</exception>
    public static Post CreatePost(Guid userProfileId, string textContent)
    {
        var validator = new PostValidator();
        var objToValidate = new Post()
        {
            UserProfileId = userProfileId,
            TextContent = textContent,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };

        var validationResult = validator.Validate(objToValidate);
        if (!validationResult.IsValid)
        {
            var exception = new PostNotValidException("Post is not valid.");
            validationResult.Errors.ForEach(e => exception.ValidationErrors.Add(e.ErrorMessage));
            throw exception;
        }
        return objToValidate;
    }

    /// <summary>
    /// Updates the text content of the post.
    /// </summary>
    /// <param name="newTextContent">The new text content of the post.</param>
    /// <exception cref="PostNotValidException">Thrown when the new text content is not valid.</exception>
    public void UpdatePost(string newTextContent)
    {
        if (string.IsNullOrWhiteSpace(newTextContent))
        {
            var exception = new PostNotValidException("Can not update post. New text is not valid.");
            exception.ValidationErrors.Add("The provided text is null or empty.");
            throw exception;
        }
        TextContent = newTextContent;
        LastModified = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds a comment to the post.
    /// </summary>
    /// <param name="newPostComment">The comment to add.</param>
    public void AddPostComment(PostComment newPostComment)
    {
        comments.Add(newPostComment);
    }

    /// <summary>
    /// Removes a comment from the post.
    /// </summary>
    /// <param name="newPostComment">The comment to remove.</param>
    public void RemovePostComment(PostComment newPostComment)
    {
        comments.Remove(newPostComment);
    }

    /// <summary>
    /// Adds an interaction to the post.
    /// </summary>
    /// <param name="newPostInteraction">The interaction to add.</param>
    public void AddPostInteractions(PostInteraction newPostInteraction)
    {
        interactions.Add(newPostInteraction);
    }

    /// <summary>
    /// Removes an interaction from the post.
    /// </summary>
    /// <param name="newPostInteraction">The interaction to remove.</param>
    public void RemovePostInteractions(PostInteraction newPostInteraction)
    {
        interactions.Remove(newPostInteraction);
    }
}
