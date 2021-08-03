using System.ComponentModel.DataAnnotations;
using UpCourse.API.Dtos.common;

namespace UpCourse.API.Dtos.request
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