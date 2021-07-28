using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCourse.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public CourseAuthor Author { get; set; }
        public CourseSource CourseSource { get; set; }
        public List<CourseUpvote> Upvotes { get; set; }
    }
}
