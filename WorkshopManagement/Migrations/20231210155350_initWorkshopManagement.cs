using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkshopManagement.Migrations
{
    /// <inheritdoc />
    public partial class initWorkshopManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopSlots",
                columns: table => new
                {
                    SlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    SlotDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopSlots", x => x.SlotID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleWorkshopSlot",
                columns: table => new
                {
                    VehiclesVehicleID = table.Column<int>(type: "int", nullable: false),
                    WorkshopSlotsSlotID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleWorkshopSlot", x => new { x.VehiclesVehicleID, x.WorkshopSlotsSlotID });
                    table.ForeignKey(
                        name: "FK_VehicleWorkshopSlot_Vehicles_VehiclesVehicleID",
                        column: x => x.VehiclesVehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleWorkshopSlot_WorkshopSlots_WorkshopSlotsSlotID",
                        column: x => x.WorkshopSlotsSlotID,
                        principalTable: "WorkshopSlots",
                        principalColumn: "SlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerID",
                table: "Vehicles",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleWorkshopSlot_WorkshopSlotsSlotID",
                table: "VehicleWorkshopSlot",
                column: "WorkshopSlotsSlotID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleWorkshopSlot");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "WorkshopSlots");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
