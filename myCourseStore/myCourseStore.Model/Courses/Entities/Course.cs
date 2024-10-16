

using myCourseStore.Model.Framework;

namespace myCourseStore.Model.Courses.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public List<CourseTag> CourseTags { get; set; }
    public List<CourseTeacher> CourseTeachers { get; set; }
    public List<CourseComment> CourseComments { get; set; }

}
