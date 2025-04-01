using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Feedbacks_FKFeedbackId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccineBatches_Manufacturers_FKManufacturerId",
                table: "VaccineBatches");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "VaccineReactions");

            migrationBuilder.DropIndex(
                name: "IX_VaccineBatches_FKManufacturerId",
                table: "VaccineBatches");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FKFeedbackId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FKManufacturerId",
                table: "VaccineBatches");

            migrationBuilder.DropColumn(
                name: "FKFeedbackId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalOrderPrice",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalOrderPrice",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "FKManufacturerId",
                table: "VaccineBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FKFeedbackId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayAmount = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_FKOrderId",
                        column: x => x.FKOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineReactions",
                columns: table => new
                {
                    VaccineReactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReactionTime = table.Column<int>(type: "int", nullable: false),
                    ResolvedTime = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineReactions", x => x.VaccineReactionId);
                    table.ForeignKey(
                        name: "FK_VaccineReactions_VaccinationSchedules_FKVaccineScheduleId",
                        column: x => x.FKVaccineScheduleId,
                        principalTable: "VaccinationSchedules",
                        principalColumn: "VaccinationScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccineBatches_FKManufacturerId",
                table: "VaccineBatches",
                column: "FKManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKFeedbackId",
                table: "Orders",
                column: "FKFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FKOrderId",
                table: "Payments",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineReactions_FKVaccineScheduleId",
                table: "VaccineReactions",
                column: "FKVaccineScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Feedbacks_FKFeedbackId",
                table: "Orders",
                column: "FKFeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "FeedbackId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccineBatches_Manufacturers_FKManufacturerId",
                table: "VaccineBatches",
                column: "FKManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
