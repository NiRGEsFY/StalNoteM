using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _3_0_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Stability",
                table: "ArmorsItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stability",
                table: "ArmorsItems");
        }
    }
}
