using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class PostComment
{
    public Guid CommentId { get; set; } = Guid.NewGuid();
    public Guid PostId { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = string.Empty;
    public Guid UserProfileId { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModified { get; set; } = DateTime.Now;
}
