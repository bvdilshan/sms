namespace StudentMgmt.Core.Entities;

public class Student : BaseEntity
{
    //  { get; set; } 
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    
}