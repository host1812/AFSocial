namespace AFSocial.Api.Contracts.Posts.Requests;

public class PostCommentCreateRequest
{
    public string Text { get; set; } = string.Empty;
    public Guid UserProfileId { get; set; }
}
