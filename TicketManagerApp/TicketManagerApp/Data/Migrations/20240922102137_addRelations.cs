using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class addRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TestParameters_TestParameterId",
                table: "TicketTestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTests_Tests_TestId",
                table: "TicketTests");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TestParameters_TestParameterId",
                table: "TicketTestParameters",
                column: "TestParameterId",
                principalTable: "TestParameters",
                principalColumn: "TestParameterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters",
                column: "TicketTestId",
                principalTable: "TicketTests",
                principalColumn: "TicketTestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTests_Tests_TestId",
                table: "TicketTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TestParameters_TestParameterId",
                table: "TicketTestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTests_Tests_TestId",
                table: "TicketTests");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TestParameters_TestParameterId",
                table: "TicketTestParameters",
                column: "TestParameterId",
                principalTable: "TestParameters",
                principalColumn: "TestParameterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTestParameters_TicketTests_TicketTestId",
                table: "TicketTestParameters",
                column: "TicketTestId",
                principalTable: "TicketTests",
                principalColumn: "TicketTestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTests_Tests_TestId",
                table: "TicketTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
