using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UpCourse.API.Config;
using UpCourse.API.Entities;
using UpCourse.API.Utils;

namespace UpCourse.API.DataAccess
{
    public class AppDbContext : DbContext
    {
        private readonly DbConfig _dbConfig;

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAuthor> CourseAuthors { get; set; }
        public DbSet<CourseSource> CourseSources { get; set; }
        public DbSet<CourseUpvote> CourseUpvotes { get; set; }
        public DbSet<CourseDownvote> CourseDownvotes { get; set; }
        public DbSet<CourseTopic> CourseTopics { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        private bool TestRun { get; set; }

        public AppDbContext(IOptions<DbConfig> settings, bool testRun = false)
        {
            _dbConfig = settings.Value;
            TestRun = testRun;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<Course>().HasOne(c => c.Author).WithMany(c => c.Courses);
            modelBuilder.Entity<CourseAuthor>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<CourseSource>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<CourseUpvote>().Property(c => c.Id).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version());

            if (!TestRun)
            {
                optionsBuilder.UseMySql(DbUtils.GenerateConnectionString(_dbConfig), serverVersion);
            }
            else
            {
                var testConfig = new DbConfig()
                {
                    Host = "localhost",
                    Login = "root",
                    Password = "",
                    DatabaseName = "upctest"
                };
                optionsBuilder.UseMySql(DbUtils.GenerateConnectionString(testConfig), serverVersion);
            }
        }
    }
}
