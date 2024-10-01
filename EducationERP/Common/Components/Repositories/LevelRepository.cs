using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EducationERP.Common.Components.Repositories
{
    public class LevelRepositor : ILevelRepository
    {
        public SettingLevel[] ReadLevels()
        {
            using(var db = new DataContext())
            {
                return db.Levels
                    .Include(x => x.Directions)
                    .ThenInclude(x => x.Profiles)
                    .ThenInclude(x => x.Forms)
                    .ToArray();
            }
        }

        public bool CreateLevel(SettingLevel level)
        {
            using(var db = new DataContext())
            {
                db.Levels.Add(level);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteLevel(Guid id)
        {
            using (var db = new DataContext())
            {
                var level = db.Levels.FirstOrDefault(x => x.Id == id);
                if (level != null)
                {
                    db.Levels.Remove(level);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }   

        public bool CreateDirection(SettingDirection direction)
        {
            using (var db = new DataContext())
            {
                db.Directions.Add(direction);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteDirection(Guid id)
        {
            using (var db = new DataContext())
            {
                var direction = db.Directions.FirstOrDefault(x => x.Id == id);
                if (direction != null)
                {
                    db.Directions.Remove(direction);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool CreateProfile(SettingProfile profile)
        {
            using (var db = new DataContext())
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteProfile(Guid id)
        {
            using (var db = new DataContext())
            {
                var profile = db.Profiles.FirstOrDefault(x => x.Id == id);
                if (profile != null)
                {
                    db.Profiles.Remove(profile);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool CreateForm(SettingForm form)
        {
            using (var db = new DataContext())
            {
                db.Forms.Add(form);
                db.SaveChanges();
                return true;
            }

            return false;
        }
        public bool DeleteForm(Guid id)
        {
            using (var db = new DataContext())
            {
                var form = db.Forms.FirstOrDefault(x => x.Id == id);
                if (form != null)
                {
                    db.Forms.Remove(form);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}