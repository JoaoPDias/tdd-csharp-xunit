using Bogus;
using Bogus.Extensions.Brazil;
using OnlineCourse.Domain.Courses;
using OnlineCourse.Domain.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.DomainTest._Builders
{
    public class StudentBuilder
    {
        private string _name;
        private Faker _studentFaker;
        private string _cpf;
        private int _id;
        private TargetAudience _targetAudience;
        private string _email;

        public static StudentBuilder New()
        {
            return new StudentBuilder();

        }
        public StudentBuilder()
        {
            _studentFaker = new Faker("pt_BR");
            _cpf = _studentFaker.Person.Cpf();
            _email = _studentFaker.Person.Email;
            _name = _studentFaker.Person.FullName;
            _targetAudience = _studentFaker.PickRandom<TargetAudience>();          
        }
        public StudentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public StudentBuilder WithCPF(string cpf)
        {
            _cpf = cpf;
            return this;
        }
        public StudentBuilder WithTargetAudience(TargetAudience targetAudience)
        {
            _targetAudience = targetAudience;
            return this;
        }
        public StudentBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }
        public StudentBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
        public Student Build()
        {
            var student = new Student(_name,_cpf,_email,_targetAudience);
            if (_id > 0)
            {
                var propertyInfo = student.GetType().GetProperty("Id");
                propertyInfo.SetValue(student, Convert.ChangeType(_id, propertyInfo.PropertyType), null);
            }
            return student;
        }
    }

}

