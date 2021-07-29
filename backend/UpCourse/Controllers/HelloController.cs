using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UpCourse.DataAccess;
using UpCourse.Dtos;
using UpCourse.Entities;

namespace UpCourse.Controllers
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
