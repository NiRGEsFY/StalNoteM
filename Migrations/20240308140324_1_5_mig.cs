using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _1_5_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Period",
                table: "Roles",
                newName: "MaxCase");

            migrationBuilder.AddColumn<int>(
                name: "MaxArt",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxArt",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "MaxCase",
                table: "Roles",
                newName: "Period");
        }
    }
}
