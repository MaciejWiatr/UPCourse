using System.Collections.Generic;

namespace UpCourse.Dtos
{
    public class CourseListResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UpvotesCount { get; set; }
        public TopicDto Topic { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}