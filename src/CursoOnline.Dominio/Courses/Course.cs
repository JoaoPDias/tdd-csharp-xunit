using CursoOnline.Dominio._Base;
using OnlineCourse.Domain.Base;
using System;
using System.Dynamic;

namespace OnlineCourse.Domain.Courses
{
    public class Course : Entity
    {
        public string Name { get; private set; }
        public int Workload { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double CourseFee { get; private set; }
        public string Description { get; private set; }
        private Course()
        {

        }
        public Course(string name, int workload, TargetAudience targetAudience, double courseFee, string description)
        {
            RuleValidator
                .New()
                .When(string.IsNullOrEmpty(name), Resource.InvalidName)
                .When(workload < 1, Resource.InvalidWorkload)
                .When(courseFee < 1, Resource.InvalidCourseFee)
                .ThrowExceptionIfExists();
            Name = name;
            Workload = workload;
            TargetAudience = targetAudience;
            CourseFee = courseFee;
            Description = description;
        }
       
        public Course UpdateName(string name)
        {
            RuleValidator
                .New()
                .When(string.IsNullOrEmpty(name), "The name cannot be empty or null")
                .ThrowExceptionIfExists();
            Name = name;
            return this;
        }
        public Course UpdateWorkload(int workload)
        {
            RuleValidator
                .New()
                 .When(workload < 1, Resource.InvalidWorkload)
                 .ThrowExceptionIfExists();
            Workload = workload;
            return this;
        }
        public Course UpdateCourseFee(double courseFee)
        {
            RuleValidator
                .New()
                  .When(courseFee < 1, Resource.InvalidCourseFee)
               .ThrowExceptionIfExists();
            CourseFee = courseFee;
            return this;
        }
        public CourseDTO ToCourseDTO()
        {
            return new CourseDTO
            {
                Id = this.Id,
                Name = this.Name,
                Workload = this.Workload,
                TargetAudience = this.TargetAudience.ToString(),
                CourseFee = this.CourseFee,
                Description = this.Description
            };
        }

        public Course UpdateDescription(string description)
        {
            Description = description;
            return this;
        }

        public Course UpdateTargetAudience(TargetAudience targetAudience)
        {
            TargetAudience = targetAudience;
            return this;

        }
    }
}