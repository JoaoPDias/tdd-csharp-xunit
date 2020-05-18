namespace CursoOnline.Dominio._Base
{
    public static class Resource
    {
        public static string InvalidName = "The name cannot be empty or null";
        public static string InvalidEmail = "Invalid Email";
        public static string InvalidWorkload = "The workload cannot be less than 1";
        public static string InvalidCourseFee = "The courseFee cannot be less than 1";
        public static string CourseNameAlreadyExists = "Another course has the same name";
        public static string InvalidTargetAudience = "Target Audience is Invalid";
        public static string InvalidCPF = "Invalid CPF";
        public static string CPFAlreadyExists = "Another student has the same CPF";
        public static string InvalidStudent = "Invalid Student Name";
        public static string InvalidCourse = "Curso inválido";
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
