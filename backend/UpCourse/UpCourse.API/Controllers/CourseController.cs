using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UpCourse.API.Dtos.request;
using UpCourse.API.Dtos.response;
using UpCourse.API.Enums;
using UpCourse.API.Services;

namespace UpCourse.API.Controllers
{
    [Route("/api/v1/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<CourseListResponseDto>> GetAllCourses( [FromQuery] CourseOrderBy orderBy = CourseOrderBy.Upvotes , [FromQuery] string q = "")
        {
            var result = _courseService.GetAllCourses(q, orderBy);
            return result;
        }

        [HttpGet("{id:int}")]
        public ActionResult<CourseResponseDto> GetCourseById([FromRoute] int id)
        {
            var result = _courseService.GetById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public ActionResult AddCourse(CourseCreateDto dto)
        {
            var result = _courseService.Create(dto);
            return Ok(new {id=result});
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCourse([FromRoute] int id)
        {
            _courseService.Delete(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateCourse([FromRoute] int id, [FromBody] CourseUpdateDto dto)
        {
            _courseService.Update(id, dto);
            return Ok();
        }

        [HttpPost("{id:int}/upvote")]
        public ActionResult UpvoteCourse([FromRoute] int id)
        {
            _courseService.Downvote(id);
            return Ok();
        }
        
        [HttpPost("{id:int}/downvote")]
        public ActionResult DownvoteCourse([FromRoute] int id)
        {
            _courseService.Downvote(id);
            return Ok();
        }
        
    }
}