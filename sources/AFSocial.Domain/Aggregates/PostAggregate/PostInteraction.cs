using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.PostAggregate;
public class PostInteraction
{
    public Guid InteractionId { get; set; } = Guid.NewGuid();
    public Guid PostId { get; set; } = Guid.NewGuid();

}
