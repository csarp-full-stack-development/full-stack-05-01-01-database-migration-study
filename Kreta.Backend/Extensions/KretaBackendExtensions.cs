using Kreta.Backend.Context;
using Kreta.Backend.Repos;
using Kreta.Backend.Repos.Managers;
using Kreta.Backend.Repos.SwitchTables;
using Kreta.Backend.Services;
using Kreta.Shared.Assamblers;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Extensions
{
    public static class KretaBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7020/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
            );
            string connectionString = "server=localhost;userid=root;password=;database=kreta;port=3306";
            services.AddDbContext<KretaMySqlContext>(options => options.UseMySQL(connectionString));
        }

        public static void ConfigureRepoService(this IServiceCollection services)
        {
            bool test = false;
            if (test)
            {
                services.AddScoped<ITeacherRepo, TeacherRepo<KretaInMemoryContext>>();
                services.AddScoped<IGradeRepo, GradeRepo<KretaInMemoryContext>>();
                services.AddScoped<IParentRepo, ParentRepo<KretaInMemoryContext>>();
                services.AddScoped<IStudentRepo, StudentRepo<KretaInMemoryContext>>();
                services.AddScoped<ISubjectRepo, SubjectRepo<KretaInMemoryContext>>();
                services.AddScoped<IEducationLevelRepo, EducationLevelRepo<KretaInMemoryContext>>();
                services.AddScoped<ISchoolClassRepo, SchoolClassRepo<KretaInMemoryContext>>();
                services.AddScoped<IAddressRepo, AddressRepo<KretaInMemoryContext>>();
                services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<KretaInMemoryContext>>();
                services.AddScoped<ITypeOfEducationRepo, TypeOfEducationRepo<KretaInMemoryContext>>();
                services.AddScoped<ISubjectTypeRepo, SubjectTypeRepo<KretaInMemoryContext>>();

                services.AddScoped<ISchoolClassStudentsRepo, SchoolClassStudentsRepo<KretaInMemoryContext>>();
                services.AddScoped<ISchoolClassSubjectsRepo, SchoolClassSubjectsRepo<KretaInMemoryContext>>();
                services.AddScoped<ITeacherTeachInSchoolClass, TeacherTeachInSchoolClassRepo<KretaInMemoryContext>>();
            }
            else
            {
                services.AddScoped<ITeacherRepo, TeacherRepo<KretaMySqlContext>>();
                services.AddScoped<IGradeRepo, GradeRepo<KretaMySqlContext>>();
                services.AddScoped<IParentRepo, ParentRepo<KretaMySqlContext>>();
                services.AddScoped<IStudentRepo, StudentRepo<KretaMySqlContext>>();
                services.AddScoped<ISubjectRepo, SubjectRepo<KretaMySqlContext>>();
                services.AddScoped<IEducationLevelRepo, EducationLevelRepo<KretaMySqlContext>>();
                services.AddScoped<ISchoolClassRepo, SchoolClassRepo<KretaMySqlContext>>();
                services.AddScoped<IAddressRepo, AddressRepo<KretaMySqlContext>>();
                services.AddScoped<IPublicSpaceRepo, PublicSpaceRepo<KretaMySqlContext>>();
                services.AddScoped<ITypeOfEducationRepo, TypeOfEducationRepo<KretaMySqlContext>>();
                services.AddScoped<ISubjectTypeRepo, SubjectTypeRepo<KretaMySqlContext>>();

                services.AddScoped<ISchoolClassStudentsRepo, SchoolClassStudentsRepo<KretaMySqlContext>>();
                services.AddScoped<ISchoolClassSubjectsRepo, SchoolClassSubjectsRepo<KretaMySqlContext>>();
                services.AddScoped<ITeacherTeachInSchoolClass, TeacherTeachInSchoolClassRepo<KretaMySqlContext>>();
            }

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<TeacherAssambler>();
            services.AddScoped<GradeAssambler>();
            services.AddScoped<ParentAssambler>();
            services.AddScoped<StudentAssambler>();
            services.AddScoped<SubjectAssambler>();
            services.AddScoped<TypeOfEducationAssambler>();
            services.AddScoped<EducationLevelAssambler>();
            services.AddScoped<SchoolClassAssambler>();
            services.AddScoped<AddressAssambler>();
            services.AddScoped<PublicSpaceAssambler>();
            services.AddScoped<SchoolClassAssambler>();
            services.AddScoped<TypeOfEducationAssambler>();

            services.AddScoped<SchoolClassSubjectsAssambler>();
            services.AddScoped<TeachersTeachInSchoolClassAssambler>();
            services.AddScoped<SchoolClassStudentsAssambler>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolClassSubjectService, SchoolClassSubjectService>();
        }
    }
}
