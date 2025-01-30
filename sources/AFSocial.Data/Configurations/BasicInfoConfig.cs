using AFSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFSocial.Data.Configurations;
internal class BasicInfoConfig : IEntityTypeConfiguration<BasicInfo>
{
    public void Configure(EntityTypeBuilder<BasicInfo> builder)
    {
    }
}
