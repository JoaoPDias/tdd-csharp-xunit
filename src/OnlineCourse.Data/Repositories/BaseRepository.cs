using OnlineCourse.Data.Contexts;
using OnlineCourse.Domain.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OnlineCourse.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            var entidades = Context.Set<TEntity>().ToList();
            return entidades.Any() ? entidades : new List<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            var query = Context.Set<TEntity>().Where(entity => entity.Id == id);
            return query.Any() ? query.First() : null;
        }
    }
}