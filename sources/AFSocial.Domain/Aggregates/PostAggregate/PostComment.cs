using AFSocial.Domain.Exceptions;
using AFSocial.Domain.Validators.PostValidators;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class PostComment
{
    private PostComment()
    {
    }

    public Guid CommentId { get; private set; } = Guid.NewGuid();
    public Guid PostId { get; private set; } = Guid.NewGuid();
    public string Text { get; private set; } = string.Empty;
    public Guid UserProfileId { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; }
    public DateTime LastModified { get; private set; }

    /// <summary>
    /// Creates a new post comment.
    /// </summary>
    /// <param name="postId">The ID of the post.</param>
    /// <param name="text">The text of the comment.</param>
    /// <param name="userProfileId">The ID of the user profile.</param>
    /// <returns>A new instance of <see cref="PostComment"/>.</returns>
    /// <exception cref="PostCommentNotValidException">Thrown when the post comment is not valid.</exception>
    public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
    {
        var validator = new PostCommentValidator();

        var objToValidate = new PostComment()
        {
            PostId = postId,
            Text = text,
            UserProfileId = userProfileId,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };

        var validationResult = validator.Validate(objToValidate);

        if (!validationResult.IsValid)
        {
            var exception = new PostCommentNotValidException("The post comment is not valid");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }

            throw exception;
        }

        return objToValidate;
    }

    public void UpdateCommentText(string newText)
    {
        Text = newText;
        LastModified = DateTime.UtcNow;
    }
}
