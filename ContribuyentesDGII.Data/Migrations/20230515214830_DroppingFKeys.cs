using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContribuyentesDGII.Data.Migrations
{
    /// <inheritdoc />
    public partial class DroppingFKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobantesFiscales_Contribuyentes",
                table: "ComprobantesFiscales");

            migrationBuilder.DropIndex(
                name: "IX_ComprobantesFiscales_RncCedula",
                table: "ComprobantesFiscales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_RncCedula",
                table: "ComprobantesFiscales",
                column: "RncCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobantesFiscales_Contribuyentes",
                table: "ComprobantesFiscales",
                column: "RncCedula",
                principalTable: "Contribuyentes",
                principalColumn: "RncCedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
