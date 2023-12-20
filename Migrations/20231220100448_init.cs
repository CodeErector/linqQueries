using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace linqQueries.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departs",
                columns: table => new
                {
                    depid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departs", x => x.depid);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    depid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.fid);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roomNo = table.Column<int>(type: "int", nullable: false),
                    fid = table.Column<int>(type: "int", nullable: false),
                    Facultyfid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Classes_Faculties_Facultyfid",
                        column: x => x.Facultyfid,
                        principalTable: "Faculties",
                        principalColumn: "fid");
                });

            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fid = table.Column<int>(type: "int", nullable: false),
                    sid = table.Column<int>(type: "int", nullable: false),
                    cid = table.Column<int>(type: "int", nullable: false),
                    facultyfid = table.Column<int>(type: "int", nullable: true),
                    clscid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.eid);
                    table.ForeignKey(
                        name: "FK_Enrolled_Classes_clscid",
                        column: x => x.clscid,
                        principalTable: "Classes",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK_Enrolled_Faculties_facultyfid",
                        column: x => x.facultyfid,
                        principalTable: "Faculties",
                        principalColumn: "fid");
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
                    age = table.Column<int>(type: "int", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    Enrolledeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stu", x => x.sid);
                    table.ForeignKey(
                        name: "FK_stu_Enrolled_Enrolledeid",
                        column: x => x.Enrolledeid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Facultyfid",
                table: "Classes",
                column: "Facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_clscid",
                table: "Enrolled",
                column: "clscid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_facultyfid",
                table: "Enrolled",
                column: "facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_stu_Enrolledeid",
                table: "stu",
                column: "Enrolledeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departs");

            migrationBuilder.DropTable(
                name: "stu");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
