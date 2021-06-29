using Microsoft.EntityFrameworkCore.Migrations;

namespace student_groupe.Migrations
{
    public partial class stdfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groupes_Groupe_Id1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groupe_Id1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Groupe_Id1",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "Groupe_Id",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groupe_Id",
                table: "Students",
                column: "Groupe_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groupes_Groupe_Id",
                table: "Students",
                column: "Groupe_Id",
                principalTable: "Groupes",
                principalColumn: "Groupe_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groupes_Groupe_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Groupe_Id",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "Groupe_Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Groupe_Id1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Groupe_Id1",
                table: "Students",
                column: "Groupe_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groupes_Groupe_Id1",
                table: "Students",
                column: "Groupe_Id1",
                principalTable: "Groupes",
                principalColumn: "Groupe_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
