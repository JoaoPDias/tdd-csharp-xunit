using Bogus;
using OnlineCourse.Domain.Courses;

namespace OnlineCourse.DomainTest._Builders
{
    public class CourseBuilder
    {
        private string _name;
        private int _workload;
        private TargetAudience _targetAudience;
        private double _courseFee;
        private string _description;

        public static CourseBuilder New()
        {
            return new CourseBuilder();
            
        }

        public CourseBuilder()
        {
            var faker = new Faker();
            _name = faker.Random.Word();
            _workload = faker.Random.Int(50, 1000);
            _targetAudience = TargetAudience.Estudante;
            _courseFee = faker.Random.Double(500, 2000);
            _description = faker.Lorem.Paragraph();
        }

        public CourseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public CourseBuilder WithWorkload(int workload)
        {
            _workload = workload;
            return this;
        }
        public CourseBuilder WithTargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }
        public CourseBuilder WithFee(double courseFee)
        {
            _courseFee = courseFee;
            return this;
        }
        public CourseBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public Course Build()
        {
            return new Course(_name,_workload,_targetAudience,_courseFee,_description);
        }
    }
}