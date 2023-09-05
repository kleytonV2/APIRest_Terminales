using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRest_Terminales.Data.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id_estado);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id_fab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fab_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fab_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id_fab);
                });

            migrationBuilder.CreateTable(
                name: "Terminales",
                columns: table => new
                {
                    Id_terminal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_fab = table.Column<int>(type: "int", nullable: false),
                    Id_estado = table.Column<int>(type: "int", nullable: false),
                    Fecha_fabricacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_estado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Terminal_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terminal_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminales", x => x.Id_terminal);
                    table.ForeignKey(
                        name: "FK_Terminales_Estado_Id_estado",
                        column: x => x.Id_estado,
                        principalTable: "Estado",
                        principalColumn: "Id_estado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terminales_Fabricantes_Id_fab",
                        column: x => x.Id_fab,
                        principalTable: "Fabricantes",
                        principalColumn: "Id_fab",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terminales_Id_estado",
                table: "Terminales",
                column: "Id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_Terminales_Id_fab",
                table: "Terminales",
                column: "Id_fab");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Terminales");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Fabricantes");
        }
    }
}
