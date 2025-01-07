using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTable.Data.Migrations
{
    public partial class foreignKeyNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_TeacherClassSubject_TeacherEntityTeacherId",
                table: "TeacherClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_ClassSubject_ClassEntityClassId",
                table: "ClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_Availability_TeacherEntityTeacherId",
                table: "Availability");

            migrationBuilder.DropColumn(
                name: "TeacherEntityTeacherId",
                table: "TeacherClassSubject");

            migrationBuilder.DropColumn(
                name: "ClassEntityClassId",
                table: "ClassSubject");

            migrationBuilder.DropColumn(
                name: "TeacherEntityTeacherId",
                table: "Availability");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassSubject_ClassId",
                table: "TeacherClassSubject",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassSubject_SubjectId",
                table: "TeacherClassSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassSubject_TeacherId",
                table: "TeacherClassSubject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_ClassId",
                table: "ClassSubject",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_SubjectId",
                table: "ClassSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_TeacherId",
                table: "Availability",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Teacher_TeacherId",
                table: "Availability",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubject_Class_ClassId",
                table: "ClassSubject",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSubject_Subject_SubjectId",
                table: "ClassSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassSubject_Class_ClassId",
                table: "TeacherClassSubject",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassSubject_Subject_SubjectId",
                table: "TeacherClassSubject",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassSubject_Teacher_TeacherId",
                table: "TeacherClassSubject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Teacher_TeacherId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubject_Class_ClassId",
                table: "ClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassSubject_Subject_SubjectId",
                table: "ClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassSubject_Class_ClassId",
                table: "TeacherClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassSubject_Subject_SubjectId",
                table: "TeacherClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassSubject_Teacher_TeacherId",
                table: "TeacherClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClassSubject_ClassId",
                table: "TeacherClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClassSubject_SubjectId",
                table: "TeacherClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClassSubject_TeacherId",
                table: "TeacherClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_ClassSubject_ClassId",
                table: "ClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_ClassSubject_SubjectId",
                table: "ClassSubject");

            migrationBuilder.DropIndex(
                name: "IX_Availability_TeacherId",
                table: "Availability");

            migrationBuilder.AddColumn<int>(
                name: "TeacherEntityTeacherId",
                table: "TeacherClassSubject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassEntityClassId",
                table: "ClassSubject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherEntityTeacherId",
                table: "Availability",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassSubject_TeacherEntityTeacherId",
                table: "TeacherClassSubject",
                column: "TeacherEntityTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubject_ClassEntityClassId",
                table: "ClassSubject",
                column: "ClassEntityClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Availability_TeacherEntityTeacherId",
                table: "Availability",
                column: "TeacherEntityTeacherId");

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
    }
}
