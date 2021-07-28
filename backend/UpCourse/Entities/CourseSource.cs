using System.Collections.Generic;

namespace UpCourse.Entities
{
    public class CourseSource
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public string Url { get; set; }
        public List<Course> Courses { get; set; }
    }
}