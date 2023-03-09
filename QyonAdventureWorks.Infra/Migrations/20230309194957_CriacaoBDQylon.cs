using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QyonAdventureWorks.Infra.Migrations
{
    public partial class CriacaoBDQylon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    CompetidorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: true),
                    Sexo = table.Column<string>(type: "char(1)", nullable: true),
                    TemperaturaMediaCorpo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.CompetidorId);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCorrida",
                columns: table => new
                {
                    HistoricoCorridaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetidorId = table.Column<int>(type: "int", nullable: false),
                    PistaCorridaId = table.Column<int>(type: "int", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoGasto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCorrida", x => x.HistoricoCorridaId);
                });

            migrationBuilder.CreateTable(
                name: "PistaCorrida",
                columns: table => new
                {
                    PistaCorridaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistaCorrida", x => x.PistaCorridaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "HistoricoCorrida");

            migrationBuilder.DropTable(
                name: "PistaCorrida");
        }
    }
}
