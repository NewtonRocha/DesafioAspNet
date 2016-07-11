using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtonProject.Migrations
{
    public partial class My5Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Perfils_PerfilId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfils",
                table: "Perfils");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfis",
                table: "Perfils",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Perfis_PerfilId",
                table: "Pessoas",
                column: "PerfilId",
                principalTable: "Perfils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Perfils",
                newName: "Perfis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Perfis_PerfilId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Perfis",
                table: "Perfis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perfils",
                table: "Perfis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Perfils_PerfilId",
                table: "Pessoas",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameTable(
                name: "Perfis",
                newName: "Perfils");
        }
    }
}
