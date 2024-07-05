using Shared.Models;

namespace Shared.Seeds;

public static class SeedData
{
    public static IEnumerable<Student> Students => new[]
    {
        new Student() { Id = 1, FirstName = "Mahdi", LastName = "Jalali", StdCode = "st-1000" },
        new Student() { Id = 2, FirstName = "Milad", LastName = "Jalali", StdCode = "st-1001" },
        new Student() { Id = 3, FirstName = "Kamran", LastName = "Jalalian", StdCode = "st-1002" },
        new Student() { Id = 4, FirstName = "John", LastName = "Doe", StdCode = "st-1003" },
        new Student() { Id = 5, FirstName = "Ahmad", LastName = "Rafei", StdCode = "st-1004" },
        new Student() { Id = 6, FirstName = "Zahra", LastName = "Kazemi", StdCode = "st-1005" },
        new Student() { Id = 7, FirstName = "Tara", LastName = "Abadi", StdCode = "st-1006" },
        new Student() { Id = 8, FirstName = "Sajedeh", LastName = "Alaverdi", StdCode = "st-1007" },
        new Student() { Id = 9, FirstName = "Fatemeh", LastName = "Shamaghdari", StdCode = "st-1008" },
        new Student() { Id = 10, FirstName = "Tamim", LastName = "Golnoush", StdCode = "st-1009" },
        new Student() { Id = 11, FirstName = "Behnoosh", LastName = "Bahiraei", StdCode = "st-1010" },
        new Student() { Id = 12, FirstName = "Farnoosh", LastName = "Kameli", StdCode = "st-1011" },
        new Student() { Id = 13, FirstName = "Payam", LastName = "Norouzi", StdCode = "st-1012" },
        new Student() { Id = 14, FirstName = "Iman", LastName = "Ghiasi", StdCode = "st-1013" },
        new Student() { Id = 15, FirstName = "Hadi", LastName = "ebrahimi", StdCode = "st-1014" },
        new Student() { Id = 16, FirstName = "Reza", LastName = "azimi", StdCode = "st-1015" },
        new Student() { Id = 17, FirstName = "Akbar", LastName = "Ghaneh", StdCode = "st-1016" },
        new Student() { Id = 18, FirstName = "Saeid", LastName = "Piriaei", StdCode = "st-1017" },
        new Student() { Id = 19, FirstName = "Delaram", LastName = "Hemati", StdCode = "st-1018" },
        new Student() { Id = 20, FirstName = "Farzaneh", LastName = "Teimouri", StdCode = "st-1019" },
    };

    public static IEnumerable<Course> Courses => new[]
    {
        new Course() { Id = 1, Name = "C# For Beginners" },
        new Course() { Id = 2, Name = "Advanced C#" },
        new Course() { Id = 3, Name = "Java For Beginners" },
        new Course() { Id = 4, Name = "Advanced Java" },
        new Course() { Id = 5, Name = "C++ For Beginners" },
        new Course() { Id = 6, Name = "Advanced C++" },
        new Course() { Id = 7, Name = "Sql For Beginners" },
        new Course() { Id = 8, Name = "Sql in depth" },
        new Course() { Id = 9, Name = "Data Science For Beginners" },
        new Course() { Id = 10, Name = "C For All" },
        new Course() { Id = 11, Name = "ML Beginners" },
        new Course() { Id = 12, Name = "Pascal For Science" },
        new Course() { Id = 13, Name = "Deep Learning For Beginners" },
        new Course() { Id = 14, Name = "Data Structure For Beginners" },
        new Course() { Id = 15, Name = "Algorithm For Beginners" },
    };

    public static IEnumerable<Enrollment> Enrollments => new[]
    {
        new Enrollment() { Id = 1, StudentId = 1010101, CourseId = 10101 }
    };
}