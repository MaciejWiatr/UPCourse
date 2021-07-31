using System.ComponentModel.DataAnnotations;

namespace UpCourse.Dtos
{
    public class CourseUpdateDto
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