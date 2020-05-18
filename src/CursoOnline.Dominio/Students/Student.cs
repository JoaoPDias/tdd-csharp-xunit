using Caelum.Stella.CSharp.Validation;
using CursoOnline.Dominio._Base;
using Newtonsoft.Json.Serialization;
using OnlineCourse.Domain.Base;
using OnlineCourse.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OnlineCourse.Domain.Students
{
    public class Student : Entity
    {
        public Student(string name, string cpf, string email, TargetAudience targetAudience)
        {
            var CPFValidator = new CPFValidator();
            RuleValidator
               .New()
               .When(string.IsNullOrEmpty(name), Resource.InvalidName)
               .When(string.IsNullOrEmpty(cpf) || !CPFValidator.IsValid(cpf), Resource.InvalidCPF)
               .When(string.IsNullOrEmpty(email) || !RegexUtilities.IsValidEmail(email), Resource.InvalidEmail)
               .ThrowExceptionIfExists();
            Name = name;
            CPF = cpf;
            Email = email;
            TargetAudience = targetAudience;
        }
        public Student()
        {

        }
        public string Name { get; set; }
        public string CPF { get; set; }
        public TargetAudience TargetAudience { get; set; }
        public string Email { get; set; }
        public Student UpdateName(string name)
        {
            RuleValidator
              .New()
              .When(string.IsNullOrEmpty(name), Resource.InvalidName)
              .ThrowExceptionIfExists();
            Name = name;
            return this;
        }
        public Student UpdateCPF(string cpf)
        {
            var CPFValidator = new CPFValidator();
            RuleValidator
               .New()
               .When(string.IsNullOrEmpty(cpf) || !CPFValidator.IsValid(cpf), Resource.InvalidCPF)
               .ThrowExceptionIfExists();
            CPF = cpf;
            return this;
        }

        internal StudentDTO ToStudentDTO()
        {
            return new StudentDTO
            {
                Id = this.Id,
                Name = this.Name,
                TargetAudience = this.TargetAudience.ToString(),
                CPF = this.CPF,
                Email = this.Email
            };
        }

        public Student UpdateEmail(string email)
        {
            RuleValidator
             .New()
             .When(string.IsNullOrEmpty(email) || !RegexUtilities.IsValidEmail(email), Resource.InvalidEmail)
             .ThrowExceptionIfExists();
            Email = email;
            return this;
        }
        public Student UpdateTargetAudience(TargetAudience targetAudience)
        {
            TargetAudience = targetAudience;
            return this;
        }

    }
}
