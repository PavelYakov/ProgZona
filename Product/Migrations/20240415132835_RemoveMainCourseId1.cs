using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    public partial class RemoveMainCourseId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.AddColumn<int>(
              name: "MainCourseId1",
              table: "Course",
              type: "int",
              nullable: false,
              defaultValue: 0);
             
            migrationBuilder.CreateIndex(
               name: "IX_Course_MainCourseId1",
               table: "Course",
               column: "MainCourseId1");
            
            migrationBuilder.AddForeignKey(
                name: "FK_Course_MainCourse_MainCourseId1",
                table: "Course",
                column: "MainCourseId1",
                principalTable: "MainCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
            
           /* migrationBuilder.DropForeignKey(
                name: "FK_Course_MainCourse_MainCourseId1",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_MainCourseId1",
                table: "Course");*/
            
            migrationBuilder.DropColumn(
                name: "MainCourseId1",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
