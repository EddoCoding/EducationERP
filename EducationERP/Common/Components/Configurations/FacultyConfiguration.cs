using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<SettingFaculty>
    {
        public void Configure(EntityTypeBuilder<SettingFaculty> builder)
        {
            builder
                .HasMany(x => x.Levels)
                .WithOne(x => x.SettingFaculty);
        }
    }
}