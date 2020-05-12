using System;
using System.Collections.Generic;

namespace OnlineCourse.Domain.Base
{
    public interface IRepository<TEntidade>
    {
        TEntidade GetById(int id);
        List<TEntidade> GetAll();
        void Add(TEntidade entity);
    }
}
