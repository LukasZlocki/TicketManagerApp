﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactoryLocations",
                columns: table => new
                {
                    FactoryLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Factory = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryLocations", x => x.FactoryLocationId);
                });

            migrationBuilder.CreateTable(
                name: "LabLocations",
                columns: table => new
                {
                    LabLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Factory = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabLocations", x => x.LabLocationId);
                });

            migrationBuilder.CreateTable(
                name: "ProductDisplacements",
                columns: table => new
                {
                    ProductDisplacementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Displacement = table.Column<int>(type: "int", nullable: false),
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDisplacements", x => x.ProductDisplacementId);
                });

            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyDescription = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.ProductFamilyId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeDesc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ReportStructures",
                columns: table => new
                {
                    ReportStructureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReportTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStructures", x => x.ReportStructureId);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    ReportTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportShortType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ReportDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TestParameters",
                columns: table => new
                {
                    TestParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParameters", x => x.TestParameterId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TestUnits = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LabLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    TicketStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.TicketStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FactoryLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_FactoryLocations_FactoryLocationId",
                        column: x => x.FactoryLocationId,
                        principalTable: "FactoryLocations",
                        principalColumn: "FactoryLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductDisplacementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductDisplacements_ProductDisplacementId",
                        column: x => x.ProductDisplacementId,
                        principalTable: "ProductDisplacements",
                        principalColumn: "ProductDisplacementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductFamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "ProductFamilies",
                        principalColumn: "ProductFamilyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestorEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImplementedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LabLocationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_LabLocations_LabLocationId",
                        column: x => x.LabLocationId,
                        principalTable: "LabLocations",
                        principalColumn: "LabLocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "TicketStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTests",
                columns: table => new
                {
                    TicketTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTests", x => x.TicketTestId);
                    table.ForeignKey(
                        name: "FK_TicketTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTests_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketTestParameters",
                columns: table => new
                {
                    TicketTestParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterValue = table.Column<double>(type: "float", nullable: false),
                    TestParameterId = table.Column<int>(type: "int", nullable: false),
                    TicketTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTestParameters", x => x.TicketTestParameterId);
                    table.ForeignKey(
                        name: "FK_TicketTestParameters_TestParameters_TestParameterId",
                        column: x => x.TestParameterId,
                        principalTable: "TestParameters",
                        principalColumn: "TestParameterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                        column: x => x.TicketTestId,
                        principalTable: "TicketTests",
                        principalColumn: "TicketTestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FactoryLocationId",
                table: "Departments",
                column: "FactoryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDisplacementId",
                table: "Products",
                column: "ProductDisplacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFamilyId",
                table: "Products",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartmentId",
                table: "Tickets",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LabLocationId",
                table: "Tickets",
                column: "LabLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProductId",
                table: "Tickets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusId",
                table: "Tickets",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTestParameters_TestParameterId",
                table: "TicketTestParameters",
                column: "TestParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTestParameters_TicketTestId",
                table: "TicketTestParameters",
                column: "TicketTestId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTests_TestId",
                table: "TicketTests",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTests_TicketId",
                table: "TicketTests",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportStructures");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "TicketTestParameters");

            migrationBuilder.DropTable(
                name: "TestParameters");

            migrationBuilder.DropTable(
                name: "TicketTests");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "LabLocations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropTable(
                name: "FactoryLocations");

            migrationBuilder.DropTable(
                name: "ProductDisplacements");

            migrationBuilder.DropTable(
                name: "ProductFamilies");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
