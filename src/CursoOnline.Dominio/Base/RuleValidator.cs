using System.Collections.Generic;
using System.Linq;

namespace OnlineCourse.Domain.Base
{
    public class RuleValidator
    {
        private readonly List<string> ErrorsMessages;

        private RuleValidator()
        {
            ErrorsMessages = new List<string>();
        }

        public static RuleValidator New()
        {
            return new RuleValidator();
        }

        public RuleValidator When(bool hasError, string errorMessage)
        {
            if (hasError)
                ErrorsMessages.Add(errorMessage);

            return this;
        }

        public void ThrowExceptionIfExists()
        {
            if (ErrorsMessages.Any())
                throw new DomainException(ErrorsMessages);
        }
    }
}
