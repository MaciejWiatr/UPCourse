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
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual CourseAuthor Author { get; set; }
        public int SourceId { get; set; }
        public virtual CourseSource Source { get; set; }
        public virtual List<CourseUpvote> Upvotes { get; set; }
        
        public virtual List<CourseTag> Tags { get; set; }
        
        public virtual CourseTopic Topic { get; set; }
    }
}
