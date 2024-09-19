using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P01_StudentSystem.Migrations
{
    /// <inheritdoc />
    public partial class intialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    RegestrionON = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    ResourceType = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorkSubmissions",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    SubmissionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorkSubmissions", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK_HomeWorkSubmissions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeWorkSubmissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "for .net developer", new DateOnly(2024, 12, 17), "c#", 5500.00m, new DateOnly(2024, 9, 17) },
                    { 2, "for java developer", new DateOnly(2024, 12, 18), "java", 6000.00m, new DateOnly(2024, 9, 18) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegestrionON" },
                values: new object[,]
                {
                    { 1, new DateOnly(1999, 9, 15), "ahmed", "0101404111", new DateOnly(2024, 9, 15) },
                    { 2, new DateOnly(1998, 9, 15), "mohamed", "0101404112", new DateOnly(2024, 9, 13) },
                    { 3, new DateOnly(1997, 9, 15), "mostafa", "0101404113", new DateOnly(2024, 9, 12) }
                });

            migrationBuilder.InsertData(
                table: "HomeWorkSubmissions",
                columns: new[] { "HomeWorkId", "Content", "ContentType", "CourseId", "Name", "StudentId", "SubmissionTime" },
                values: new object[,]
                {
                    { 1, "http://google.com/homework1", 1, 1, "homework s1 ", 1, new DateTime(2024, 9, 19, 5, 36, 43, 14, DateTimeKind.Local).AddTicks(7478) },
                    { 2, "http://google.com/homework2", 2, 2, "homework s2 ", 2, new DateTime(2024, 9, 19, 5, 36, 43, 14, DateTimeKind.Local).AddTicks(7536) },
                    { 3, "http://google.com/homework2", 2, 2, "homework s3 ", 3, new DateTime(2024, 9, 19, 5, 36, 43, 14, DateTimeKind.Local).AddTicks(7541) }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Math Video", 0, "http://google.com/math-video" },
                    { 2, 2, "Physics Presentation", 1, "http://google.com/physics-presentation" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkSubmissions_CourseId",
                table: "HomeWorkSubmissions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorkSubmissions_StudentId",
                table: "HomeWorkSubmissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CourseId",
                table: "Resources",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeWorkSubmissions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
