using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Domain.Courses
{
    public class ListViewCourseDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }

    }
}
