using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class criacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoMarca = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HoraSaida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoModelo = table.Column<string>(type: "TEXT", nullable: true),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: true),
                    Porte = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorPagar = table.Column<double>(type: "REAL", nullable: false),
                    DescricaoServico = table.Column<string>(type: "TEXT", nullable: true),
                    ValorHora = table.Column<double>(type: "REAL", nullable: false),
                    PeriodoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servico_periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "periodo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    CorExterna = table.Column<int>(type: "INTEGER", nullable: false),
                    ModeloId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteCpf = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Caminhonete_NroPortas = table.Column<int>(type: "INTEGER", nullable: true),
                    Combustivel = table.Column<string>(type: "TEXT", nullable: true),
                    NroPortas = table.Column<int>(type: "INTEGER", nullable: true),
                    Bau = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veiculo_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_veiculo_cliente_ClienteCpf",
                        column: x => x.ClienteCpf,
                        principalTable: "cliente",
                        principalColumn: "Cpf");
                });

            migrationBuilder.CreateTable(
                name: "notasFiscais",
                columns: table => new
                {
                    NumeroNota = table.Column<string>(type: "TEXT", nullable: false),
                    ValorDaNota = table.Column<double>(type: "REAL", nullable: false),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteCpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notasFiscais", x => x.NumeroNota);
                    table.ForeignKey(
                        name: "FK_notasFiscais_cliente_ClienteCpf",
                        column: x => x.ClienteCpf,
                        principalTable: "cliente",
                        principalColumn: "Cpf");
                    table.ForeignKey(
                        name: "FK_notasFiscais_servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "servico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodTicket = table.Column<int>(type: "INTEGER", nullable: false),
                    PublicServicoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_servico_PublicServicoId",
                        column: x => x.PublicServicoId,
                        principalTable: "servico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MarcaId",
                table: "Modelo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_notasFiscais_ClienteCpf",
                table: "notasFiscais",
                column: "ClienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_notasFiscais_ServicoId",
                table: "notasFiscais",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_servico_PeriodoId",
                table: "servico",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_PublicServicoId",
                table: "ticket",
                column: "PublicServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ClienteCpf",
                table: "veiculo",
                column: "ClienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ModeloId",
                table: "veiculo",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notasFiscais");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
