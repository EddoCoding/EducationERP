using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class StructEducationRepository : IStructEducationRepository
    {
        public StructEducationalInstitution GetStructEducation()
        {
            using (var db = new DataContext())
            {
                try
                {
                    return db.StructEducationalInstitution.FirstOrDefault();
                }
                catch
                {
                    MessageBox.Show("Ошибка получения данных об учебном заведении из базы данных!");
                }
            }

            return null;
        }
        public async Task SaveStructEducation(StructEducationalInstitution structEducation)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var entity = await db.StructEducationalInstitution.FirstOrDefaultAsync();
                    if(entity == null)
                    {
                        db.StructEducationalInstitution.Add(structEducation);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Данные об учебном заведении добавлены в базу данных!");
                        return;
                    }

                    entity.NameVUZ = structEducation.NameVUZ;
                    entity.ShortNameVUZ = structEducation.ShortNameVUZ;
                    await db.SaveChangesAsync();
                    MessageBox.Show("Данные учебного заведения обновлены в базе данных!");
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения данных об учебном заведении в базу данных!");
                }
            }
        }
    }
}