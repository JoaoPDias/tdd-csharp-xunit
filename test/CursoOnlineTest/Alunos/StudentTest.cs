using Bogus;
using Bogus.Extensions.Brazil;
using CursoOnline.Dominio._Base;
using FluentAssertions;
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
    public class StudentTest : IDisposable
    {
        private readonly Faker<Student> _studentFaker;
        private readonly Student _studentFake;
        private readonly Faker _faker;

        public StudentTest()
        {
            _studentFaker = new Faker<Student>("pt_BR")
                .RuleFor(s => s.CPF, f => f.Person.Cpf())
                .RuleFor(s => s.Email, f => f.Person.Email)
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.TargetAudience, f => f.PickRandom<TargetAudience>());
            _studentFake = _studentFaker.Generate();
            _faker = new Faker();
        }
        public void Dispose()
        {
        }

        [Fact]
        public void DeveCriarEstudante()
        {
            var student = new Student(_studentFake.Name, _studentFake.CPF, _studentFake.Email, _studentFake.TargetAudience);
            student.Should().BeEquivalentTo(_studentFake);
        }

        [Theory]
        [InlineData("0000000000000")]
        [InlineData("0000000000")]
        [InlineData("11111111111")]
        [InlineData("16148567708")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarEstudanteComCPFInvalido(string InvalidCPF)
        {
            FluentActions.Invoking(() => StudentBuilder.New().WithCPF(InvalidCPF).Build())
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidCPF));
        }

        [Fact]
        public void DeveAlterarPublicoAlvoDoEstudante()
        {
            var valorEsperado = _faker.PickRandom<TargetAudience>();
            var student = StudentBuilder.New().Build();
            student.UpdateTargetAudience(valorEsperado);
            student.TargetAudience.Should().Be(valorEsperado);
        }

        [Fact]
        public void DeveAlterarCPFDoEstudante()
        {
            var valorEsperado = _faker.Person.Cpf();
            var student = StudentBuilder.New().Build();
            student.UpdateCPF(valorEsperado);
            student.CPF.Should().Be(valorEsperado);
        }

        [Fact]
        public void DeveAlterarNomeDoEstudante()
        {
            var valorEsperado = _faker.Person.FullName;
            var student = StudentBuilder.New().Build();
            student.UpdateName(valorEsperado);
            student.Name.Should().Be(valorEsperado);
        }
        [Fact]
        public void DeveAlterarEmailDoEstudante()
        {
            var valorEsperado = _faker.Person.Email;
            var student = StudentBuilder.New().Build();
            student.UpdateEmail(valorEsperado);
            student.Email.Should().Be(valorEsperado);
        }

        [Theory]
        [InlineData("j..@retento")]
        [InlineData("email invalido")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarEstudanteComEmailInvalido(string InvalidEmail)
        {
            FluentActions.Invoking(() => StudentBuilder.New().WithEmail(InvalidEmail).Build())
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidEmail));
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarEstudanteComNomeInvalido(string InvalidName)
        {
            FluentActions.Invoking(() => StudentBuilder.New().WithName(InvalidName).Build())
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidName));
        }

        [Theory]
        [InlineData("0000000000000")]
        [InlineData("0000000000")]
        [InlineData("11111111111")]
        [InlineData("16148567708")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarEstudanteComCPFInvalido(string InvalidCPF)
        {
            var student = StudentBuilder.New().Build();
            FluentActions.Invoking(() => student.UpdateCPF(InvalidCPF))
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidCPF));
        }

        [Theory]
        [InlineData("j..@retento")]
        [InlineData("email invalido")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarEstudanteComEmailInvalido(string InvalidEmail)
        {
            var student = StudentBuilder.New().Build();
            FluentActions.Invoking(() => student.UpdateEmail(InvalidEmail))
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidEmail));
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarEstudanteComNomeInvalido(string InvalidName)
        {
            var student = StudentBuilder.New().Build();
            FluentActions.Invoking(() => student.UpdateName(InvalidName))
               .Should()
               .Throw<DomainException>()
               .Where(d => d.ErrorMessages.Contains(Resource.InvalidName));
        }


    }
}
