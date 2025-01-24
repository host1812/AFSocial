using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.Post;
public class Post
{
    public Guid PostId { get; set; } = Guid.NewGuid();
    public Guid UserProfileId { get; set; } = Guid.NewGuid();
    public string TextContent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModified { get; set; } = DateTime.Now;
    public ICollection<PostComment> Comments { get; set; }
}
