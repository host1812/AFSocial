namespace AFSocial.Api;

public class ApiRoutes
{
    public const string BaseDefaultRoute = "api/[controller]";
    public const string BaseVersionedRoute = "api/v{version:apiVersion}/[controller]";

    public static class Posts
    {
        public const string IdRoute = "{id}";
        public const string PostCommentsRoute = "{postId}/comments";
        public const string PostCommentIdRoute = "{postId}/comments/{commentId}";
    }
    public static class UserProfiles
    {
        public const string IdRoute = "{id}";
    }

    public static class Identity
    {
        public const string Login = "login";
        public const string Registration = "registration";
    }
}
