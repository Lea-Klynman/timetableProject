using System.Drawing;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TimeTable.Core.Entity;
namespace TimeTable.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AvailabilityEntity> _Availabilities { get; set; }
        public DbSet<ClassEntity> _Classes { get; set; }
        public DbSet<SubjectEntity> _Subjects { get; set; }
        public DbSet<TeacherEntity> _Teachers { get; set; }
        public DbSet<TeacherClassSubjectEntity> _TeacherClassSubject{ get ;set; }
        public DbSet<ClassSubjectEntity> _ClassSubject { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(m => Console.WriteLine(m));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
