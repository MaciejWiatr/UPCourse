using AutoMapper;
using UpCourse.DataAccess;
using UpCourse.Dtos;
using UpCourse.Entities;

namespace UpCourse.MappingProfiles
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