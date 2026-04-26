using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeeSharpCarCare.API.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Vehicles_VIN",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Vehicles_VIN",
                table: "Invoices",
                column: "VIN",
                principalTable: "Vehicles",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Vehicles_VIN",
                table: "Invoices");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Vehicles_VIN",
                table: "Invoices",
                column: "VIN",
                principalTable: "Vehicles",
                principalColumn: "VIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
