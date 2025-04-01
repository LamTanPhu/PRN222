using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Merged_OrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderPackageDetails_FKOrderPackageDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderVaccineDetails_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "OrderPackageDetails");

            migrationBuilder.DropTable(
                name: "OrderVaccineDetails");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: true),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_FKOrderId",
                        column: x => x.FKOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_VaccinePackages_FKVaccinePackageId",
                        column: x => x.FKVaccinePackageId,
                        principalTable: "VaccinePackages",
                        principalColumn: "VaccinePackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKOrderId",
                table: "OrderDetails",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKVaccineId",
                table: "OrderDetails",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FKVaccinePackageId",
                table: "OrderDetails",
                column: "FKVaccinePackageId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderPackageDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationSchedules_OrderDetails_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.CreateTable(
                name: "OrderPackageDetails",
                columns: table => new
                {
                    OrderPackageDetaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinePackageId = table.Column<int>(type: "int", nullable: false),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPackageDetails", x => x.OrderPackageDetaiId);
                    table.ForeignKey(
                        name: "FK_OrderPackageDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPackageDetails_VaccinePackages_VaccinePackageId",
                        column: x => x.VaccinePackageId,
                        principalTable: "VaccinePackages",
                        principalColumn: "VaccinePackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderVaccineDetails",
                columns: table => new
                {
                    OrderVaccineDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderVaccineDetails", x => x.OrderVaccineDetailId);
                    table.ForeignKey(
                        name: "FK_OrderVaccineDetails_Orders_FKOrderId",
                        column: x => x.FKOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderVaccineDetails_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageDetails_OrderId",
                table: "OrderPackageDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageDetails_VaccinePackageId",
                table: "OrderPackageDetails",
                column: "VaccinePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVaccineDetails_FKOrderId",
                table: "OrderVaccineDetails",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVaccineDetails_FKVaccineId",
                table: "OrderVaccineDetails",
                column: "FKVaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationSchedules_OrderPackageDetails_FKOrderPackageDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderPackageDetailsId",
                principalTable: "OrderPackageDetails",
                principalColumn: "OrderPackageDetaiId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationSchedules_OrderVaccineDetails_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderVaccineDetailsId",
                principalTable: "OrderVaccineDetails",
                principalColumn: "OrderVaccineDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
