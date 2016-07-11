using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewtonProject.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cargos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_ClienteId",
                table: "Cargos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Clientes_ClienteId",
                table: "Cargos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Clientes_ClienteId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_ClienteId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cargos");
        }
    }
}
