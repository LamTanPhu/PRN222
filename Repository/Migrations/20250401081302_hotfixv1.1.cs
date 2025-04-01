using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class hotfixv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccineHistories_Accounts_FKAccountId",
                table: "VaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_VaccineHistories_FKAccountId",
                table: "VaccineHistories");

            migrationBuilder.DropColumn(
                name: "DocumentationProvided",
                table: "VaccineHistories");

            migrationBuilder.DropColumn(
                name: "FKAccountId",
                table: "VaccineHistories");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdministeredBy",
                table: "VaccineHistories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DosedNumber",
                table: "VaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccineHistories_Accounts_AdministeredBy",
                table: "VaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_VaccineHistories_AdministeredBy",
                table: "VaccineHistories");

            migrationBuilder.DropColumn(
                name: "DosedNumber",
                table: "VaccineHistories");

            migrationBuilder.AlterColumn<string>(
                name: "AdministeredBy",
                table: "VaccineHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "DocumentationProvided",
                table: "VaccineHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FKAccountId",
                table: "VaccineHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKAccountId",
                table: "VaccineHistories",
                column: "FKAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccineHistories_Accounts_FKAccountId",
                table: "VaccineHistories",
                column: "FKAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
