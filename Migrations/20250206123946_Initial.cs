using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN222_Group_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCategories",
                columns: table => new
                {
                    VaccineCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCategories", x => x.VaccineCategoryId);
                    table.ForeignKey(
                        name: "FK_VaccineCategories_VaccineCategories_FKParentCategoryId",
                        column: x => x.FKParentCategoryId,
                        principalTable: "VaccineCategories",
                        principalColumn: "VaccineCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "VaccineCenters",
                columns: table => new
                {
                    VacineCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCenters", x => x.VacineCenterId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinePackages",
                columns: table => new
                {
                    VaccinePackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinePackages", x => x.VaccinePackageId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineBatches",
                columns: table => new
                {
                    VaccineBatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKManufacturerId = table.Column<int>(type: "int", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ActiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineBatches", x => x.VaccineBatchId);
                    table.ForeignKey(
                        name: "FK_VaccineBatches_Manufacturers_FKManufacturerId",
                        column: x => x.FKManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineBatches_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenProfiles",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenProfiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_ChildrenProfiles_Accounts_FKAccountId",
                        column: x => x.FKAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCategoryId = table.Column<int>(type: "int", nullable: false),
                    FKBatchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    UnitOfVolume = table.Column<int>(type: "int", nullable: false),
                    IngredientsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    BetweenPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccineBatches_FKBatchId",
                        column: x => x.FKBatchId,
                        principalTable: "VaccineBatches",
                        principalColumn: "VaccineBatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccineCategories_FKCategoryId",
                        column: x => x.FKCategoryId,
                        principalTable: "VaccineCategories",
                        principalColumn: "VaccineCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Feedbacks_FKFeedbackId",
                        column: x => x.FKFeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "FeedbackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccineHistories",
                columns: table => new
                {
                    VacineHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    AdministeredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentationProvided = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifiedStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineHistories", x => x.VacineHistoryId);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_Accounts_FKAccountId",
                        column: x => x.FKAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccineHistories_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccinePackageDetails",
                columns: table => new
                {
                    VaccinePackageDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineId = table.Column<int>(type: "int", nullable: false),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: false),
                    PackagePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinePackageDetails", x => x.VaccinePackageDetailId);
                    table.ForeignKey(
                        name: "FK_VaccinePackageDetails_VaccinePackages_FKVaccinePackageId",
                        column: x => x.FKVaccinePackageId,
                        principalTable: "VaccinePackages",
                        principalColumn: "VaccinePackageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinePackageDetails_Vaccines_FKVaccineId",
                        column: x => x.FKVaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPackageDetails",
                columns: table => new
                {
                    OrderPackageDetaiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccinePackageId = table.Column<int>(type: "int", nullable: false),
                    VaccinePackageId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PayAmount = table.Column<int>(type: "int", nullable: false)
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
                name: "VaccinationSchedules",
                columns: table => new
                {
                    VaccinationScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKCenterId = table.Column<int>(type: "int", nullable: false),
                    FKOrderVaccineDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKOrderPackageDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoseNumber = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministeredBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationSchedules", x => x.VaccinationScheduleId);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_ChildrenProfiles_FKProfileId",
                        column: x => x.FKProfileId,
                        principalTable: "ChildrenProfiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_OrderPackageDetails_FKOrderPackageDetailsId",
                        column: x => x.FKOrderPackageDetailsId,
                        principalTable: "OrderPackageDetails",
                        principalColumn: "OrderPackageDetaiId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_OrderVaccineDetails_FKOrderVaccineDetailsId",
                        column: x => x.FKOrderVaccineDetailsId,
                        principalTable: "OrderVaccineDetails",
                        principalColumn: "OrderVaccineDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_VaccineCenters_FKCenterId",
                        column: x => x.FKCenterId,
                        principalTable: "VaccineCenters",
                        principalColumn: "VacineCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaccineReactions",
                columns: table => new
                {
                    VaccineReactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKVaccineScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    ReactionTime = table.Column<int>(type: "int", nullable: false),
                    ResolvedTime = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Accounts_FKCenterId",
                table: "Accounts",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenProfiles_FKAccountId",
                table: "ChildrenProfiles",
                column: "FKAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageDetails_OrderId",
                table: "OrderPackageDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPackageDetails_VaccinePackageId",
                table: "OrderPackageDetails",
                column: "VaccinePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKFeedbackId",
                table: "Orders",
                column: "FKFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FKProfileId",
                table: "Orders",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVaccineDetails_FKOrderId",
                table: "OrderVaccineDetails",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderVaccineDetails_FKVaccineId",
                table: "OrderVaccineDetails",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FKOrderId",
                table: "Payments",
                column: "FKOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKCenterId",
                table: "VaccinationSchedules",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKOrderPackageDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderPackageDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKOrderVaccineDetailsId",
                table: "VaccinationSchedules",
                column: "FKOrderVaccineDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_FKProfileId",
                table: "VaccinationSchedules",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineBatches_FKCenterId",
                table: "VaccineBatches",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineBatches_FKManufacturerId",
                table: "VaccineBatches",
                column: "FKManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCategories_FKParentCategoryId",
                table: "VaccineCategories",
                column: "FKParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKAccountId",
                table: "VaccineHistories",
                column: "FKAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKCenterId",
                table: "VaccineHistories",
                column: "FKCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKProfileId",
                table: "VaccineHistories",
                column: "FKProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineHistories_FKVaccineId",
                table: "VaccineHistories",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinePackageDetails_FKVaccineId",
                table: "VaccinePackageDetails",
                column: "FKVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinePackageDetails_FKVaccinePackageId",
                table: "VaccinePackageDetails",
                column: "FKVaccinePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineReactions_FKVaccineScheduleId",
                table: "VaccineReactions",
                column: "FKVaccineScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_FKBatchId",
                table: "Vaccines",
                column: "FKBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_FKCategoryId",
                table: "Vaccines",
                column: "FKCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "VaccineHistories");

            migrationBuilder.DropTable(
                name: "VaccinePackageDetails");

            migrationBuilder.DropTable(
                name: "VaccineReactions");

            migrationBuilder.DropTable(
                name: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "OrderPackageDetails");

            migrationBuilder.DropTable(
                name: "OrderVaccineDetails");

            migrationBuilder.DropTable(
                name: "VaccinePackages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "ChildrenProfiles");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "VaccineBatches");

            migrationBuilder.DropTable(
                name: "VaccineCategories");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "VaccineCenters");
        }
    }
}
