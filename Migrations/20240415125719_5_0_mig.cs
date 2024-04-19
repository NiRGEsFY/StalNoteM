using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _5_0_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtefactItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Pottential = table.Column<int>(type: "int", nullable: false),
                    CarryWeight = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Stamina = table.Column<double>(type: "float", nullable: false),
                    StaminaRegeneration = table.Column<double>(type: "float", nullable: false),
                    LacerationProtection = table.Column<double>(type: "float", nullable: false),
                    ExplosionProtection = table.Column<double>(type: "float", nullable: false),
                    Stability = table.Column<double>(type: "float", nullable: false),
                    HealingEffectiveness = table.Column<double>(type: "float", nullable: false),
                    BulletResistance = table.Column<double>(type: "float", nullable: false),
                    HealthRegeneration = table.Column<double>(type: "float", nullable: false),
                    Vitality = table.Column<double>(type: "float", nullable: false),
                    Bleeding = table.Column<double>(type: "float", nullable: false),
                    BiologicalInfection = table.Column<double>(type: "float", nullable: false),
                    BiologicalResistance = table.Column<double>(type: "float", nullable: false),
                    BioinfectionProtection = table.Column<double>(type: "float", nullable: false),
                    PsyEmissionsResistance = table.Column<double>(type: "float", nullable: false),
                    PsyEmissionsProtection = table.Column<double>(type: "float", nullable: false),
                    PsyEmissions = table.Column<double>(type: "float", nullable: false),
                    RadiationProtection = table.Column<double>(type: "float", nullable: false),
                    RadiationResistance = table.Column<double>(type: "float", nullable: false),
                    Radiation = table.Column<double>(type: "float", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Frost = table.Column<double>(type: "float", nullable: false),
                    ReactionToLaceration = table.Column<double>(type: "float", nullable: false),
                    ReactionToElectricity = table.Column<double>(type: "float", nullable: false),
                    ReactionToChemicalBurns = table.Column<double>(type: "float", nullable: false),
                    ReactionToBurns = table.Column<double>(type: "float", nullable: false),
                    TriggersDamage = table.Column<double>(type: "float", nullable: false),
                    ReducesDamageBy = table.Column<double>(type: "float", nullable: false),
                    Reload = table.Column<double>(type: "float", nullable: false),
                    ChargeRequiredToActivate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtefactItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtefactItems");
        }
    }
}
