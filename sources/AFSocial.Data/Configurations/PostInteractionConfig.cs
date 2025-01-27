﻿using AFSocial.Domain.Aggregates.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Data.Configurations;
internal class PostInteractionConfig : IEntityTypeConfiguration<PostInteraction>
{
    public void Configure(EntityTypeBuilder<PostInteraction> builder)
    {
        builder.HasKey(pc => pc.InteractionId);
    }
}
