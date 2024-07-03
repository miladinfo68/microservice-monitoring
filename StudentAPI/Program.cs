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
    public DbSet<Student> Student { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(e =>
        {
            e.Property(p => p.FirstName).HasMaxLength(200);
            e.Property(p => p.LastName).HasMaxLength(200);
            e.Property(p => p.StdCode).HasMaxLength(10);
            e.Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
            e.HasData(SeedData.Students);
        });
    }
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

public static class RouteExtension
{
    public static IEndpointRouteBuilder AddRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/hc", () => "health check is ok");
        
        var studentMapGroup = routes.MapGroup("/api/v1/students").WithTags("StudentAPI");
        
        studentMapGroup.MapGet("/", async ([FromServices] AppDbContext db) => await db.Student.ToListAsync());
        
        studentMapGroup.MapGet("/{id:int}",
            async ([FromServices] AppDbContext db, int id) => await db.Student.FirstOrDefaultAsync(x => x.Id == id));
        
        studentMapGroup.MapPost("/",
            async ([FromServices] AppDbContext db, [FromBody] StudentAddDto dto, CancellationToken token = default) =>
            {
                var newStudent= new Student()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    StdCode = dto.StdCode
                };
                db.Student.Add(newStudent);
                await db.SaveChangesAsync(token);
                return newStudent;
            });

        studentMapGroup.MapPut("/{id:int}",
            async ([FromServices] AppDbContext db,int id , [FromBody] StudentEditDto dto, CancellationToken token = default) =>
            {
                var student = await db.Student.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
                if (student is null) return null;
                student.FirstName = dto.FirstName;
                student.LastName = dto.LastName;
                student.StdCode = dto.StdCode;
                await db.SaveChangesAsync(token);
                return student;
            });
        
        studentMapGroup.MapDelete("/{id:int}",
            async ([FromServices] AppDbContext db, int id, CancellationToken token = default) =>
            {
                var student = await db.Student.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
                if (student is null) return false;
                db.Student.Remove(student);
                return await db.SaveChangesAsync(token) > 0;
            });
        

        return routes;
    }
}