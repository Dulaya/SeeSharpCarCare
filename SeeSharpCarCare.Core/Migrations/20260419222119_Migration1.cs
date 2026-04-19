using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeeSharpCarCare.Core.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairCodes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepairName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VIN);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Vehicles_VIN",
                        column: x => x.VIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Repairs_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TechnicianWorkOrder",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianWorkOrder", x => new { x.TechnicianId, x.WorkOrderId });
                    table.ForeignKey(
                        name: "FK_TechnicianWorkOrder_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    TechnicianWorkOrderTechnicianId = table.Column<int>(type: "int", nullable: true),
                    TechnicianWorkOrderWorkOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrders_TechnicianWorkOrder_TechnicianWorkOrderTechnicianId_TechnicianWorkOrderWorkOrderId",
                        columns: x => new { x.TechnicianWorkOrderTechnicianId, x.TechnicianWorkOrderWorkOrderId },
                        principalTable: "TechnicianWorkOrder",
                        principalColumns: new[] { "TechnicianId", "WorkOrderId" });
                    table.ForeignKey(
                        name: "FK_WorkOrders_Vehicles_VIN",
                        column: x => x.VIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TechnicianId",
                table: "Invoices",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_VIN",
                table: "Invoices",
                column: "VIN");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_InvoiceId",
                table: "Repairs",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_TechnicianId",
                table: "Repairs",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_WorkOrderId",
                table: "Repairs",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianWorkOrder_WorkOrderId",
                table: "TechnicianWorkOrder",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_InvoiceId",
                table: "WorkOrders",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_TechnicianWorkOrderTechnicianId_TechnicianWorkOrderWorkOrderId",
                table: "WorkOrders",
                columns: new[] { "TechnicianWorkOrderTechnicianId", "TechnicianWorkOrderWorkOrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_VIN",
                table: "WorkOrders",
                column: "VIN");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_WorkOrders_WorkOrderId",
                table: "Repairs",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianWorkOrder_WorkOrders_WorkOrderId",
                table: "TechnicianWorkOrder",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Customers_CustomerId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Technicians_TechnicianId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianWorkOrder_Technicians_TechnicianId",
                table: "TechnicianWorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Vehicles_VIN",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Vehicles_VIN",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Invoices_InvoiceId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianWorkOrder_WorkOrders_WorkOrderId",
                table: "TechnicianWorkOrder");

            migrationBuilder.DropTable(
                name: "RepairCodes");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "TechnicianWorkOrder");
        }
    }
}
