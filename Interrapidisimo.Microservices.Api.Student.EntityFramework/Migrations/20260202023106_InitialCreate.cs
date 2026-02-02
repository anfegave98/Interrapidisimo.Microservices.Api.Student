using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Interrapidisimo.Microservices.Api.Student.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Created", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 2, 2, 31, 5, 300, DateTimeKind.Utc).AddTicks(17), "andres.galeano@gmail.com", "Andres", "Galeano" },
                    { 2, new DateTime(2026, 2, 2, 2, 31, 5, 300, DateTimeKind.Utc).AddTicks(21), "isabella@gmail.com", "Isabella", "Roche" },
                    { 3, new DateTime(2026, 2, 2, 2, 31, 5, 300, DateTimeKind.Utc).AddTicks(23), "andrea@gmail.com", "Andrea", "Velasco" },
                    { 4, new DateTime(2026, 2, 2, 2, 31, 5, 300, DateTimeKind.Utc).AddTicks(24), "felipe@gmail.com", "Felipe", "Velasco" },
                    { 5, new DateTime(2026, 2, 2, 2, 31, 5, 300, DateTimeKind.Utc).AddTicks(25), "danya@gmail.com", "Danya", "Sotelo" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Profesor Juan Perez" },
                    { 2, "Profesor Maria Gomez" },
                    { 3, "Profesor Carlos Ruiz" },
                    { 4, "Profesor Ana Torres" },
                    { 5, "Profesor. Luis Herrera" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Credits", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, 3, "Matematicas", 1 },
                    { 2, 3, "Fisica", 1 },
                    { 3, 3, "Quimica", 2 },
                    { 4, 3, "Biologia", 2 },
                    { 5, 3, "Historia", 3 },
                    { 6, 3, "Geografia", 3 },
                    { 7, 3, "Programacion", 4 },
                    { 8, 3, "Base de Datos", 4 },
                    { 9, 3, "Economia", 5 },
                    { 10, 3, "Estadistica", 5 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 1, 7 },
                    { 4, 2, 1 },
                    { 5, 2, 5 },
                    { 6, 2, 7 },
                    { 7, 3, 1 },
                    { 8, 3, 3 },
                    { 9, 4, 5 },
                    { 10, 4, 7 },
                    { 11, 5, 1 },
                    { 12, 5, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId_SubjectId",
                table: "Enrollments",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubjectId",
                table: "Enrollments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
