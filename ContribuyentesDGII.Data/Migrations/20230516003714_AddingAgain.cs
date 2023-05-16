using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContribuyentesDGII.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "IdCedulation",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "IdCedulation",
                table: "ComprobantesFiscales");

            migrationBuilder.AddColumn<string>(
                name: "RncCedula",
                table: "Contribuyentes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RncCedula",
                table: "ComprobantesFiscales",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes",
                column: "RncCedula");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_RncCedula",
                table: "ComprobantesFiscales",
                column: "RncCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobantesFiscales_Contribuyentes_B",
                table: "ComprobantesFiscales",
                column: "RncCedula",
                principalTable: "Contribuyentes",
                principalColumn: "RncCedula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobantesFiscales_Contribuyentes_B",
                table: "ComprobantesFiscales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes");

            migrationBuilder.DropIndex(
                name: "IX_ComprobantesFiscales_RncCedula",
                table: "ComprobantesFiscales");

            migrationBuilder.DropColumn(
                name: "RncCedula",
                table: "Contribuyentes");

            migrationBuilder.DropColumn(
                name: "RncCedula",
                table: "ComprobantesFiscales");

            migrationBuilder.AddColumn<int>(
                name: "IdCedulation",
                table: "Contribuyentes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdCedulation",
                table: "ComprobantesFiscales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes",
                column: "IdCedulation");
        }
    }
}
