using OnlineCourse.Data.Contexts;
using OnlineCourse.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineCourse.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }
        public Course GetByName(string name)
        {
            var entity = Context.Set<Course>().Where(c => c.Name.Contains(name));
            return entity.FirstOrDefault();
        }
    }
}
