using Bogus;
using Bogus.Extensions.Brazil;
using CursoOnline.Dominio._Base;
using FluentAssertions;
using Moq;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using OnlineCourse.Domain.Students;
using OnlineCourse.DomainTest._Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineCourse.DomainTest.Alunos
{
    public class StudentServiceTest
    {
        private readonly Faker _faker;
        private StudentDTO _studentDTO;
        private Mock<IStudentRepository> _studentRepositoryMock;
        private StudentService _studentService;

        public StudentServiceTest()
        {
            _faker = new Faker();
            _studentDTO = new StudentDTO
            {
                Name = _faker.Person.FullName,
                Email = _faker.Person.Email,
                TargetAudience = _faker.PickRandom<TargetAudience>().ToString(),
                CPF = _faker.Person.Cpf()
            };

            _studentRepositoryMock = new Mock<IStudentRepository>();
            _studentService = new StudentService(_studentRepositoryMock.Object);
        }

        [Fact]
        public void DeveAdicionarEstudante()
        {

            _studentService.Save(_studentDTO);
            _studentRepositoryMock.Verify(r => r.Add(It.Is<Student>(s => s.Name == _studentDTO.Name)));
        }
        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var targetAudienceInvalid = "Médico";
            _studentDTO.TargetAudience = targetAudienceInvalid;
            FluentActions.Invoking(() => _studentService.Save(_studentDTO)).Should().Throw<DomainException>().Where(d => d.ErrorMessages.Contains(Resource.InvalidTargetAudience));
        }
        [Fact]
        public void NaoDeveAdicionarCursoComOMesmoNomeEIdDiferenteDoOutroSalvo()
        {
            var studentAlreadySaved = StudentBuilder.New().WithCPF(_studentDTO.CPF).WithId(60).Build();
            _studentRepositoryMock.Setup(r => r.GetByCPF(_studentDTO.CPF)).Returns(studentAlreadySaved);
            _studentDTO.Id = _faker.Random.Int(50, 100);
            FluentActions.Invoking(() => _studentService.Save(_studentDTO)).Should().Throw<DomainException>().Where(d => d.ErrorMessages.Contains(Resource.CPFAlreadyExists));

        }
    }
}
