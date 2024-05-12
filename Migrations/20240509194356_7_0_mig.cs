using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _7_0_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FifthArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForthArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SixthArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdArtefactAddition",
                table: "UserCases",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FifthArtefactAddition",
                table: "UserCases");

            migrationBuilder.DropColumn(
                name: "FirstArtefactAddition",
                table: "UserCases");

            migrationBuilder.DropColumn(
                name: "ForthArtefactAddition",
                table: "UserCases");

            migrationBuilder.DropColumn(
                name: "SecondArtefactAddition",
                table: "UserCases");

            migrationBuilder.DropColumn(
                name: "SixthArtefactAddition",
                table: "UserCases");

            migrationBuilder.DropColumn(
                name: "ThirdArtefactAddition",
                table: "UserCases");
        }
    }
}
