using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    public partial class UserCourseStageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LevelDifficult",
                table: "Course",
                newName: "PurchaseCount");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseCount",
                table: "Stage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainCourseId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MainCourseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultLevel = table.Column<int>(type: "int", nullable: false),
                    PurchaseCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCourseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => new { x.UserId, x.CourseId });
                });

            migrationBuilder.CreateTable(
                name: "UserMainCourse",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MainCourseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMainCourse", x => new { x.UserId, x.MainCourseId });
                });

            migrationBuilder.CreateTable(
                name: "UserStage",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStage", x => new { x.UserId, x.StageId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_MainCourseId",
                table: "Course",
                column: "MainCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_MainCourseEntity_MainCourseId",
                table: "Course",
                column: "MainCourseId",
                principalTable: "MainCourseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_MainCourseEntity_MainCourseId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "MainCourseEntity");

            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropTable(
                name: "UserMainCourse");

            migrationBuilder.DropTable(
                name: "UserStage");

            migrationBuilder.DropIndex(
                name: "IX_Course_MainCourseId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "PurchaseCount",
                table: "Stage");

            migrationBuilder.DropColumn(
                name: "MainCourseId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "PurchaseCount",
                table: "Course",
                newName: "LevelDifficult");
        }
    }
}
