using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UpCourse.DataAccess;
using UpCourse.Dtos;
using UpCourse.Entities;
using UpCourse.Enums;
using UpCourse.Exceptions;

namespace UpCourse.Services
{
    public interface ICourseService
    {
        int Create(CourseCreateDto dto);
        void Delete(int courseId);
        void Update(int courseId, CourseUpdateDto dto);
        CourseResponseDto GetById(int id);
        List<CourseListResponseDto> GetAllCourses(string query, CourseOrderBy? orderBy);
    }

    public class CourseService : ICourseService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public List<CourseListResponseDto> GetAllCourses(string query, CourseOrderBy? orderBy)
        {
            query = query.ToLower();
            var courses = _db.Courses
                .Include(c => c.Upvotes)
                .Include(c => c.Tags)
                .Include(c => c.Topic).Where(c =>
                    c.Name.ToLower().Contains(query)
                    || c.Description.ToLower().Contains(query)
                    || c.Topic.Name.ToLower().Contains(query))
                .ToList();

            if (orderBy is not null)
            {
                switch (orderBy)
                {
                    case CourseOrderBy.Upvotes:
                        courses = courses.OrderBy(c => c.Upvotes.Count()).ToList();
                        break;
                    default:
                        break;
                }
            }
            
            var coursesDtos = _mapper.Map<List<CourseListResponseDto>>(courses);
            return coursesDtos;
        }

        public CourseResponseDto GetById(int id)
        {
            var course = _db.Courses
                .Include(c => c.Author)
                .Include(c => c.Source)
                .Include(c => c.Upvotes)
                .Include(c => c.Tags)
                .Include(c => c.Topic).FirstOrDefault(c => c.Id == id);

            if (course is null) throw new NotFoundException();
            var courseDto = _mapper.Map<CourseResponseDto>(course);
            return courseDto;

        }

        public int Create(CourseCreateDto dto)
        {
            var newCourse = _mapper.Map<Course>(dto);
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
            return newCourse.Id;
        }

        public void Delete(int courseId)
        {
            var course = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course is null) throw new NotFoundException();
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }

        public void Update(int courseId, CourseUpdateDto dto)
        {
            var course = _db.Courses.Include(c=>c.Source).FirstOrDefault(c => c.Id == courseId);
            if (course is null) throw new NotFoundException();
            course.Name = dto.Name;
            course.Description = dto.Description;
            course.AuthorId = dto.AuthorId;
            course.Source.Url = dto.Source.Url;
            // TODO: Allow for platform url change
            course.Source.PlatformName = dto.Source.PlatformName;
            course.TopicId = dto.TopicId;
            _db.SaveChanges();
        }
    }
}