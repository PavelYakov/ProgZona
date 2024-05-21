using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    public partial class TextToStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_MainCourseEntity_MainCourseId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAchievement_User_UserId",
                table: "UserAchievement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCourseEntity",
                table: "MainCourseEntity");

            migrationBuilder.RenameTable(
                name: "MainCourseEntity",
                newName: "MainCourse");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Stage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           /* migrationBuilder.AddColumn<int>(
                name: "MainCourseId1",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);*/

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCourse",
                table: "MainCourse",
                column: "Id");

           /* migrationBuilder.CreateIndex(
                name: "IX_Course_MainCourseId1",
                table: "Course",
                column: "MainCourseId1");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Course_MainCourse_MainCourseId",
                table: "Course",
                column: "MainCourseId",
                principalTable: "MainCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            /*migrationBuilder.AddForeignKey(
                name: "FK_Course_MainCourse_MainCourseId1",
                table: "Course",
                column: "MainCourseId1",
                principalTable: "MainCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_MainCourse_MainCourseId",
                table: "Course");

            /*migrationBuilder.DropForeignKey(
                name: "FK_Course_MainCourse_MainCourseId1",
                table: "Course");*/

            /*migrationBuilder.DropIndex(
                name: "IX_Course_MainCourseId1",
                table: "Course");*/

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCourse",
                table: "MainCourse");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Stage");

            /*migrationBuilder.DropColumn(
                name: "MainCourseId1",
                table: "Course");*/

            migrationBuilder.RenameTable(
                name: "MainCourse",
                newName: "MainCourseEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCourseEntity",
                table: "MainCourseEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_MainCourseEntity_MainCourseId",
                table: "Course",
                column: "MainCourseId",
                principalTable: "MainCourseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAchievement_User_UserId",
                table: "UserAchievement",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
