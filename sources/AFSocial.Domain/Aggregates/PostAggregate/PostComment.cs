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

    public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
    {
        return new PostComment()
        {
            PostId = postId,
            Text = text,
            UserProfileId = userProfileId,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };
    }

    public void UpdateCommentText(string newText)
    {
        Text = newText;
        LastModified = DateTime.UtcNow;
    }
}
