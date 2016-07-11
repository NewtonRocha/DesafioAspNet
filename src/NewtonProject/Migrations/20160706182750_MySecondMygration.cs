using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtonProject.Migrations
{
    public partial class MySecondMygration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Atividades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_PessoaId",
                table: "Atividades",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_Pessoas_PessoaId",
                table: "Atividades",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_Pessoas_PessoaId",
                table: "Atividades");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_PessoaId",
                table: "Atividades");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Atividades");
        }
    }
}
