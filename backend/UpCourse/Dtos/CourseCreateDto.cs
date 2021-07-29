using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UpCourse.Entities;

namespace UpCourse.Dtos
{
    public class CourseCreateDto
    {
        [Required]
        public string Description { get; set; }
        public AuthorResponseDto CourseAuthor { get; set; }
        [Required]
        public CourseSource CourseSource { get; set; }
    }
}