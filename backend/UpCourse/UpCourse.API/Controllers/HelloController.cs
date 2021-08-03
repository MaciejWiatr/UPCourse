using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpCourse.API.DataAccess;
using UpCourse.API.Dtos.response;

namespace UpCourse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _db;

        public HelloController(AppDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CourseResponseDto> Get()
        {
            var courses = _db.Courses.Include(c => c.Author)
                .Include(c=>c.Source).Include(c=>c.Upvotes)
                .Include(c=>c.Tags)
                .Include(c=>c.Topic)
                .ToList();
            var resp = _mapper.Map<List<CourseResponseDto>>(courses);
            return resp;
        }
    }
}
