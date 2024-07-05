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
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(e =>
        {
            e.Property(p => p.CreatedAt).HasDefaultValueSql("getdate()");
            e.HasData(SeedData.Enrollments);
        });
    }
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

public static class RouteExtension
{
    public static IEndpointRouteBuilder AddRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/hc", () => "health check is ok");

        var enrollmentMapGroup = routes.MapGroup("/api/v1/enrollments").WithTags("EnrollmentAPI");

        enrollmentMapGroup.MapPost("/",
            async ([FromServices] AppDbContext db, [FromBody] EnrollmentAddDto dto,
                CancellationToken token = default) =>
            {
                var newEnrollment = new Enrollment() { StudentId = dto.StudentId, CourseId = dto.CourseId };
                if (await db.Enrollments.AnyAsync(x =>
                            x.StudentId == dto.StudentId && x.CourseId == dto.CourseId, cancellationToken: token))
                {
                    return newEnrollment;
                }

                db.Enrollments.Add(newEnrollment);
                await db.SaveChangesAsync(token);
                return newEnrollment;
            });

        enrollmentMapGroup.MapPut("/{id:int}",
            async ([FromServices] AppDbContext db, int id, [FromBody] EnrollmentEditDto dto,
                CancellationToken token = default) =>
            {
                var enrollment = await db.Enrollments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);
                if (enrollment is null) return null;
                enrollment.StudentId = dto.StudentId;
                enrollment.CourseId = dto.CourseId;
                await db.SaveChangesAsync(token);
                return enrollment;
            });


        return routes;
    }
}