using System;
using Bogus;
using CursoOnline.Dominio._Base;
using FluentAssertions;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using OnlineCourse.DomainTest._Builders;
using Xunit;
using Xunit.Abstractions;

namespace OnlineCourse.DomainTest.Courses
{
    public class CourseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _name;
        private readonly int _workload;
        private readonly TargetAudience _targetAudience;
        private readonly double _courseFee;
        private readonly string _description;
        private readonly Faker _faker;
        public CourseTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");
            _faker = new Faker();
            _name = _faker.Random.Word();
            _workload = _faker.Random.Int(50, 1000);
            _targetAudience = TargetAudience.Estudante;
            _courseFee = _faker.Random.Double(500, 2000);
            _description = _faker.Lorem.Paragraph();
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
                .Throw<DomainException>()
                .Where(d => d.ErrorMessages.Contains(Resource.InvalidName));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void CursoNaoDeveSerCriadoComCargaHorariaMenorQue1(int invalidWorkload)
        {

            FluentActions.Invoking(() => CourseBuilder.New().WithWorkload(invalidWorkload).Build())
                .Should().Throw<DomainException>()
                .Where(d => d.ErrorMessages.Contains(Resource.InvalidWorkload));
        }

        [Fact]
        public void DeveAlterarValor() { 
            var valorEsperado = _faker.Random.Double(500, 2000);
            var curso = CourseBuilder.New().Build();
            curso.UpdateCourseFee(valorEsperado);
            curso.CourseFee.Should().Be(valorEsperado);
        }
        [Fact]
        public void DeveAlterarNome()
        {
            var valorEsperado = _faker.Random.Word();
            var curso = CourseBuilder.New().Build();
            curso.UpdateName(valorEsperado);
            curso.Name.Should().Be(valorEsperado);
        }
        [Fact]
        public void DeveAlterarCargaHoraria()
        {
            var valorEsperado = _faker.Random.Int(50, 1000);
            var curso = CourseBuilder.New().Build();
            curso.UpdateWorkload(valorEsperado);
            curso.Workload.Should().Be(valorEsperado);
        }
        [Theory]
        [InlineData(0.0)]
        [InlineData(-2.0)]
        [InlineData(-100.0)]
        public void CursoNaoDeveSerAlteradoComValorMenorQue1(double invalidFee)
        {
            var course = CourseBuilder.New().Build();
            FluentActions.Invoking(() => course.UpdateCourseFee(invalidFee))
                .Should().Throw<DomainException>()
                .Where(d => d.ErrorMessages.Contains(Resource.InvalidCourseFee));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveSerAlteradoComNomeInválido(string invalidName)
        {
            var course = CourseBuilder.New().Build();
            FluentActions.Invoking(() => course.UpdateName(invalidName))
                .Should()
                .Throw<DomainException>()
                .Where(d => d.ErrorMessages.Contains(Resource.InvalidName));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void CursoNaoDeveSerAlteradoComCargaHorariaMenorQue1(int invalidWorkload)
        {
            var course = CourseBuilder.New().Build();
            FluentActions.Invoking(() => course.UpdateWorkload(invalidWorkload))
                .Should().Throw<DomainException>()
                .Where(d => d.ErrorMessages.Contains(Resource.InvalidWorkload));
        }
    }

}