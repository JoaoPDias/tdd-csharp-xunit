using OnlineCourse.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data.Contexts
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
           await _context.SaveChangesAsync();
        }
    }
}
