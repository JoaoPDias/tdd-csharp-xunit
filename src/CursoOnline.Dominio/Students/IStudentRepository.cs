using OnlineCourse.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Domain.Students
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByCPF(string cpf);
        Student GetByEmail(string email);
    }
}
