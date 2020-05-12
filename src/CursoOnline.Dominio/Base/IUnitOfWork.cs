using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Domain.Base
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
