using Bogus;
using CursoOnline.Dominio._Base;
using FluentAssertions;
using Moq;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using OnlineCourse.DomainTest._Builders;
using System;
using Xunit;

namespace OnlineCourse.DomainTest.Courses
{
    public class CourseServiceTest
    {
        private CourseDTO _courseDTO;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private CourseService _courseService;
        public CourseServiceTest()
        {
            var faker = new Faker();
            _courseDTO = new CourseDTO
            {
                Name = faker.Random.Words(),
                Workload = faker.Random.Int(50, 1000),
                TargetAudience = "Estudante",
                CourseFee = faker.Random.Double(50, 1000),
                Description = faker.Lorem.Paragraph()
            };

            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseService = new CourseService(_courseRepositoryMock.Object);
        }
        [Fact]
        public void DeveAdicionarCurso()
        {

            _courseService.Save(_courseDTO);
            _courseRepositoryMock.Verify(r => r.Add(It.Is<Course>(c => c.Name == _courseDTO.Name)));
        }
        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var targetAudienceInvalid = "Médico";
            _courseDTO.TargetAudience = targetAudienceInvalid;
            FluentActions.Invoking(() => _courseService.Save(_courseDTO)).Should().Throw<DomainException>().Where(d => d.ErrorMessages.Contains(Resource.InvalidTargetAudience));
        }
        [Fact]
        public void NaoDeveAdicionarCursoComOMesmoNomeEIdDiferenteDoOutroSalvo()
        {
            var cursoJaSalvo = CourseBuilder.New().WithName(_courseDTO.Name).WithId(40).Build();
            _courseRepositoryMock.Setup(r => r.GetByName(_courseDTO.Name)).Returns(cursoJaSalvo);
            _courseDTO.Id = 60;
            FluentActions.Invoking(() => _courseService.Save(_courseDTO)).Should().Throw<DomainException>().Where(d => d.ErrorMessages.Contains(Resource.CourseNameAlreadyExists));

        }
    }
}
