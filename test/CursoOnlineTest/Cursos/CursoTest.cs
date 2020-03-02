using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest:IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly int _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest()
        {
            _nome = "Computação Gráfica";
            _cargaHoraria = 200;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950.0;
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor);
            curso.Should().BeEquivalentTo(cursoEsperado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CursoNaoDeveSerCriadoComNomeInválido(string nomeInvalido)
        {
            FluentActions.Invoking(() => new Curso(nomeInvalido,
                    _cargaHoraria,
                    _publicoAlvo,
                    _valor))
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("O nome não pode ser vazio ou nulo");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void CursoNaoDeveSerCriadoComCargaHorariaMenorQue1(int cargaHorariaInvalida)
        {

            FluentActions.Invoking(() => new Curso(_nome,
                    cargaHorariaInvalida,
                    _publicoAlvo,
                    _valor))
                .Should().Throw<ArgumentException>()
                .WithMessage("A carga horária não pode ser menor que 1");
        }

        [Theory]
        [InlineData(0.0)]
        [InlineData(-2.0)]
        [InlineData(-100.0)]
        public void CursoNaoDeveSerCriadoComValorMenorQue1(double valorInvalido)
        {

            FluentActions.Invoking(() => new Curso(_nome,
                    _cargaHoraria,
                    _publicoAlvo,
                    valorInvalido))
                .Should().Throw<ArgumentException>()
                .WithMessage("O valor não pode ser menor que 1");
        }

        
    }

}