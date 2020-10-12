using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IplanRio.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    HoraAbertura = table.Column<string>(nullable: false),
                    HoraFechamento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shopping",
                columns: new[] { "Id", "Endereco", "HoraAbertura", "HoraFechamento", "Nome" },
                values: new object[] { 1, "Rua Lauro Müller, 116 - Botafogo, Rio de Janeiro - RJ, 22290-160", "10:00", "22:00", "Shopping Rio Sul" });

            migrationBuilder.InsertData(
                table: "Shopping",
                columns: new[] { "Id", "Endereco", "HoraAbertura", "HoraFechamento", "Nome" },
                values: new object[] { 2, "Av. Vicente de Carvalho, 909 - Vila da Penha, Rio de Janeiro - RJ, 21210-000", "10:00", "22:00", "Shopping Carioca" });

            migrationBuilder.InsertData(
                table: "Shopping",
                columns: new[] { "Id", "Endereco", "HoraAbertura", "HoraFechamento", "Nome" },
                values: new object[] { 3, "Av. Maracanã, 987 - Tijuca, Rio de Janeiro - RJ, 20511-000", "10:00", "22:00", "Shopping Tijuca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopping");
        }
    }
}
