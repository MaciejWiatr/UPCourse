using System;
using System.Collections.Generic;
using System.Linq;
using UpCourse.API.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MockQueryable.Moq;
using Moq;
using UpCourse.API.Config;
using UpCourse.API.Dtos.common;
using UpCourse.API.Dtos.request;
using UpCourse.API.Entities;
using UpCourse.API.MappingProfiles;
using UpCourse.API.Services;
using UpCourse.API.Utils;
using Xunit;

// TODO: Swap out xunit to nunit because of its better teardown-function capabilities

namespace Upcourse.Test.Services
{
    public class TestCourseService
    {
        private IMapper _mapper;
        private AppDbContext _dbContext;
        private ICourseService _courseService;

        public TestCourseService()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AppMappingProfile>());
            _mapper = new Mapper(config);
            var dbOptions = new Mock<IOptions<DbConfig>>();
            // TODO: Figure out better way to test db heavy functions
            _dbContext = new AppDbContext(dbOptions.Object, testRun: true);
            _dbContext.PopulateDb();
            _courseService = new CourseService(_dbContext,_mapper);
        }

        [Fact]
        public void TestCourseCreate()
        {
            var createDto = new CourseCreateDto()
            {
                TopicId = 1,
                Name = "Test",
                Description = "test",
                AuthorId = 1,
                Source = new CourseSourceDto()
                {
                    PlatformName = "Test",
                    Url = "test"
                }
            };
            var id = _courseService.Create(createDto);
            Assert.IsType<int>(id);
            _dbContext.CleanDb();
        }
    }
}