using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class hotfixv13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccineHistories_Accounts_AdministeredBy",
                table: "VaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_VaccineHistories_AdministeredBy",
                table: "VaccineHistories");

            migrationBuilder.AlterColumn<string>(
                name: "AdministeredBy",
                table: "VaccineHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AdministeredBy",
                table: "VaccineHistories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_AdministeredBy",
                table: "VaccineHistories",
                column: "AdministeredBy");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccineHistories_Accounts_AdministeredBy",
                table: "VaccineHistories",
                column: "AdministeredBy",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
