﻿using Microsoft.AspNetCore.Mvc;
using UpCourse.Dtos;
using UpCourse.Services;

namespace UpCourse.Controllers
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
        
    }
}