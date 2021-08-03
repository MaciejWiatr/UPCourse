using System.Collections.Generic;

namespace UpCourse.API.Entities
{
    public class CourseAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}