using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "CartItems",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CartItems",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
