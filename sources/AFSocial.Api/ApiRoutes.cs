namespace AFSocial.Api;

public class ApiRoutes
{
    public const string BaseDefaultRoute = "api/[controller]";
    public const string BaseVersionedRoute = "api/v{version:apiVersion}/[controller]";

    public class Posts
    {
        public const string IdRoute = "{id}";
    }
    public class UserProfiles
    {
        public const string IdRoute = "{id}";
    }
}
