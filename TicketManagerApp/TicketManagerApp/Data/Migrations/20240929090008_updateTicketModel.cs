using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class updateTicketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsibleLabSpecialist",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters",
                column: "TicketTestId",
                principalTable: "TicketTests",
                principalColumn: "TicketTestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters");

            migrationBuilder.DropColumn(
                name: "ResponsibleLabSpecialist",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters",
                column: "TicketTestId",
                principalTable: "TicketTests",
                principalColumn: "TicketTestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
