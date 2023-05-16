using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContribuyentesDGII.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReversingEverything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "RncCedula",
                table: "Contribuyentes",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RncCedula",
                table: "ComprobantesFiscales",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribuyentes",
                table: "Contribuyentes",
                column: "RncCedula");
        }
    }
}
