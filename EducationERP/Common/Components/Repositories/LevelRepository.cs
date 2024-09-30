using EducationERP.Common.Components;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;

namespace EducationERP.Common.Components.Repositories
{
    public class LevelRepositor : ILevelRepository
    {
        public void CreateLevel(SettingLevel level)
        {
            using(var db = new DataContext())
            {
                db.Levels.Add(level);
                db.SaveChanges();
            }
        }

        public SettingLevel[] ReadLevels()
        {
            using(var db = new DataContext())
            {
                return db.Levels
                    .Include(x => x.Directions)
                    .ToArray();
            }
        }
    }
}

//using (var db = new DataContext())
//{
//
//}