using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cb7c27c-1fc7-4c7a-9966-fea05811e962", null, "Editor", "EDITOR" },
                    { "342908f7-3065-4af5-991b-a49a53a7e8fd", null, "Admin", "ADMIN" },
                    { "35a5bdf2-7bfa-4898-bf8e-0618584d0672", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cb7c27c-1fc7-4c7a-9966-fea05811e962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "342908f7-3065-4af5-991b-a49a53a7e8fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a5bdf2-7bfa-4898-bf8e-0618584d0672");
        }
    }
}
