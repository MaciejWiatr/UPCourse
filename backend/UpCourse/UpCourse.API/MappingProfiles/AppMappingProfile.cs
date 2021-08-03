using AutoMapper;
using UpCourse.API.Dtos.common;
using UpCourse.API.Dtos.request;
using UpCourse.API.Dtos.response;
using UpCourse.API.Entities;

namespace UpCourse.API.MappingProfiles
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Course, CourseResponseDto>();
            CreateMap<CourseAuthor, AuthorDto>();
            CreateMap<CourseSource, CourseSourceDto>();
            CreateMap<CourseSourceDto, CourseSource>();
            CreateMap<CourseTag, TagDto>();
            CreateMap<CourseTopic, TopicDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseResponseDto, Course>();
            CreateMap<Course, CourseListResponseDto>();
        }
    }
}