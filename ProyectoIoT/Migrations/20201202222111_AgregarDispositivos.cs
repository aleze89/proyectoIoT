using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIoT.Migrations
{
    public partial class AgregarDispositivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispositivos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    CambiarEstado = table.Column<bool>(nullable: false),
                    Temporizar = table.Column<float>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    Potencia = table.Column<int>(nullable: false),
                    DuenioID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dispositivos_Usuarios_DuenioID",
                        column: x => x.DuenioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivos_DuenioID",
                table: "Dispositivos",
                column: "DuenioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositivos");
        }
    }
}
