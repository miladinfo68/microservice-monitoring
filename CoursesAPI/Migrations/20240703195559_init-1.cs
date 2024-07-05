using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesAPI.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Duration = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
                    StartAtInPersian = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "FORMAT(getdate(),'yyyy-MM-dd HH:mm:ss','fa')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C# For Beginners" },
                    { 2, "Advanced C#" },
                    { 3, "Java For Beginners" },
                    { 4, "Advanced Java" },
                    { 5, "C++ For Beginners" },
                    { 6, "Advanced C++" },
                    { 7, "Sql For Beginners" },
                    { 8, "Sql in depth" },
                    { 9, "Data Science For Beginners" },
                    { 10, "C For All" },
                    { 11, "ML Beginners" },
                    { 12, "Pascal For Science" },
                    { 13, "Deep Learning For Beginners" },
                    { 14, "Data Structure For Beginners" },
                    { 15, "Algorithm For Beginners" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
