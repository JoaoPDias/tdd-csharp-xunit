using OnlineCourse.Data.Contexts;
using OnlineCourse.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourse.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Student GetByCPF(string cpf)
        {
            var entity = Context.Set<Student>().Where(s => s.CPF.Equals(cpf));
            return entity.FirstOrDefault();
        }

        public Student GetByEmail(string email)
        {
            var entity = Context.Set<Student>().Where(s => s.Email.Equals(email));
            return entity.FirstOrDefault();
        }
    }
}
