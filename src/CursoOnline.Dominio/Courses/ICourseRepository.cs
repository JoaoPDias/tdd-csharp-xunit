using OnlineCourse.Domain.Base;

namespace OnlineCourse.Domain.Courses
{

    public interface ICourseRepository:IRepository<Course>
    {
        Course GetByName(string name);
    }
}

