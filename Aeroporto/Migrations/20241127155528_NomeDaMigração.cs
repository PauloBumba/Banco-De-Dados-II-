using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aeroporto.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigração : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AERONAVE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NUM_POLTRONA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AERONAVE__3214EC27E1573627", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PREFERENCIAL = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CLIENTE__3214EC27C6DA7253", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "POLTRONA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_AERONAVE = table.Column<int>(type: "int", nullable: true),
                    LOCALIZACAO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__POLTRONA__3214EC274A2D9089", x => x.ID);
                    table.ForeignKey(
                        name: "FK__POLTRONA__ID_AER__38996AB5",
                        column: x => x.ID_AERONAVE,
                        principalTable: "AERONAVE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VOO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AEROPORTO_ORIGEM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    AEROPORTO_DESTINO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    HORARIO_SAIDA = table.Column<DateTime>(type: "datetime", nullable: true),
                    HORARIO_CHEGADA = table.Column<DateTime>(type: "datetime", nullable: true),
                    DISPONIBILIDADE = table.Column<int>(type: "int", nullable: true),
                    ID_AERONAVE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VOO__3214EC27E0A8F5C7", x => x.ID);
                    table.ForeignKey(
                        name: "FK__VOO__ID_AERONAVE__3B75D760",
                        column: x => x.ID_AERONAVE,
                        principalTable: "AERONAVE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ESCALA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VOO = table.Column<int>(type: "int", nullable: true),
                    AEROPORTO_SAIDA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ESCALA__3214EC27418E35CC", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ESCALA__ID_VOO__3E52440B",
                        column: x => x.ID_VOO,
                        principalTable: "VOO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESCALA_ID_VOO",
                table: "ESCALA",
                column: "ID_VOO");

            migrationBuilder.CreateIndex(
                name: "IX_POLTRONA_ID_AERONAVE",
                table: "POLTRONA",
                column: "ID_AERONAVE");

            migrationBuilder.CreateIndex(
                name: "IX_VOO_ID_AERONAVE",
                table: "VOO",
                column: "ID_AERONAVE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "ESCALA");

            migrationBuilder.DropTable(
                name: "POLTRONA");

            migrationBuilder.DropTable(
                name: "VOO");

            migrationBuilder.DropTable(
                name: "AERONAVE");
        }
    }
}
