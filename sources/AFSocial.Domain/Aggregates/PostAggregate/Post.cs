using AFSocial.Domain.Aggregates.UserProfileAggregate;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class Post
{
    private readonly List<PostComment> comments = [];
    private readonly List<PostInteraction> interactions = [];
    private Post()
    {
    }

    public Guid PostId { get; private set; } = Guid.NewGuid();
    public Guid UserProfileId { get; private set; } = Guid.NewGuid();
    public UserProfile UserProfile { get; private set; }
    public string TextContent { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public DateTime LastModified { get; private set; } = DateTime.Now;
    public IEnumerable<PostComment> Comments { get => comments; }
    public IEnumerable<PostInteraction> Interactions { get => interactions; }

    public static Post CreatePost(Guid userProfileId, string textContent)
    {
        return new Post()
        {
            UserProfileId = userProfileId,
            TextContent = textContent,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };
    }

    public void UpdatePost(string newTextContent)
    {
        TextContent = newTextContent;
        LastModified = DateTime.UtcNow;
    }

    public void AddPostComment(PostComment newPostComment)
    {
        comments.Add(newPostComment);
    }

    public void RemovePostComment(PostComment newPostComment)
    {
        comments.Remove(newPostComment);
    }

    public void AddPostInteractions(PostInteraction newPostInteraction)
    {
        interactions.Add(newPostInteraction);
    }

    public void RemovePostInteractions(PostInteraction newPostInteraction)
    {
        interactions.Remove(newPostInteraction);
    }
}
