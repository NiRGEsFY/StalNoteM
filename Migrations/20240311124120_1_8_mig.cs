using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _1_8_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pottential",
                table: "UserItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quality",
                table: "UserItems",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pottential",
                table: "UserItems");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "UserItems");
        }
    }
}
