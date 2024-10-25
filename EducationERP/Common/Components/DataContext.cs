using EducationERP.Common.Components.Configurations;
using EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign;
using EducationERP.Models.Modules.Administration.SettingUser;
using EducationERP.Models.Modules.AdmissionsCampaign;
using EducationERP.Models.Modules.AdmissionsCampaign.Directions;
using EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures;
using EducationERP.Models.Modules.AdmissionsCampaign.Educations;
using EducationERP.Models.Modules.AdmissionsCampaign.Exams;
using EducationERP.Models.Modules.DeanRoom.DocumentsStudent;
using EducationERP.Models.Modules.EducationalInstitution;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace EducationERP.Common.Components
{
    public class DataContext : DbContext
    {
        #region ПРИЁМНАЯ КАМПАНИЯ
        // -- Документы --
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Snils> Snilss { get; set; }
        public DbSet<Inn> Inns { get; set; }
        public DbSet<ForeignPassport> ForeignPassports { get; set; }
        // -- Образования --
        public DbSet<EducationNine> EducationsNine { get; set; }
        public DbSet<EducationEleven> EducationsEleven { get; set; }
        public DbSet<EducationSPO> EducationsSPO { get; set; }
        public DbSet<EducationBak> EducationsBak { get; set; }
        public DbSet<EducationMag> EducationsMag { get; set; }
        public DbSet<EducationAsp> EducationsAsp { get; set; }
        // -- ЕГЭ --
        public DbSet<EGE> EGES { get; set; }
        // -- Отличительные признаки --
        public DbSet<DistinctiveFeature> DistinctiveFeatures { get; set; }
        // -- Выбранные направления --
        public DbSet<SelectedDirection> SelectedDirections { get; set; }
        // -- Назначенные экзамены/испытания --
        public DbSet<Exam> Exams { get; set; }
        #endregion
        #region АДМИНИСТРИРОВАНИЕ
        // -- Настройка структуры учебного заведения --
        public DbSet<StructEducationalInstitution> StructEducationalInstitution { get; set; }
        public DbSet<Faculty> MainFaculties { get; set; }
        public DbSet<Department> MainDepartments { get; set; }

        // -- Настройка пользователей --
        public DbSet<User> Users { get; set; }

        // -- Настройка образования для приёмной кампании --
        public DbSet<SettingFaculty> Faculties { get; set; }
        public DbSet<SettingLevel> Levels { get; set; }
        public DbSet<SettingDirection> Directions { get; set; }
        #endregion
        #region ДЕКАНАТ
        public DbSet<EducationGroup> EducationGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<PassportStudent> PassportsStudent { get; set; }
        public DbSet<SnilsStudent> SnilssStudent { get; set; }
        public DbSet<InnStudent> InnsStudent { get; set; }
        public DbSet<ForeignPassportStudent> ForeignPassportsStudent { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["StrConnection"].ToString());

        public bool CanConnect(string host, string port, string username, string password, string database)
        {
            try
            {
                Database.GetDbConnection().ConnectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";
                if (Database.CanConnect()) return true;
                else return false;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
                return false;
            }
            
        }
        public bool CanConnect()
        {
            try
            {
                if (Database.CanConnect()) return true;
                else
                {
                    MessageBox.Show("Ошибка соединения!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения!");
                return false;
            }

        }

        public bool ApplyMigrate()
        {
            Database.GetDbConnection().ConnectionString = ConfigurationManager.ConnectionStrings["StrConnection"].ToString();

            if (Database.CanConnect()) 
            {
                
                if (Database.GetPendingMigrations().Any())
                {
                    Database.Migrate();
                    SaveIsConfigured();
                    MessageBox.Show("Информационная система сформирована!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Информационная система уже имеется!");
                    SaveIsConfigured();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ошибка соединения!");
                return false;
            }
        }

        void SaveIsConfigured()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["IsConfigured"].Value = "True";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new StructEducationConfiguration());
            modelBuilder.ApplyConfiguration(new MainFacultyConfiguration());
            modelBuilder.ApplyConfiguration(new EducationGroupConfiguration());

            modelBuilder.Entity<Document>().UseTpcMappingStrategy();
            modelBuilder.Entity<EducationBase>().UseTpcMappingStrategy();

            modelBuilder.Entity<DocumentStudentBase>().UseTpcMappingStrategy();

            base.OnModelCreating(modelBuilder);
        }
    }
}