namespace StudentMgmt.Core.Entities;

public class Course : BaseEntity
{
    public string CourseCode { get; set; } = null!; 
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
}