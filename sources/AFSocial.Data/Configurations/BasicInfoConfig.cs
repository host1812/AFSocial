﻿using AFSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSocial.Data.Configurations;
internal class BasicInfoConfig : IEntityTypeConfiguration<BasicInfo>
{
    public void Configure(EntityTypeBuilder<BasicInfo> builder)
    {
    }
}
