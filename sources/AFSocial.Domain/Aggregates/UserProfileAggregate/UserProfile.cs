﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Domain.Aggregates.UserProfileAggregate;
public class UserProfile
{
    private UserProfile()
    {
    }
    public Guid UserProfileId { get; private set; }
    public Guid ObjectId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime LastModified { get; private set; }
    public BasicInfo BasicInfo { get; private set; }

    public static UserProfile CreateUserProfile(Guid objectId, BasicInfo basicInfo)
    {
        return new UserProfile()
        {
            ObjectId = objectId,
            BasicInfo = basicInfo,
            CreatedAt = DateTime.UtcNow,
            LastModified = DateTime.UtcNow,
        };
    }
}
