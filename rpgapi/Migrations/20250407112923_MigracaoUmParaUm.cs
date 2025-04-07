using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGEM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGEM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGEM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "TB_ARMAS",
                columns: new[] { "Id", "Dano", "Nome", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 35, "arco", 1 },
                    { 2, 35, "arco", 2 },
                    { 3, 35, "arco", 3 },
                    { 4, 35, "arco", 4 },
                    { 5, 35, "arco", 5 },
                    { 6, 35, "arco", 6 },
                    { 7, 35, "arco", 7 }
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGEM",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGEM_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGEM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGEM_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGEM");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGEM");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGEM");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");
        }
    }
}
