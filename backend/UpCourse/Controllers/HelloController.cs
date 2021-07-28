using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpCourse.DataAccess;

namespace UpCourse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {

        private readonly AppDbContext _db;

        public HelloController(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {message = "hello world", dbtest = _db.Courses});
        }
    }
}
