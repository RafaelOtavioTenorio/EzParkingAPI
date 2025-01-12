using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ez_parking_api.Migrations
{
    /// <inheritdoc />
    public partial class alterarTipoListaVeiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Users_UserID",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_UserID",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Veiculos");

            migrationBuilder.AddColumn<string>(
                name: "Veiculos",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Veiculos",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Veiculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UserID",
                table: "Veiculos",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Users_UserID",
                table: "Veiculos",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
