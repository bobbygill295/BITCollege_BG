using System.Data.Entity;
using BITCollege_BG.Models;

namespace BITCollege_BG
{
    public class BITCollege_BGContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<BITCollege_BG.BITCollege_BGContext>());

        public BITCollege_BGContext() : base("name=BITCollege_BGContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<GPAState> GPAStates { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<ProbationState> ProbationStates { get; set; }

        public DbSet<HonoursState> HonoursStates { get; set; }

        public DbSet<SuspendedState> SuspendedStates { get; set; }

        public DbSet<RegularState> RegularStates { get; set; }

        public DbSet<GradedCourse> GradedCourses { get; set; }

        public DbSet<AuditCourse> AuditCourses { get; set; }

        public DbSet<MasteryCourse> MasteryCourses { get; set; }

        public DbSet<StudentCard> StudentCards { get; set; }

        public DbSet<NextStudentNumber> NextStudentNumbers { get; set; }

        public DbSet<NextRegistrationNumber> NextRegistrationNumbers { get; set; }

        public DbSet<NextGradedCourse> NextGradedCourses { get; set; }

        public DbSet<NextAuditCourse> NextAuditCourses { get; set; }

        public DbSet<NextMasteryCourse> NextMasteryCourses { get; set; }
    }
}
