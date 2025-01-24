using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.UserProfile;
public class UserProfile
{
    public Guid UserProfileId { get; set; } = Guid.NewGuid();
    public Guid ObjectId { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModified { get; set; } = DateTime.Now;
    public BasicInfo BasicInfo { get; set; } = new BasicInfo();
}
