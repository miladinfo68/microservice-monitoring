using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StdCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "FirstName", "LastName", "StdCode" },
                values: new object[,]
                {
                    { 1, "Mahdi", "Jalali", "st-1000" },
                    { 2, "Milad", "Jalali", "st-1001" },
                    { 3, "Kamran", "Jalalian", "st-1002" },
                    { 4, "John", "Doe", "st-1003" },
                    { 5, "Ahmad", "Rafei", "st-1004" },
                    { 6, "Zahra", "Kazemi", "st-1005" },
                    { 7, "Tara", "Abadi", "st-1006" },
                    { 8, "Sajedeh", "Alaverdi", "st-1007" },
                    { 9, "Fatemeh", "Shamaghdari", "st-1008" },
                    { 10, "Tamim", "Golnoush", "st-1009" },
                    { 11, "Behnoosh", "Bahiraei", "st-1010" },
                    { 12, "Farnoosh", "Kameli", "st-1011" },
                    { 13, "Payam", "Norouzi", "st-1012" },
                    { 14, "Iman", "Ghiasi", "st-1013" },
                    { 15, "Hadi", "ebrahimi", "st-1014" },
                    { 16, "Reza", "azimi", "st-1015" },
                    { 17, "Akbar", "Ghaneh", "st-1016" },
                    { 18, "Saeid", "Piriaei", "st-1017" },
                    { 19, "Delaram", "Hemati", "st-1018" },
                    { 20, "Farzaneh", "Teimouri", "st-1019" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
