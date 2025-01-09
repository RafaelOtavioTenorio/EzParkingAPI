using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ez_parking_api.Migrations
{
    /// <inheritdoc />
    public partial class NewTables_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CPF",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumPiso = table.Column<int>(type: "int", nullable: true),
                    NumVaga = table.Column<int>(type: "int", nullable: true),
                    Cobrado = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Saida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocalID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    VeiculoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registros_Estacionamentos_LocalID",
                        column: x => x.LocalID,
                        principalTable: "Estacionamentos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegAtualID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Veiculos_Registros_RegAtualID",
                        column: x => x.RegAtualID,
                        principalTable: "Registros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_LocalID",
                table: "Registros",
                column: "LocalID");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_VeiculoID",
                table: "Registros",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_RegAtualID",
                table: "Veiculos",
                column: "RegAtualID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UserID",
                table: "Veiculos",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Veiculos_VeiculoID",
                table: "Registros",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Estacionamentos_LocalID",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Veiculos_VeiculoID",
                table: "Registros");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
