using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourse.Domain.Base
{
    public abstract class Entity
    {
        public int Id { get;  protected set; }
    }
}
