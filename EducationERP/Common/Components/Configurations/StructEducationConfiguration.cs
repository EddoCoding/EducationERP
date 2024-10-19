using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationERP.Common.Components.Configurations
{
    public class StructEducationConfiguration : IEntityTypeConfiguration<StructEducationalInstitution>
    {
        public void Configure(EntityTypeBuilder<StructEducationalInstitution> builder)
        {
            builder
                .HasMany(x => x.Faculties)
                .WithOne(x => x.StructEducationalInstitution);
        }
    }
}