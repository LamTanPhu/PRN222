using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class HotFix_v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderPackageDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationSchedules_FKOrderPackageDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropColumn(
                name: "FKOrderPackageDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.RenameColumn(
                name: "FKOrderVaccineDetailsId",
                table: "VaccinationSchedules",
                newName: "FKOrderDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationSchedules_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules",
                newName: "IX_VaccinationSchedules_FKOrderDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.RenameColumn(
                name: "FKOrderDetailsId",
                table: "VaccinationSchedules",
                newName: "FKOrderVaccineDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationSchedules_FKOrderDetailsId",
                table: "VaccinationSchedules",
                newName: "IX_VaccinationSchedules_FKOrderVaccineDetailsId");

            migrationBuilder.AddColumn<Guid>(
                name: "FKOrderPackageDetailsId",
                table: "VaccinationSchedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKOrderPackageDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderPackageDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderPackageDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderPackageDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderVaccineDetailsId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
