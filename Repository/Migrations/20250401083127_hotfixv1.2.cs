using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class hotfixv12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_VaccineCenters_FKCenterId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "QuantityAvailable",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "VaccineBatches");

            migrationBuilder.RenameColumn(
                name: "TotalOrderPrice",
                table: "Orders",
                newName: "TotalPaidPrice");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "TotalAmountPrice");

            migrationBuilder.RenameColumn(
                name: "Allergies",
                table: "ChildrenProfiles",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "VaccineCenters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "VaccineBatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDate",
                table: "VaccinationSchedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "FKCenterId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_VaccineCenters_FKCenterId",
                table: "Accounts",
                column: "FKCenterId",
                principalTable: "VaccineCenters",
                principalColumn: "VacineCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_VaccineCenters_FKCenterId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "VaccineCenters");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "VaccineBatches");

            migrationBuilder.RenameColumn(
                name: "TotalPaidPrice",
                table: "Orders",
                newName: "TotalOrderPrice");

            migrationBuilder.RenameColumn(
                name: "TotalAmountPrice",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ChildrenProfiles",
                newName: "Allergies");

            migrationBuilder.AddColumn<int>(
                name: "QuantityAvailable",
                table: "Vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "VaccineBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActualDate",
                table: "VaccinationSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FKCenterId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_VaccineCenters_FKCenterId",
                table: "Accounts",
                column: "FKCenterId",
                principalTable: "VaccineCenters",
                principalColumn: "VacineCenterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
