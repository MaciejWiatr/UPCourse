using System.Collections.Generic;

namespace UpCourse.API.Entities
{
    public class CourseTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}