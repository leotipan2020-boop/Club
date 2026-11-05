using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubesApp.Migrations
{
    /// <inheritdoc />
    public partial class AgregarClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Jugador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_ClubId",
                table: "Jugador",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugador_Club_ClubId",
                table: "Jugador",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugador_Club_ClubId",
                table: "Jugador");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Jugador_ClubId",
                table: "Jugador");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Jugador");
        }
    }
}
