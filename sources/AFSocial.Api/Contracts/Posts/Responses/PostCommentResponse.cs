namespace AFSocial.Api.Contracts.Posts.Responses;

public class PostCommentResponse
{
    public string Text { get; set; } = string.Empty;
    public Guid UserProfileId { get; set; }
}
