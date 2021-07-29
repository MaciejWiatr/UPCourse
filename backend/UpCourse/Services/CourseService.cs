using UpCourse.DataAccess;
using UpCourse.Dtos;

namespace UpCourse.Services
{
    public class CourseService
    {
        private readonly AppDbContext _db;
        
        public CourseService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public int Create(CourseCreateDto dto)
        {
            return 1;
        }
    }
}