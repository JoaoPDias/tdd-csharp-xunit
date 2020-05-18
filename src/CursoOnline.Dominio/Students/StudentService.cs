using CursoOnline.Dominio._Base;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OnlineCourse.Domain.Students
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService()
        {
        }

        public StudentService(IStudentRepository repository)
        {
            _studentRepository = repository;
        }

        public void Save(StudentDTO studentDTO)
        {
            var studentWithCPF = _studentRepository.GetByCPF(studentDTO.CPF);
            RuleValidator.New()
                .When(studentWithCPF != null && studentWithCPF.Id != studentDTO.Id, Resource.CPFAlreadyExists)
                .When(!Enum.TryParse(studentDTO.TargetAudience, out TargetAudience targetAudience), Resource.InvalidTargetAudience)
                .ThrowExceptionIfExists();
            if (studentDTO.Id == 0)
            {
                var student = new Student(studentDTO.Name, studentDTO.CPF, studentDTO.Email, targetAudience);
                _studentRepository.Add(student);
            }
            else
            {
                var student = _studentRepository.GetById(studentDTO.Id);
                student.UpdateName(studentDTO.Name);
                student.UpdateCPF(studentDTO.CPF);
                student.UpdateEmail(studentDTO.Email);
                student.UpdateTargetAudience(targetAudience);
            }
        }
        public StudentDTO GetById(int id)
        {
            return _studentRepository.GetById(id).ToStudentDTO(); ;
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var students = _studentRepository.GetAll();

            if (students.Any())
            {
                var studentsDTO = students.Select(s => s.ToStudentDTO());
                return studentsDTO;
            }
            return null;
        }
    }
}
