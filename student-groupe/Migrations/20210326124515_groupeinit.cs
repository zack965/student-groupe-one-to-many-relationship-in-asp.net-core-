using Microsoft.EntityFrameworkCore.Migrations;

namespace student_groupe.Migrations
{
    public partial class groupeinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Groupe_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Groupe_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Groupe_Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student_Filiere = table.Column<int>(type: "int", nullable: false),
                    Groupe_Id = table.Column<int>(type: "int", nullable: false),
                    Groupe_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_Students_Groupes_Groupe_Id1",
                        column: x => x.Groupe_Id1,
                        principalTable: "Groupes",
                        principalColumn: "Groupe_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groupe_Id1",
                table: "Students",
                column: "Groupe_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groupes");
        }
    }
}
