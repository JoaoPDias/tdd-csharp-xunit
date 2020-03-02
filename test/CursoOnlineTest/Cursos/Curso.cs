using System;
using System.Dynamic;

namespace CursoOnline.DominioTest.Cursos
{
    public class Curso
    {

        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (String.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome não pode ser vazio ou nulo");
            if(cargaHoraria<1)
                throw new ArgumentException("A carga horária não pode ser menor que 1");
            if(valor< 1)
                throw new ArgumentException("O valor não pode ser menor que 1");
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public int? CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}