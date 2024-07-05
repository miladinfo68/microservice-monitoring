namespace Shared.Models;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId{get; set; }
    public int CourseId{get; set; }
    public DateTime CreatedAt { get; set; }
}