using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContribuyentesDGII.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    IdEstatus = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.IdEstatus);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersonas",
                columns: table => new
                {
                    IdTipoPersona = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionPersona = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonas", x => x.IdTipoPersona);
                });

            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    RncCedula = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoPersona = table.Column<short>(type: "smallint", nullable: false),
                    IdEstatus = table.Column<short>(type: "smallint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.RncCedula);
                    table.ForeignKey(
                        name: "FK_Contribuyentes_Estatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribuyentes_TipoPersonas",
                        column: x => x.IdTipoPersona,
                        principalTable: "TipoPersonas",
                        principalColumn: "IdTipoPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesFiscales",
                columns: table => new
                {
                    NCF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RncCedula = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesFiscales", x => x.NCF);
                    table.ForeignKey(
                        name: "FK_ComprobantesFiscales_Contribuyentes",
                        column: x => x.RncCedula,
                        principalTable: "Contribuyentes",
                        principalColumn: "RncCedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_RncCedula",
                table: "ComprobantesFiscales",
                column: "RncCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuyentes_IdEstatus",
                table: "Contribuyentes",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuyentes_IdTipoPersona",
                table: "Contribuyentes",
                column: "IdTipoPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantesFiscales");

            migrationBuilder.DropTable(
                name: "Contribuyentes");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "TipoPersonas");
        }
    }
}
