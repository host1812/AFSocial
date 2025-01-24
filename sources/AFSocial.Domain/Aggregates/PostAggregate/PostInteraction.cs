using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class PostInteraction
{
    private PostInteraction()
    {
    }

    public Guid InteractionId { get; private set; } = Guid.NewGuid();
    public Guid PostId { get; private set; } = Guid.NewGuid();
    public InteractionType InteractionType { get; private set; }

    public static PostInteraction CreatePostInteraction(Guid postId, InteractionType type)
    {
        return new PostInteraction()
        {
            PostId = postId,
            InteractionType = type,
        };
    }
}
