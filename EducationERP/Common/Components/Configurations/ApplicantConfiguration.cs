using EducationERP.Models.Modules.AdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder
                .HasMany(x => x.Documents)
                .WithOne(x => x.Applicant);

            builder
                .HasMany(x => x.Educations)
                .WithOne(x => x.Applicant);

            builder
                .HasMany(x => x.EGES)
                .WithOne(x => x.Applicant);
        }
    }
}