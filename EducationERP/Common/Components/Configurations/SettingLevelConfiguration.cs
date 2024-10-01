using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class SettingLevelConfiguration : IEntityTypeConfiguration<SettingLevel>
    {
        public void Configure(EntityTypeBuilder<SettingLevel> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Directions)
                .WithOne(x => x.SettingLevel);
        }
    }
}