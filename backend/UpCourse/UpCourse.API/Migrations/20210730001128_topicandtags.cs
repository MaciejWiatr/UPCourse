using Microsoft.EntityFrameworkCore.Migrations;

namespace UpCourse.Migrations
{
    public partial class topicandtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCourseTag_CourseTag_TagsId",
                table: "CourseCourseTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTopic_TopicId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTopic",
                table: "CourseTopic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTag",
                table: "CourseTag");

            migrationBuilder.RenameTable(
                name: "CourseTopic",
                newName: "CourseTopics");

            migrationBuilder.RenameTable(
                name: "CourseTag",
                newName: "CourseTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTopics",
                table: "CourseTopics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTags",
                table: "CourseTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCourseTag_CourseTags_TagsId",
                table: "CourseCourseTag",
                column: "TagsId",
                principalTable: "CourseTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTopics_TopicId",
                table: "Courses",
                column: "TopicId",
                principalTable: "CourseTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCourseTag_CourseTags_TagsId",
                table: "CourseCourseTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTopics_TopicId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTopics",
                table: "CourseTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTags",
                table: "CourseTags");

            migrationBuilder.RenameTable(
                name: "CourseTopics",
                newName: "CourseTopic");

            migrationBuilder.RenameTable(
                name: "CourseTags",
                newName: "CourseTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTopic",
                table: "CourseTopic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTag",
                table: "CourseTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCourseTag_CourseTag_TagsId",
                table: "CourseCourseTag",
                column: "TagsId",
                principalTable: "CourseTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTopic_TopicId",
                table: "Courses",
                column: "TopicId",
                principalTable: "CourseTopic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
