using System.Collections.Generic;

namespace UpCourse.API.Entities
{
    public class CourseTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}