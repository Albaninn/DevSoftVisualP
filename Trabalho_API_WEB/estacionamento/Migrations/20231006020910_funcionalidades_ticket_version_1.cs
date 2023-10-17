using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class funcionalidades_ticket_version_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "ticket",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_TicketId",
                table: "ticket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_ticket_TicketId",
                table: "ticket",
                column: "TicketId",
                principalTable: "ticket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_ticket_TicketId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_TicketId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "ticket");
        }
    }
}
