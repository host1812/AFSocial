using AFSocial.Api.Contracts.Posts.Responses;
using AFSocial.Domain.Aggregates.PostAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AFSocial.Api.Mappers;

public static class PostMapper
{
    public static PostResponse ToPostResponse(this Post source)
    {
        return new PostResponse()
        {
            CreatedAt = source.CreatedAt,
            LastModified = source.LastModified,
            PostId = source.PostId,
            TextContent = source.TextContent,
            UserProfileId = source.UserProfileId,
        };
    }
}
