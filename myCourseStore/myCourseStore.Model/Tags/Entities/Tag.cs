using myCourseStore.Model.Courses.Entities;
using myCourseStore.Model.Framework;

namespace myCourseStore.Model.Tags.Entities;

public class Tag : BaseEntity
{
    public string TagName { get; set; }
    public List<CourseTag> CourseTags { get; set; }
}
