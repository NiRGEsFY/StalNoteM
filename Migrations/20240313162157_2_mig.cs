using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _2_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmorsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pottential = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    PeriodicHealing = table.Column<double>(type: "float", nullable: false),
                    Bleeding = table.Column<double>(type: "float", nullable: false),
                    StaminaRegeneration = table.Column<double>(type: "float", nullable: false),
                    Stamina = table.Column<double>(type: "float", nullable: false),
                    MoveSpeed = table.Column<double>(type: "float", nullable: false),
                    CarryWeight = table.Column<double>(type: "float", nullable: false),
                    BulletResistance = table.Column<double>(type: "float", nullable: false),
                    LacerationProtection = table.Column<double>(type: "float", nullable: false),
                    ExplosionProtection = table.Column<double>(type: "float", nullable: false),
                    ResistanceToElectricity = table.Column<double>(type: "float", nullable: false),
                    ResistanceToFire = table.Column<double>(type: "float", nullable: false),
                    ResistanceToChemicals = table.Column<double>(type: "float", nullable: false),
                    RadiationProtection = table.Column<double>(type: "float", nullable: false),
                    ThermalProtection = table.Column<double>(type: "float", nullable: false),
                    BioinfectionProtection = table.Column<double>(type: "float", nullable: false),
                    PsyProtection = table.Column<double>(type: "float", nullable: false),
                    BleedingProtection = table.Column<double>(type: "float", nullable: false),
                    CompatibleBackpacks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompatibleContainers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorsItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bullets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    AmmoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmorPenetration = table.Column<double>(type: "float", nullable: false),
                    Bleeding = table.Column<double>(type: "float", nullable: false),
                    StoppingPower = table.Column<double>(type: "float", nullable: false),
                    Burning = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bullets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pottential = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    AmmoType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<double>(type: "float", nullable: false),
                    StartDamage = table.Column<double>(type: "float", nullable: false),
                    EndDamage = table.Column<double>(type: "float", nullable: false),
                    DamageDecreaseStart = table.Column<double>(type: "float", nullable: false),
                    DamageDecreaseEnd = table.Column<double>(type: "float", nullable: false),
                    MagazineCapacity = table.Column<double>(type: "float", nullable: false),
                    MaxDistance = table.Column<double>(type: "float", nullable: false),
                    RateOfFire = table.Column<double>(type: "float", nullable: false),
                    Reload = table.Column<double>(type: "float", nullable: false),
                    TacticalReload = table.Column<double>(type: "float", nullable: false),
                    Spread = table.Column<double>(type: "float", nullable: false),
                    HipFireSpread = table.Column<double>(type: "float", nullable: false),
                    VerticalRecoil = table.Column<double>(type: "float", nullable: false),
                    HorizontalRecoil = table.Column<double>(type: "float", nullable: false),
                    DrawTime = table.Column<double>(type: "float", nullable: false),
                    AimingTime = table.Column<double>(type: "float", nullable: false),
                    StoppingPower = table.Column<double>(type: "float", nullable: false),
                    DamageModifierHeadshot = table.Column<double>(type: "float", nullable: false),
                    DamageModifierLimb = table.Column<double>(type: "float", nullable: false),
                    Desription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponsItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmorsItems");

            migrationBuilder.DropTable(
                name: "Bullets");

            migrationBuilder.DropTable(
                name: "WeaponsItems");
        }
    }
}
