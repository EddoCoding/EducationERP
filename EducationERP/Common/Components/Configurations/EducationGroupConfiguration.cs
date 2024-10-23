using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class EducationGroupConfiguration : IEntityTypeConfiguration<EducationGroup>
    {
        public void Configure(EntityTypeBuilder<EducationGroup> builder)
        {
            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.EducationGroup);
        }
    }
}