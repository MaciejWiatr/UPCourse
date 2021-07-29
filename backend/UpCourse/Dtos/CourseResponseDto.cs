﻿using System.Collections.Generic;
using UpCourse.Entities;

namespace UpCourse.Dtos
{
    public class CourseResponseDto
    {
        public int Id { get; set; }
        public TopicDto Topic { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }
        public CourseSourceDto Source { get; set; }
        public int UpvotesCount { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}