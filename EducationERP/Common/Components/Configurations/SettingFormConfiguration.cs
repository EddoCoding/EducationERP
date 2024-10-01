using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class SettingFormConfiguration : IEntityTypeConfiguration<SettingForm>
    {
        public void Configure(EntityTypeBuilder<SettingForm> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.SettingProfile);
        }
    }
}