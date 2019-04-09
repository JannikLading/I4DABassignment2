using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackboardReplacement.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUIDs",
                columns: table => new
                {
                    AUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUIDs", x => x.AUId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    EnrolledDate = table.Column<DateTime>(nullable: false),
                    GraduationDate = table.Column<DateTime>(nullable: false),
                    AUId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AUId);
                    table.ForeignKey(
                        name: "FK_Students_AUIDs_AUId1",
                        column: x => x.AUId1,
                        principalTable: "AUIDs",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    AUId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.AUId);
                    table.ForeignKey(
                        name: "FK_Teachers_AUIDs_AUId1",
                        column: x => x.AUId1,
                        principalTable: "AUIDs",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lecture = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CoursesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_Calendars_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseContents",
                columns: table => new
                {
                    CourseContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Audio = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    TextBlock = table.Column<string>(nullable: true),
                    Folder = table.Column<string>(nullable: true),
                    courseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContents", x => x.CourseContentId);
                    table.ForeignKey(
                        name: "FK_CourseContents_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    AUID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_AUID",
                        column: x => x.AUID,
                        principalTable: "Students",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assigments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Attempt = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assigments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assigments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesTeachers",
                columns: table => new
                {
                    CoursesTeachersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AUId = table.Column<int>(nullable: false),
                    CoursesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesTeachers", x => x.CoursesTeachersId);
                    table.ForeignKey(
                        name: "FK_CoursesTeachers_Teachers_AUId",
                        column: x => x.AUId,
                        principalTable: "Teachers",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesTeachers_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    maxSize = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Assigments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assigments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    StudentGroupsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AUId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.StudentGroupsId);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Students_AUId",
                        column: x => x.AUId,
                        principalTable: "Students",
                        principalColumn: "AUId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AUIDs",
                column: "AUId",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "CourseContents",
                columns: new[] { "CourseContentId", "Audio", "Folder", "TextBlock", "Video", "courseID" },
                values: new object[,]
                {
                    { 1, "some audioclip", "Folder containing more Course Content", "Welcome to Dab", "some videoclip", 0 },
                    { 2, "some audioclip", "Folder containing more Course Content", "Welcome to Linear Algebra", "some videoclip", 0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Databaser" },
                    { 2, "Linear Algebra" }
                });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "StudentGroupsId", "AUId", "GroupId" },
                values: new object[] { 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "AUId", "AUId1", "Birthday", "EnrolledDate", "GraduationDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1996, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "N008S14Y3R" },
                    { 2, null, new DateTime(1969, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "xXAlekDreamer420Xx" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "AUId", "AUId1", "Birthday", "name" },
                values: new object[,]
                {
                    { 3, null, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnnyBoi" },
                    { 4, null, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lil' jan-z" }
                });

            migrationBuilder.InsertData(
                table: "Assigments",
                columns: new[] { "AssignmentId", "Attempt", "CourseId", "Grade", "TeacherId" },
                values: new object[] { 1, 1, 1, 12, 1 });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "CalendarId", "CoursesId", "Date", "Deadline", "Lecture" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EF Core FrameWork" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Database assignment 2" },
                    { 3, 2, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linjer og planer" }
                });

            migrationBuilder.InsertData(
                table: "CoursesTeachers",
                columns: new[] { "CoursesTeachersId", "AUId", "CoursesId" },
                values: new object[,]
                {
                    { -3, 3, 1 },
                    { -1, 4, 2 },
                    { -2, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "AUID", "CourseId", "Grade", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, true },
                    { 2, 1, 2, 12, false },
                    { 3, 2, 1, 0, true }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "AssignmentId", "maxSize" },
                values: new object[] { 22, 1, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Assigments_CourseId",
                table: "Assigments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigments_TeacherId",
                table: "Assigments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_CoursesId",
                table: "Calendars",
                column: "CoursesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_courseID",
                table: "CourseContents",
                column: "courseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursesTeachers_AUId",
                table: "CoursesTeachers",
                column: "AUId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesTeachers_CoursesId",
                table: "CoursesTeachers",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_AUID",
                table: "Enrollments",
                column: "AUID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AssignmentId",
                table: "Groups",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_AUId",
                table: "StudentGroups",
                column: "AUId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_GroupId",
                table: "StudentGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AUId1",
                table: "Students",
                column: "AUId1");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AUId1",
                table: "Teachers",
                column: "AUId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "CourseContents");

            migrationBuilder.DropTable(
                name: "CoursesTeachers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Assigments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AUIDs");
        }
    }
}
