using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMdataLayer.Migrations
{
    /// <inheritdoc />
    public partial class maintainace1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Maintenances",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CurrentMileage",
                table: "Maintenances",
                newName: "CurrentWileage");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Maintenances",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CurrentWileage",
                table: "Maintenances",
                newName: "CurrentMileage");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Vehicles_VehicleId",
                table: "Maintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
