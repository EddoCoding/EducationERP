using EducationERP.Models.Modules.EducationalInstitution;

namespace EducationERP.Common.Components.Repositories
{
    public interface IStructEducationRepository
    {
        StructEducationalInstitution GetStructEducation();
        Task SaveStructEducation(StructEducationalInstitution structEducation);
    }
}