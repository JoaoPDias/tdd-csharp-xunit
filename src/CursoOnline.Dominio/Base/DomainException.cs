using System;
using System.Collections.Generic;

namespace OnlineCourse.Domain.Base
{
    public class DomainException : ArgumentException
    {
        public List<string> ErrorMessages { get; set; }

        public DomainException(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
