using AFSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFSocial.Data.Configurations;
internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.OwnsOne(e => e.BasicInfo);
    }
}
