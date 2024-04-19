using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StalNoteM.Migrations
{
    /// <inheritdoc />
    public partial class _5_1_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vitality",
                table: "ArtefactItems",
                newName: "VitalityMin");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "ArtefactItems",
                newName: "VitalityMax");

            migrationBuilder.RenameColumn(
                name: "StaminaRegeneration",
                table: "ArtefactItems",
                newName: "TemperatureResistanceMin");

            migrationBuilder.RenameColumn(
                name: "Stamina",
                table: "ArtefactItems",
                newName: "TemperatureResistanceMax");

            migrationBuilder.RenameColumn(
                name: "Stability",
                table: "ArtefactItems",
                newName: "TemperatureProtectionMin");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "ArtefactItems",
                newName: "TemperatureProtectionMax");

            migrationBuilder.RenameColumn(
                name: "Reload",
                table: "ArtefactItems",
                newName: "TemperatureMin");

            migrationBuilder.RenameColumn(
                name: "ReducesDamageBy",
                table: "ArtefactItems",
                newName: "TemperatureMax");

            migrationBuilder.RenameColumn(
                name: "ReactionToLaceration",
                table: "ArtefactItems",
                newName: "StaminaRegenerationMin");

            migrationBuilder.RenameColumn(
                name: "ReactionToElectricity",
                table: "ArtefactItems",
                newName: "StaminaRegenerationMax");

            migrationBuilder.RenameColumn(
                name: "ReactionToChemicalBurns",
                table: "ArtefactItems",
                newName: "StaminaMin");

            migrationBuilder.RenameColumn(
                name: "ReactionToBurns",
                table: "ArtefactItems",
                newName: "StaminaMax");

            migrationBuilder.RenameColumn(
                name: "RadiationResistance",
                table: "ArtefactItems",
                newName: "StabilityMin");

            migrationBuilder.RenameColumn(
                name: "RadiationProtection",
                table: "ArtefactItems",
                newName: "StabilityMax");

            migrationBuilder.RenameColumn(
                name: "Radiation",
                table: "ArtefactItems",
                newName: "SpeedMin");

            migrationBuilder.RenameColumn(
                name: "PsyEmissionsResistance",
                table: "ArtefactItems",
                newName: "SpeedMax");

            migrationBuilder.RenameColumn(
                name: "PsyEmissionsProtection",
                table: "ArtefactItems",
                newName: "ResistanceToChemicalsMin");

            migrationBuilder.RenameColumn(
                name: "PsyEmissions",
                table: "ArtefactItems",
                newName: "ResistanceToChemicalsMax");

            migrationBuilder.RenameColumn(
                name: "LacerationProtection",
                table: "ArtefactItems",
                newName: "ResistToFireMin");

            migrationBuilder.RenameColumn(
                name: "HealthRegeneration",
                table: "ArtefactItems",
                newName: "ResistToFireMax");

            migrationBuilder.RenameColumn(
                name: "HealingEffectiveness",
                table: "ArtefactItems",
                newName: "ReloadMin");

            migrationBuilder.RenameColumn(
                name: "Frost",
                table: "ArtefactItems",
                newName: "ReloadMax");

            migrationBuilder.RenameColumn(
                name: "ExplosionProtection",
                table: "ArtefactItems",
                newName: "ReducesDamageByMin");

            migrationBuilder.RenameColumn(
                name: "ChargeRequiredToActivate",
                table: "ArtefactItems",
                newName: "ReducesDamageByMax");

            migrationBuilder.RenameColumn(
                name: "CarryWeight",
                table: "ArtefactItems",
                newName: "ReactionToLacerationMin");

            migrationBuilder.RenameColumn(
                name: "BulletResistance",
                table: "ArtefactItems",
                newName: "ReactionToLacerationMax");

            migrationBuilder.RenameColumn(
                name: "Bleeding",
                table: "ArtefactItems",
                newName: "ReactionToElectricityMin");

            migrationBuilder.RenameColumn(
                name: "BiologicalResistance",
                table: "ArtefactItems",
                newName: "ReactionToElectricityMax");

            migrationBuilder.RenameColumn(
                name: "BiologicalInfection",
                table: "ArtefactItems",
                newName: "ReactionToChemicalBurnsMin");

            migrationBuilder.RenameColumn(
                name: "BioinfectionProtection",
                table: "ArtefactItems",
                newName: "ReactionToChemicalBurnsMax");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ArtefactItems",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SubType",
                table: "ArtefactItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArtefactItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "ArtefactItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "ArtefactItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionInfectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionInfectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionProtectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionProtectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionResistanceMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BioinfectionResistanceMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BleedingMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BleedingMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BulletResistanceMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BulletResistanceMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarryWeightMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarryWeightMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ChargeRequiredToActivateMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ChargeRequiredToActivateMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ExplosionProtectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ExplosionProtectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrostMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrostMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealingEffectivenessMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealingEffectivenessMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealthRegenerationMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HealthRegenerationMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LacerationProtectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LacerationProtectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsProtectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsProtectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsResistanceMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PsyEmissionsResistanceMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationProtectionMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationProtectionMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationResistanceMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RadiationResistanceMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReactionToBurnsMax",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReactionToBurnsMin",
                table: "ArtefactItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BioinfectionInfectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BioinfectionInfectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BioinfectionProtectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BioinfectionProtectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BioinfectionResistanceMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BioinfectionResistanceMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BleedingMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BleedingMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BulletResistanceMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "BulletResistanceMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "CarryWeightMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "CarryWeightMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ChargeRequiredToActivateMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ChargeRequiredToActivateMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ExplosionProtectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ExplosionProtectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "FrostMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "FrostMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "HealingEffectivenessMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "HealingEffectivenessMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "HealthRegenerationMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "HealthRegenerationMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "LacerationProtectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "LacerationProtectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsProtectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsProtectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsResistanceMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "PsyEmissionsResistanceMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationProtectionMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationProtectionMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationResistanceMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "RadiationResistanceMin",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ReactionToBurnsMax",
                table: "ArtefactItems");

            migrationBuilder.DropColumn(
                name: "ReactionToBurnsMin",
                table: "ArtefactItems");

            migrationBuilder.RenameColumn(
                name: "VitalityMin",
                table: "ArtefactItems",
                newName: "Vitality");

            migrationBuilder.RenameColumn(
                name: "VitalityMax",
                table: "ArtefactItems",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "TemperatureResistanceMin",
                table: "ArtefactItems",
                newName: "StaminaRegeneration");

            migrationBuilder.RenameColumn(
                name: "TemperatureResistanceMax",
                table: "ArtefactItems",
                newName: "Stamina");

            migrationBuilder.RenameColumn(
                name: "TemperatureProtectionMin",
                table: "ArtefactItems",
                newName: "Stability");

            migrationBuilder.RenameColumn(
                name: "TemperatureProtectionMax",
                table: "ArtefactItems",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "TemperatureMin",
                table: "ArtefactItems",
                newName: "Reload");

            migrationBuilder.RenameColumn(
                name: "TemperatureMax",
                table: "ArtefactItems",
                newName: "ReducesDamageBy");

            migrationBuilder.RenameColumn(
                name: "StaminaRegenerationMin",
                table: "ArtefactItems",
                newName: "ReactionToLaceration");

            migrationBuilder.RenameColumn(
                name: "StaminaRegenerationMax",
                table: "ArtefactItems",
                newName: "ReactionToElectricity");

            migrationBuilder.RenameColumn(
                name: "StaminaMin",
                table: "ArtefactItems",
                newName: "ReactionToChemicalBurns");

            migrationBuilder.RenameColumn(
                name: "StaminaMax",
                table: "ArtefactItems",
                newName: "ReactionToBurns");

            migrationBuilder.RenameColumn(
                name: "StabilityMin",
                table: "ArtefactItems",
                newName: "RadiationResistance");

            migrationBuilder.RenameColumn(
                name: "StabilityMax",
                table: "ArtefactItems",
                newName: "RadiationProtection");

            migrationBuilder.RenameColumn(
                name: "SpeedMin",
                table: "ArtefactItems",
                newName: "Radiation");

            migrationBuilder.RenameColumn(
                name: "SpeedMax",
                table: "ArtefactItems",
                newName: "PsyEmissionsResistance");

            migrationBuilder.RenameColumn(
                name: "ResistanceToChemicalsMin",
                table: "ArtefactItems",
                newName: "PsyEmissionsProtection");

            migrationBuilder.RenameColumn(
                name: "ResistanceToChemicalsMax",
                table: "ArtefactItems",
                newName: "PsyEmissions");

            migrationBuilder.RenameColumn(
                name: "ResistToFireMin",
                table: "ArtefactItems",
                newName: "LacerationProtection");

            migrationBuilder.RenameColumn(
                name: "ResistToFireMax",
                table: "ArtefactItems",
                newName: "HealthRegeneration");

            migrationBuilder.RenameColumn(
                name: "ReloadMin",
                table: "ArtefactItems",
                newName: "HealingEffectiveness");

            migrationBuilder.RenameColumn(
                name: "ReloadMax",
                table: "ArtefactItems",
                newName: "Frost");

            migrationBuilder.RenameColumn(
                name: "ReducesDamageByMin",
                table: "ArtefactItems",
                newName: "ExplosionProtection");

            migrationBuilder.RenameColumn(
                name: "ReducesDamageByMax",
                table: "ArtefactItems",
                newName: "ChargeRequiredToActivate");

            migrationBuilder.RenameColumn(
                name: "ReactionToLacerationMin",
                table: "ArtefactItems",
                newName: "CarryWeight");

            migrationBuilder.RenameColumn(
                name: "ReactionToLacerationMax",
                table: "ArtefactItems",
                newName: "BulletResistance");

            migrationBuilder.RenameColumn(
                name: "ReactionToElectricityMin",
                table: "ArtefactItems",
                newName: "Bleeding");

            migrationBuilder.RenameColumn(
                name: "ReactionToElectricityMax",
                table: "ArtefactItems",
                newName: "BiologicalResistance");

            migrationBuilder.RenameColumn(
                name: "ReactionToChemicalBurnsMin",
                table: "ArtefactItems",
                newName: "BiologicalInfection");

            migrationBuilder.RenameColumn(
                name: "ReactionToChemicalBurnsMax",
                table: "ArtefactItems",
                newName: "BioinfectionProtection");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ArtefactItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "SubType",
                table: "ArtefactItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ArtefactItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "ArtefactItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "ArtefactItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
