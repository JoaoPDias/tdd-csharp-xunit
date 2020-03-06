using System;
using Bogus;
using FluentAssertions;
using OnlineCourse.Domain.Courses;
using OnlineCourse.DomainTest._Builders;
using Xunit;
using Xunit.Abstractions;

namespace OnlineCourse.DomainTest.Cursos
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _name;
        private readonly int _workload;
        private readonly TargetAudience _targetAudience;
        private readonly double _courseFee;
        private readonly string _description;

        public CourseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");
            var faker = new Faker();
            _name = faker.Random.Word();
            _workload = faker.Random.Int(50, 1000);
            _targetAudience = TargetAudience.Estudante;
            _courseFee = faker.Random.Double(500, 2000);
            _description = faker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var ExpectedCourse = new
            {
                Name = _name,
                Workload = _workload,
                TargetAudience = _targetAudience,
                CourseFee = _courseFee,
                Description = _description

            };
            var course = new Course(ExpectedCourse.Name, ExpectedCourse.Workload, ExpectedCourse.TargetAudience,
                ExpectedCourse.CourseFee, ExpectedCourse.Description);
            course.Should().BeEquivalentTo(ExpectedCourse);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveSerCriadoComNomeInválido(string invalidName)
        {
            FluentActions.Invoking(() => CourseBuilder.New().WithName(invalidName).Build())
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("The name cannot be empty or null");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void CursoNaoDeveSerCriadoComCargaHorariaMenorQue1(int invalidWorkload)
        {

            FluentActions.Invoking(() => CourseBuilder.New().WithWorkload(invalidWorkload).Build())
                .Should().Throw<ArgumentException>()
                .WithMessage("The workload cannot be less than 1");
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(-2.0)]
        [InlineData(-100.0)]
        public void CursoNaoDeveSerCriadoComValorMenorQue1(double invalidFee)
        {
            FluentActions.Invoking(() => CourseBuilder.New().WithFee(invalidFee).Build())
                .Should().Throw<ArgumentException>()
                .WithMessage("The courseFee cannot be less than 1");
        }
    }

}