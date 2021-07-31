using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UpCourse.Entities;

namespace UpCourse.Dtos
{
    public class CourseCreateDto
    {
        [Required]
        public int TopicId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public CourseSourceDto Source { get; set; }
    }
}