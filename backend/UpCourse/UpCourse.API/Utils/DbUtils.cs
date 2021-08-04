using System.Linq;
using Microsoft.EntityFrameworkCore;
using UpCourse.API.Config;
using UpCourse.API.DataAccess;
using UpCourse.API.Entities;

namespace UpCourse.API.Utils
{
    public static class DbUtils
    {
        public static string GenerateConnectionString(DbConfig config)
        {
            return $"server={config.Host};user={config.Login};password={config.Password};database={config.DatabaseName}";
        }

        public static void PopulateDb(this AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
            
            if (!dbContext.CourseTopics.Any())
            {
                dbContext.CourseTopics.Add(new CourseTopic()
                {
                    Id = 1,
                    Name = "Test"
                });
            }else if (!dbContext.CourseAuthors.Any())
            {
                dbContext.CourseAuthors.Add(new CourseAuthor()
                {
                    Id = 1,
                    Name = "Test",
                    PhotoUrl = "https://example.com"
                });
            }

            dbContext.SaveChanges();
        }

        public static void CleanDb(this AppDbContext dbContext)
        {
            if (!dbContext.Courses.Any()) return;
            dbContext.RemoveRange(dbContext.Courses);
            dbContext.SaveChanges();
        }
    }
}