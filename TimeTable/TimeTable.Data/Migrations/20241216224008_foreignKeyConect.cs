using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Data.Migrations
{
    public partial class foreignKeyConect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Availabilities__Teachers_TeacherEntityTeacherId",
                table: "_Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubjectEntity__Classes_ClassEntityClassId",
                table: "ClassSubjectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassSubjectEntity__Teachers_TeacherEntityTeacherId",
                table: "TeacherClassSubjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClassSubjectEntity",
                table: "TeacherClassSubjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubjectEntity",
                table: "ClassSubjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Teachers",
                table: "_Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Subjects",
                table: "_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Classes",
                table: "_Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Availabilities",
                table: "_Availabilities");

            migrationBuilder.RenameTable(
                name: "TeacherClassSubjectEntity",
                newName: "TeacherClassSubject");

            migrationBuilder.RenameTable(
                name: "ClassSubjectEntity",
                newName: "ClassSubject");

            migrationBuilder.RenameTable(
                name: "_Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "_Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "_Classes",
                newName: "Class");

            migrationBuilder.RenameTable(
                name: "_Availabilities",
                newName: "Availability");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassSubjectEntity_TeacherEntityTeacherId",
                table: "TeacherClassSubject",
                newName: "IX_TeacherClassSubject_TeacherEntityTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubjectEntity_ClassEntityClassId",
                table: "ClassSubject",
                newName: "IX_ClassSubject_ClassEntityClassId");

            migrationBuilder.RenameIndex(
                name: "IX__Availabilities_TeacherEntityTeacherId",
                table: "Availability",
                newName: "IX_Availability_TeacherEntityTeacherId");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClassSubject",
                table: "TeacherClassSubject",
                column: "TeacherClassSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubject",
                table: "ClassSubject",
                column: "ClassSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availability",
                table: "Availability",
                column: "AvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Teacher_TeacherEntityTeacherId",
                table: "Availability",
                column: "TeacherEntityTeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubject_Class_ClassEntityClassId",
                table: "ClassSubject",
                column: "ClassEntityClassId",
                principalTable: "Class",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassSubject_Teacher_TeacherEntityTeacherId",
                table: "TeacherClassSubject",
                column: "TeacherEntityTeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Teacher_TeacherEntityTeacherId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubject_Class_ClassEntityClassId",
                table: "ClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassSubject_Teacher_TeacherEntityTeacherId",
                table: "TeacherClassSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClassSubject",
                table: "TeacherClassSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSubject",
                table: "ClassSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Availability",
                table: "Availability");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Availability");

            migrationBuilder.RenameTable(
                name: "TeacherClassSubject",
                newName: "TeacherClassSubjectEntity");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "_Teachers");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "_Subjects");

            migrationBuilder.RenameTable(
                name: "ClassSubject",
                newName: "ClassSubjectEntity");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "_Classes");

            migrationBuilder.RenameTable(
                name: "Availability",
                newName: "_Availabilities");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassSubject_TeacherEntityTeacherId",
                table: "TeacherClassSubjectEntity",
                newName: "IX_TeacherClassSubjectEntity_TeacherEntityTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSubject_ClassEntityClassId",
                table: "ClassSubjectEntity",
                newName: "IX_ClassSubjectEntity_ClassEntityClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Availability_TeacherEntityTeacherId",
                table: "_Availabilities",
                newName: "IX__Availabilities_TeacherEntityTeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClassSubjectEntity",
                table: "TeacherClassSubjectEntity",
                column: "TeacherClassSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Teachers",
                table: "_Teachers",
                column: "TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Subjects",
                table: "_Subjects",
                column: "SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSubjectEntity",
                table: "ClassSubjectEntity",
                column: "ClassSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Classes",
                table: "_Classes",
                column: "ClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Availabilities",
                table: "_Availabilities",
                column: "AvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK__Availabilities__Teachers_TeacherEntityTeacherId",
                table: "_Availabilities",
                column: "TeacherEntityTeacherId",
                principalTable: "_Teachers",
                principalColumn: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubjectEntity__Classes_ClassEntityClassId",
                table: "ClassSubjectEntity",
                column: "ClassEntityClassId",
                principalTable: "_Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassSubjectEntity__Teachers_TeacherEntityTeacherId",
                table: "TeacherClassSubjectEntity",
                column: "TeacherEntityTeacherId",
                principalTable: "_Teachers",
                principalColumn: "TeacherId");
        }
    }
}
