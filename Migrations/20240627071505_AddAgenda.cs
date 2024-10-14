using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Entrega.Migrations
{
    /// <inheritdoc />
    public partial class AddAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAgenda = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agenda", x => x.AgendaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Agenda");
        }
    }
}
