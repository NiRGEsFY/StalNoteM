using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _6_0_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    CaseItemId = table.Column<int>(type: "int", nullable: false),
                    FirstArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    FirstArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    FirstArtefactId = table.Column<int>(type: "int", nullable: true),
                    SecondArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    SecondArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    SecondArtefactId = table.Column<int>(type: "int", nullable: true),
                    ThirdArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    ThirdArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    ThirdArtefactId = table.Column<int>(type: "int", nullable: true),
                    ForthArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    ForthArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    ForthArtefactId = table.Column<int>(type: "int", nullable: true),
                    FifthArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    FifthArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    FifthArtefactId = table.Column<int>(type: "int", nullable: true),
                    SixthArtefactQuality = table.Column<int>(type: "int", nullable: false),
                    SixthArtefactPercent = table.Column<double>(type: "float", nullable: false),
                    SixthArtefactId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_FifthArtefactId",
                        column: x => x.FifthArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_FirstArtefactId",
                        column: x => x.FirstArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_ForthArtefactId",
                        column: x => x.ForthArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_SecondArtefactId",
                        column: x => x.SecondArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_SixthArtefactId",
                        column: x => x.SixthArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_ArtefactItems_ThirdArtefactId",
                        column: x => x.ThirdArtefactId,
                        principalTable: "ArtefactItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCases_CaseItems_CaseItemId",
                        column: x => x.CaseItemId,
                        principalTable: "CaseItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_CaseItemId",
                table: "UserCases",
                column: "CaseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_FifthArtefactId",
                table: "UserCases",
                column: "FifthArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_FirstArtefactId",
                table: "UserCases",
                column: "FirstArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_ForthArtefactId",
                table: "UserCases",
                column: "ForthArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_SecondArtefactId",
                table: "UserCases",
                column: "SecondArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_SixthArtefactId",
                table: "UserCases",
                column: "SixthArtefactId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_ThirdArtefactId",
                table: "UserCases",
                column: "ThirdArtefactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCases");
        }
    }
}
