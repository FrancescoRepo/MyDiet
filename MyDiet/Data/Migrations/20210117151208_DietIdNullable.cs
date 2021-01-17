using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDiet.Data.Migrations
{
    public partial class DietIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diets_DietId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diets_DietId",
                table: "Patients",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Diets_DietId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Diets_DietId",
                table: "Patients",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
