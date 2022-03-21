using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo.Infrastructure.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "cidade",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    cidade_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_pessoa_cidade_cidade_id",
                        column: x => x.cidade_id,
                        principalSchema: "dbo",
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_cidade_id",
                schema: "dbo",
                table: "pessoa",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_cpf",
                schema: "dbo",
                table: "pessoa",
                column: "cpf",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "cidade",
                schema: "dbo");
        }
    }
}
