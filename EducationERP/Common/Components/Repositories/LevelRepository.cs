using EducationERP.Models;
using EducationERP.ViewModels.Modules.Administration.SettingAdmissionCampaign;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class LevelRepositor : ILevelRepository
    {
        public async Task<bool> Create(EducationalLevelPreparation level)
        {
            using (var db = new DataContext())
            {
                try
                {
                    db.SettingLevels.Add(level);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления!");
                    return false; 
                }
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<EducationalLevelPreparationVM> Read()
        {
            using (var db = new DataContext())
            {
                return db.SettingLevels.Select(level => new EducationalLevelPreparationVM
                {
                    Id = level.Id,
                    LevelName = level.LevelName,
                    DirectionsTraining = level.DirectionsTraining.Select(direction => new EducationalDirectionTrainingVM
                    {
                        Id = direction.Id,
                        DirectionCode = direction.DirectionCode,
                        DirectionName = direction.DirectionName,
                        EducationalProfiles = direction.EducationalProfiles.Select(profile => new EducationalProfileVM
                        {
                            Id = profile.Id,
                            ProfileCode = profile.ProfileCode,
                            ProfileName = profile.ProfileName
                        }).ToList()
                    }).ToList()
                }).ToList();
            }
        }

        public Task Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}