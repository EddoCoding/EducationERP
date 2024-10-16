using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace EducationERP.Common.Components.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        public IEnumerable<Applicant> Read()
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.Applicants
                        .Include(x => x.Documents)
                        .Include(x => x.Educations)
                        .Include(x => x.EGES)
                        .Include(x => x.DistinguishingFeatures)
                        .Include(x => x.DirectionsOfTraining)
                        .Include(x => x.Exams)
                        .ToArray();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка получения данных из базы данных!");
                return Enumerable.Empty<Applicant>();
            }
        }
        public async Task<bool> Create<T>(T model) where T : class
        {
            using (var db = new DataContext())
            {
                try
                {
                    await db.Set<T>().AddAsync(model);
                    await db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления данных в базу данных!");
                    return false;
                }
            }
        }
        public async Task<bool> Delete<T>(Guid id) where T : class
        {
            using (var db = new DataContext())
            {
                try
                {
                    var entity = await db.Set<T>().FindAsync(id);
                    if (entity != null)
                    {
                        db.Set<T>().Remove(entity);
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления данных из базы данных!");
                    return false;
                }
                
            }
            return false;
        }
        public async Task<bool> Update(Applicant applicant)
        {
            using(var db = new DataContext())
            {
                try
                {
                    var entity = await db.Applicants
                        .Where(x => x.Id == applicant.Id)
                        .FirstOrDefaultAsync();

                    if (entity != null) 
                    {
                        entity.SurName = applicant.SurName;
                        entity.Name = applicant.Name;
                        entity.MiddleName = applicant.MiddleName;
                        entity.DateOfBirth = applicant.DateOfBirth;
                        entity.Gender = applicant.Gender;
                        entity.PlaceOfBirth = applicant.PlaceOfBirth;
                        entity.IsCitizenRus = applicant.IsCitizenRus;
                        entity.NotCitizen = applicant.NotCitizen;
                        entity.IsForeign = applicant.IsForeign;
                        entity.Citizenship = applicant.Citizenship;
                        entity.CitizenshipValidFrom = applicant.CitizenshipValidFrom;
                        entity.IsNeedHostel = applicant.IsNeedHostel;
                        entity.IsNotNeedHostel = applicant.IsNotNeedHostel;
                        entity.AdditionalInformation = applicant.AdditionalInformation;

                        entity.ResidentialAddress = applicant.ResidentialAddress;
                        entity.AddressOfRegistration = applicant.AddressOfRegistration;
                        entity.HomePhone = applicant.HomePhone;
                        entity.MobilePhone = applicant.MobilePhone;
                        entity.Mail = applicant.Mail;
                        entity.AdditionalContactInformation = applicant.AdditionalContactInformation;

                        entity.TotalPoints = applicant.TotalPoints;
                        entity.PointsDistinctiveFeatures = applicant.PointsDistinctiveFeatures;
                        entity.SumPointsExam = applicant.SumPointsExam;

                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления данных в базе данных!");
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> Update(Exam exam)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var entity = await db.Exams
                        .Where(x => x.Id == exam.Id)
                        .FirstOrDefaultAsync();

                    if (entity != null) 
                    {
                        entity.SubjectScores = exam.SubjectScores;
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления баллов в базе данных!");
                    return false;
                }

                return false;
            }
        }
        public async Task<bool> UpdateSatatus(Guid id)
        {
            using (var db = new DataContext()) 
            {
                try
                {
                    var entity = await db.Applicants
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

                    if (entity != null)
                    {
                        entity.ForEnrollment = !entity.ForEnrollment;
                        await db.SaveChangesAsync();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка обновления статуса в базе данных!");
                    return false;
                }
            }
            return false;
        }
    }
}