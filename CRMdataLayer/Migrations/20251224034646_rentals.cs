using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMdataLayer.Migrations
{
    /// <inheritdoc />
    public partial class rentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "Rentals",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "Rentals",
                newName: "RentalDays");

            migrationBuilder.RenameColumn(
                name: "RentDate",
                table: "Rentals",
                newName: "EndDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualReturnDate",
                table: "Rentals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceDue",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "DailyRate",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DamageFee",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LateFee",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentNotes",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Rentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Rentals",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualReturnDate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "BalanceDue",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DailyRate",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DamageFee",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "LateFee",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "PaymentNotes",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Rentals",
                newName: "TotalCost");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rentals",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "RentalDays",
                table: "Rentals",
                newName: "RentalId");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Rentals",
                newName: "RentDate");
        }
    }
}
