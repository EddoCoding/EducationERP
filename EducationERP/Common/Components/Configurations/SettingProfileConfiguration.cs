using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class SettingProfileConfiguration : IEntityTypeConfiguration<SettingProfile>
    {
        public void Configure(EntityTypeBuilder<SettingProfile> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Forms)
                .WithOne(x => x.SettingProfile);
        }
    }
}
