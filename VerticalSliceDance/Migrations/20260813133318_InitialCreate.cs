using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VerticalSliceDance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanceStudios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_DanceStudios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "DanceStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanceClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Schedule_Day = table.Column<int>(type: "int", nullable: false),
                    Schedule_StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Schedule_EndTime = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanceClasses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DanceStudios",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Bulevar Oslobođenja 12", "Rhythm Studio" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Narodnog Fronta 45", "Salsa Nation" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), "Zmaj Jovina 8", "Urban Dance Hub" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FirstName", "LastName", "StudioId" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222221"), "Ana", "Jovanović", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Marko", "Petrović", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("22222222-2222-2222-2222-222222222223"), "Jovana", "Nikolić", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222224"), "Stefan", "Ilić", new Guid("11111111-1111-1111-1111-111111111112") },
                    { new Guid("22222222-2222-2222-2222-222222222225"), "Milica", "Radovanović", new Guid("11111111-1111-1111-1111-111111111113") }
                });

            migrationBuilder.InsertData(
                table: "DanceClasses",
                columns: new[] { "Id", "Schedule_Day", "Schedule_EndTime", "Schedule_StartTime", "InstructorId", "Title" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444441"), 1, new TimeOnly(19, 30, 0), new TimeOnly(18, 0, 0), new Guid("22222222-2222-2222-2222-222222222221"), "Salsa Beginners" },
                    { new Guid("44444444-4444-4444-4444-444444444442"), 3, new TimeOnly(21, 0, 0), new TimeOnly(19, 30, 0), new Guid("22222222-2222-2222-2222-222222222221"), "Salsa Advanced" },
                    { new Guid("44444444-4444-4444-4444-444444444443"), 2, new TimeOnly(18, 30, 0), new TimeOnly(17, 0, 0), new Guid("22222222-2222-2222-2222-222222222222"), "Hip Hop Intermediate" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 4, new TimeOnly(21, 30, 0), new TimeOnly(20, 0, 0), new Guid("22222222-2222-2222-2222-222222222223"), "Bachata Beginners" },
                    { new Guid("44444444-4444-4444-4444-444444444445"), 5, new TimeOnly(20, 0, 0), new TimeOnly(18, 30, 0), new Guid("22222222-2222-2222-2222-222222222224"), "Kizomba Beginners" },
                    { new Guid("44444444-4444-4444-4444-444444444446"), 6, new TimeOnly(11, 30, 0), new TimeOnly(10, 0, 0), new Guid("22222222-2222-2222-2222-222222222225"), "Breakdance Kids" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanceClasses_InstructorId",
                table: "DanceClasses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_DanceStudios_Name",
                table: "DanceStudios",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_StudioId",
                table: "Instructors",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanceClasses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "DanceStudios");
        }
    }
}
