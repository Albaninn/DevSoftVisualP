using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho_API_web.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Modelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarcaId = table.Column<int>(type: "INTEGER", nullable: true),
                    DescricaoModelo = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "ClienteVeiculo",
                columns: table => new
                {
                    ClientesCpf = table.Column<string>(type: "TEXT", nullable: false),
                    VeiculosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteVeiculo", x => new { x.ClientesCpf, x.VeiculosId });
                    table.ForeignKey(
                        name: "FK_ClienteVeiculo_cliente_ClientesCpf",
                        column: x => x.ClientesCpf,
                        principalTable: "cliente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
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
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HoraSaida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoServico = table.Column<string>(type: "TEXT", nullable: true),
                    ValorHora = table.Column<double>(type: "REAL", nullable: false),
                    ValorPagar = table.Column<double>(type: "REAL", nullable: true),
                    _ClienteCpf = table.Column<string>(type: "TEXT", nullable: false),
                    _PeriodoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servico_cliente__ClienteCpf",
                        column: x => x._ClienteCpf,
                        principalTable: "cliente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servico_periodo__PeriodoId",
                        column: x => x._PeriodoId,
                        principalTable: "periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodTicket = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    VeiculoPlaca = table.Column<string>(type: "TEXT", nullable: false),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    CorExterna = table.Column<int>(type: "INTEGER", nullable: false),
                    ModeloId = table.Column<int>(type: "INTEGER", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    TicketId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_veiculo_ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteVeiculo_VeiculosId",
                table: "ClienteVeiculo",
                column: "VeiculosId");

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
                name: "IX_periodo_ServicoId",
                table: "periodo",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_periodo_TicketId",
                table: "periodo",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_servico__ClienteCpf",
                table: "servico",
                column: "_ClienteCpf");

            migrationBuilder.CreateIndex(
                name: "IX_servico__PeriodoId",
                table: "servico",
                column: "_PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_ServicoId",
                table: "ticket",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_TicketId",
                table: "ticket",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_VeiculoId",
                table: "ticket",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ModeloId",
                table: "veiculo",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_TicketId",
                table: "veiculo",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteVeiculo_veiculo_VeiculosId",
                table: "ClienteVeiculo",
                column: "VeiculosId",
                principalTable: "veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notasFiscais_servico_ServicoId",
                table: "notasFiscais",
                column: "ServicoId",
                principalTable: "servico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_periodo_servico_ServicoId",
                table: "periodo",
                column: "ServicoId",
                principalTable: "servico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_periodo_ticket_TicketId",
                table: "periodo",
                column: "TicketId",
                principalTable: "ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_veiculo_VeiculoId",
                table: "ticket",
                column: "VeiculoId",
                principalTable: "veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_servico_cliente__ClienteCpf",
                table: "servico");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_veiculo_VeiculoId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_periodo_servico_ServicoId",
                table: "periodo");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_servico_ServicoId",
                table: "ticket");

            migrationBuilder.DropTable(
                name: "ClienteVeiculo");

            migrationBuilder.DropTable(
                name: "notasFiscais");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "ticket");
        }
    }
}
