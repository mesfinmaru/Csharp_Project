using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMdataLayer.Migrations
{
    /// <inheritdoc />
    public partial class maintn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "NextMaintenanceDate",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "NextServiceKm",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ServiceContact",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "ServiceProvider",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "MaintenanceDate",
                table: "Maintenances",
                newName: "ScheduledDate");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Maintenances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Scheduled",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceType",
                table: "Maintenances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Maintenances",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Maintenances",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                table: "Maintenances",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MechanicPhone",
                table: "Maintenances",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Maintenances",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "MechanicName",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "MechanicPhone",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Maintenances");

            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "Maintenances",
                newName: "MaintenanceDate");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Scheduled");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceType",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Maintenances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMaintenanceDate",
                table: "Maintenances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextServiceKm",
                table: "Maintenances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContact",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceProvider",
                table: "Maintenances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
