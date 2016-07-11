using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtonProject.Migrations
{
    public partial class My4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ClienteId",
                table: "Pessoas",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Clientes_ClienteId",
                table: "Pessoas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Clientes_ClienteId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_ClienteId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pessoas");
        }
    }
}
