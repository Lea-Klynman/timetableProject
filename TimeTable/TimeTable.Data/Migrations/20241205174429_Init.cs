using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassNumber = table.Column<int>(type: "int", nullable: false),
                    TotalWeekHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "_Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "_Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalWeeklyHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectEntity",
                columns: table => new
                {
                    ClassSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    HoursPersWeek = table.Column<int>(type: "int", nullable: false),
                    ClassEntityClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectEntity", x => x.ClassSubjectId);
                    table.ForeignKey(
                        name: "FK_ClassSubjectEntity__Classes_ClassEntityClassId",
                        column: x => x.ClassEntityClassId,
                        principalTable: "_Classes",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "_Availabilities",
                columns: table => new
                {
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unavailablehours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWholeDayOff = table.Column<bool>(type: "bit", nullable: false),
                    isMust = table.Column<bool>(type: "bit", nullable: false),
                    TeacherEntityTeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Availabilities", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK__Availabilities__Teachers_TeacherEntityTeacherId",
                        column: x => x.TeacherEntityTeacherId,
                        principalTable: "_Teachers",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "TeacherClassSubjectEntity",
                columns: table => new
                {
                    TeacherClassSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    HoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    TeacherEntityTeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassSubjectEntity", x => x.TeacherClassSubjectId);
                    table.ForeignKey(
                        name: "FK_TeacherClassSubjectEntity__Teachers_TeacherEntityTeacherId",
                        column: x => x.TeacherEntityTeacherId,
                        principalTable: "_Teachers",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Availabilities_TeacherEntityTeacherId",
                table: "_Availabilities",
                column: "TeacherEntityTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectEntity_ClassEntityClassId",
                table: "ClassSubjectEntity",
                column: "ClassEntityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassSubjectEntity_TeacherEntityTeacherId",
                table: "TeacherClassSubjectEntity",
                column: "TeacherEntityTeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Availabilities");

            migrationBuilder.DropTable(
                name: "_Subjects");

            migrationBuilder.DropTable(
                name: "ClassSubjectEntity");

            migrationBuilder.DropTable(
                name: "TeacherClassSubjectEntity");

            migrationBuilder.DropTable(
                name: "_Classes");

            migrationBuilder.DropTable(
                name: "_Teachers");
        }
    }
}
