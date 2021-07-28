using System.Collections.Generic;

namespace UpCourse.Entities
{
    public class CourseAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public List<Course> Courses { get; set; }
    }
}