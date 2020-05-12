namespace CursoOnline.Dominio._Base
{
    public static class Resource
    {
        public static string InvalidName = "The name cannot be empty or null";
        public static string EmailInvalido = "Email inválido";
        public static string InvalidWorkload = "The workload cannot be less than 1";
        public static string InvalidCourseFee = "The courseFee cannot be less than 1";
        public static string CourseNameAlreadyExists = "Another course has the same name";
        public static string InvalidTargetAudience = "Target Audience is Invalid";
        public static string CpfInvalido = "CPF inválido";
        public static string CpfJaCadastrado = "CPF já cadastrado";
        public static string AlunoInvalido = "Aluno inválido";
        public static string CursoInvalido = "Curso inválido";
        public static string ValorPagoMaiorQueValorDoCurso =
            "Valor pago na matricula não pode ser maior que valor do curso";

        public static string PublicosAlvoDiferentes = "Publico alvo do aluno e curso são diferentes";
        public static string CursoNaoEncontrado = "Curso não encontrado";
        public static string AlunoNaoEncontrado = "Aluno não encontrado";
        public static string NotaDoAlunoInvalida = "Nota do aluno invalida";
        public static string MatriculaNaoEncontrada = "Matricula não encontrada";
        public static string MatriculaCancelada = "Ação não permitida por matricula está cancelada";
        public static string MatriculaConcluida = "Ação não permitida por matricula está conclída";
    }
}
