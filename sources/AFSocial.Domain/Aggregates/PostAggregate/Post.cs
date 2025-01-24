using AFSocial.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class Post
{
    public Guid PostId { get; set; } = Guid.NewGuid();
    public Guid UserProfileId { get; set; } = Guid.NewGuid();
    public UserProfile UserProfile { get; set; } = new UserProfile();
    public string TextContent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModified { get; set; } = DateTime.Now;
    public ICollection<PostComment>? Comments { get; set; }
    public ICollection<PostInteraction>? Interactions { get; set; }
}
