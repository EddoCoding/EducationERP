using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EducationERP.ViewModels.Modules.DeanRoom.AddEducationGroupViewModel;

namespace EducationERP.Common.Components.Configurations
{
    public class EducationGroupConfiguration : IEntityTypeConfiguration<EducationGroup>
    {
        public void Configure(EntityTypeBuilder<EducationGroup> builder)
        {
            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.EducationGroup);

            builder
                .Property(x => x.TypeGroup)
                .HasConversion(x => x.ToString(), 
                               x => (GroupTypes)Enum.Parse(typeof(GroupTypes), x));
        }
    }
}