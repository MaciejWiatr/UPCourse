using System.Collections.Generic;
using UpCourse.API.Dtos.common;

namespace UpCourse.API.Dtos.response
{
    public class CourseListResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UpvotesCount { get; set; }
        public int DownvotesCount { get; set; }
        public TopicDto Topic { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}