using CursoOnline.Dominio._Base;
using OnlineCourse.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineCourse.Domain.Courses
{
    public class CourseService
    {

        private readonly ICourseRepository _courseRepository;

        public CourseService()
        {
        }

        public CourseService(ICourseRepository repository)
        {
            _courseRepository = repository;
        }

        public void Save(CourseDTO courseDTO)
        {
            var cursoJaSalvo = _courseRepository.GetByName(courseDTO.Name);
            RuleValidator.New()
                .When(cursoJaSalvo != null && cursoJaSalvo.Id != courseDTO.Id, Resource.CourseNameAlreadyExists)
                .When(!Enum.TryParse(courseDTO.TargetAudience, out TargetAudience targetAudience), Resource.InvalidTargetAudience)
                .ThrowExceptionIfExists();
            var curso = new Course(courseDTO.Name, courseDTO.Workload, targetAudience, courseDTO.CourseFee, courseDTO.Description);


            if (courseDTO.Id > 0)
            {
                curso = _courseRepository.GetById(courseDTO.Id);
                curso.UpdateName(courseDTO.Name)
                    .UpdateCourseFee(courseDTO.CourseFee)
                    .UpdateWorkload(courseDTO.Workload)
                    .UpdateDescription(courseDTO.Description)
                    .UpdateTargetAudience(targetAudience);
            }
            else
            {
                _courseRepository.Add(curso);
            }
        }

        public CourseDTO GetById(int id)
        {
            return _courseRepository.GetById(id).ToCourseDTO(); ;
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            var courses = _courseRepository.GetAll();

            if (courses.Any())
            {
                var coursesDTO = courses.Select(c => c.ToCourseDTO());
                return coursesDTO;
            }
            return null;
        }
    }
}


