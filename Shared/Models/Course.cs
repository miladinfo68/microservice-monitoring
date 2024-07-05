namespace Shared.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartAt { get; set; }
    public int Duration { get; set; } //days
    public DateTime StartAtInPersian { get; set; }
}