using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class SettingDirectionConfiguration : IEntityTypeConfiguration<SettingDirection>
    {
        public void Configure(EntityTypeBuilder<SettingDirection> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Profiles)
                .WithOne(x => x.SettingDirection);
        }
    }
}
