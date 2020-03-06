using System;

namespace OnlineCourse.Domain.Courses
{
    public class Course
    {

        public Course(string name, int workload, TargetAudience targetAudience, double courseFee, string description)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("The name cannot be empty or null");
            if(workload<1)
                throw new ArgumentException("The workload cannot be less than 1");
            if(courseFee< 1)
                throw new ArgumentException("The courseFee cannot be less than 1");
            Name = name;
            Workload = workload;
            TargetAudience = targetAudience;
            CourseFee = courseFee;
            Description = description;
        }

        public string Name { get; private set; }
        public int? Workload { get; private set; }
        public TargetAudience TargetAudience { get; private set; }
        public double CourseFee { get; private set; }
        public string Description { get; private set; }
    }
}