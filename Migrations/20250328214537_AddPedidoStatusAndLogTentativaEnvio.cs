using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RevendaProject.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoStatusAndLogTentativaEnvio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LogTentativasEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTentativa = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sucesso = table.Column<bool>(type: "boolean", nullable: false),
                    MensagemErro = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTentativasEnvio", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogTentativasEnvio");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedidos");
        }
    }
}
