using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeeSharpCarCare.API.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_WorkOrders_Vehicles_VIN",
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
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Repairs_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TechnicianWorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianWorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicianWorkOrders_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicianWorkOrders_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "RepairCodes",
                columns: new[] { "Id", "RepairName" },
                values: new object[,]
                {
                    { "AC", "Air Conditioning" },
                    { "BB", "Brake Bleeding" },
                    { "BP", "Brake Pads" },
                    { "BR", "Battery Replacement" },
                    { "BT", "Battery Testing" },
                    { "CL", "Clutch" },
                    { "CR", "Coolant Flush" },
                    { "CS", "Charging System" },
                    { "CW", "Car Wash" },
                    { "ECM", "Engine Control Module" },
                    { "EM", "Electric Motor" },
                    { "ES", "Engine Swap" },
                    { "FP", "Fuel Pump" },
                    { "HB", "Hybrid System" },
                    { "HR", "Head Lights" },
                    { "OC", "Oil Change" },
                    { "SP", "Spark Plugs" },
                    { "SS", "Suspension System" },
                    { "ST", "Steering System" },
                    { "TF", "Transmission Fluid" },
                    { "TR", "Tire Rotation" },
                    { "TRN", "Tire Replacement (New)" },
                    { "TRU", "Tire Replacement (Used)" },
                    { "TS", "Transmission Service" },
                    { "WA", "Wheel Alignment" },
                    { "WB", "Wheel Balancing" }
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
                name: "IX_TechnicianWorkOrders_TechnicianId",
                table: "TechnicianWorkOrders",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianWorkOrders_WorkOrderId",
                table: "TechnicianWorkOrders",
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
                name: "IX_WorkOrders_VIN",
                table: "WorkOrders",
                column: "VIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairCodes");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "TechnicianWorkOrders");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
