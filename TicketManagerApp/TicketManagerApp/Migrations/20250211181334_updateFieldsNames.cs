using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class updateFieldsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CustomFiles_CustomFileId1",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomFileId1",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CustomFileId1",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CustomFiles",
                newName: "CustomFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomFileId",
                table: "Tickets",
                column: "CustomFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CustomFiles_CustomFileId",
                table: "Tickets",
                column: "CustomFileId",
                principalTable: "CustomFiles",
                principalColumn: "CustomFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CustomFiles_CustomFileId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomFileId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "CustomFileId",
                table: "CustomFiles",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CustomFileId1",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomFileId1",
                table: "Tickets",
                column: "CustomFileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CustomFiles_CustomFileId1",
                table: "Tickets",
                column: "CustomFileId1",
                principalTable: "CustomFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
