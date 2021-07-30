﻿using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UpCourse.DataAccess;
using UpCourse.Dtos;
using UpCourse.Entities;
using UpCourse.Exceptions;

namespace UpCourse.Services
{
    public interface ICourseService
    {
        int Create(CourseCreateDto dto);
        void Delete(int courseId);
        void Update(int courseId, CourseUpdateDto dto);
        CourseResponseDto GetById(int id);
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
            course.Source.PlatformName = dto.Source.PlatformName;
            course.TopicId = dto.TopicId;
            _db.SaveChanges();
        }
    }
}