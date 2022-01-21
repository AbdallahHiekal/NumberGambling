using Microsoft.EntityFrameworkCore.Migrations;

namespace NumberGambling.Infra.Data.Migrations
{
    public partial class addrelationshipusergambling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Gamblings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Gamblings_UserId",
                table: "Gamblings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gamblings_Users_UserId",
                table: "Gamblings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gamblings_Users_UserId",
                table: "Gamblings");

            migrationBuilder.DropIndex(
                name: "IX_Gamblings_UserId",
                table: "Gamblings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gamblings");
        }
    }
}
