using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchesWebShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FRSTProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryID", "ImageURL", "ModelNumber", "Price", "Series" },
                values: new object[] { 1, "Casio", 1, "", "5566", 556.99000000000001, "144-GT" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
