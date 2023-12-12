using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linqQueries.Migrations
{
    /// <inheritdoc />
    public partial class linq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.eid);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roomNo = table.Column<int>(type: "int", nullable: false),
                    facultyfid = table.Column<int>(type: "int", nullable: true),
                    Enrolledeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Classes_Enrolled_Enrolledeid",
                        column: x => x.Enrolledeid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                });

            migrationBuilder.CreateTable(
                name: "stu",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classcid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stu", x => x.sid);
                    table.ForeignKey(
                        name: "FK_stu_Classes_Classcid",
                        column: x => x.Classcid,
                        principalTable: "Classes",
                        principalColumn: "cid");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledStudent",
                columns: table => new
                {
                    enrollseid = table.Column<int>(type: "int", nullable: false),
                    studentssid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledStudent", x => new { x.enrollseid, x.studentssid });
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_Enrolled_enrollseid",
                        column: x => x.enrollseid,
                        principalTable: "Enrolled",
                        principalColumn: "eid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_stu_studentssid",
                        column: x => x.studentssid,
                        principalTable: "stu",
                        principalColumn: "sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    depid = table.Column<int>(type: "int", nullable: false),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrolleid = table.Column<int>(type: "int", nullable: true),
                    Studentsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.fid);
                    table.ForeignKey(
                        name: "FK_Faculties_Enrolled_enrolleid",
                        column: x => x.enrolleid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                    table.ForeignKey(
                        name: "FK_Faculties_stu_Studentsid",
                        column: x => x.Studentsid,
                        principalTable: "stu",
                        principalColumn: "sid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Enrolledeid",
                table: "Classes",
                column: "Enrolledeid");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_facultyfid",
                table: "Classes",
                column: "facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_studentssid",
                table: "EnrolledStudent",
                column: "studentssid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_enrolleid",
                table: "Faculties",
                column: "enrolleid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Studentsid",
                table: "Faculties",
                column: "Studentsid");

            migrationBuilder.CreateIndex(
                name: "IX_stu_Classcid",
                table: "stu",
                column: "Classcid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Faculties_facultyfid",
                table: "Classes",
                column: "facultyfid",
                principalTable: "Faculties",
                principalColumn: "fid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Enrolled_Enrolledeid",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Enrolled_enrolleid",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Faculties_facultyfid",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "EnrolledStudent");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "stu");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
