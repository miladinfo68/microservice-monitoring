using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Models;
using Shared.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.AddRoutes();

app.Run();

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Course> Course { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(e =>
        {
            e.Property(p => p.Name).HasMaxLength(200);
            e.Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
            e.Property(p => p.PersianCreatedAt).HasDefaultValueSql("FORMAT(getdate(),'yyyy-MM-dd HH:mm:ss','fa')");
            e.HasData(SeedData.Courses);
        });
    }
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

public static class RouteExtension
{
    public static IEndpointRouteBuilder AddRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/hc", () => "health check is ok");
        
        var courseMapGroup = routes.MapGroup("/api/v1/courses").WithTags("CoursesAPI");
        
        courseMapGroup.MapGet("/", async ([FromServices] AppDbContext db) => await db.Course.ToListAsync());
        
        courseMapGroup.MapGet("/{id:int}",
            async ([FromServices] AppDbContext db, int id) => await db.Course.FirstOrDefaultAsync(x => x.Id == id));
        
        courseMapGroup.MapPost("/",
            async ([FromServices] AppDbContext db, [FromBody] CoursAddDto dto, CancellationToken token = default) =>
            {
                var newCourse = new Course() { Name = dto.Name };
                db.Course.Add(newCourse);
                await db.SaveChangesAsync(token);
                return newCourse;
            });

        courseMapGroup.MapPut("/{id:int}",
            async ([FromServices] AppDbContext db,int id , [FromBody] CoursEditDto dto, CancellationToken token = default) =>
            {
                var course = await db.Course.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
                if (course is null) return null;
                course.Name = dto.Name;
                await db.SaveChangesAsync(token);
                return course;
            });
        
        courseMapGroup.MapDelete("/{id:int}",
            async ([FromServices] AppDbContext db, int id, CancellationToken token = default) =>
            {
                var course = await db.Course.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
                if (course is null) return false;
                db.Course.Remove(course);
                return await db.SaveChangesAsync(token) > 0;
            });

        /*
        var bookMapGroup = routes.MapGroup("/api/v1/books").WithTags("BooksAPI");
        bookMapGroup.MapGet("/", () => "health check is ok");
        bookMapGroup.MapGet("/{id:int}", (int id) => $"enter id is {id}");
        */

        return routes;
    }
}