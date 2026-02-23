using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AcMissionsApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedMissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Missions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Id", "CreatedAt", "Name", "Region" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(784), "Assassins", "Moyen-Orient" },
                    { 2, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(1451), "Templiers", "Europe" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "CreatedAt", "Description", "Difficulty", "Location", "Reward", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(6202), "Altaïr doit infiltrer Acre pour éliminer Garnier de Naplouse.", "Difficile", "Acre", null, "La Croisade du Roi Richard", null },
                    { 2, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(6943), "Ezio élimine les lieutenants de Savonarole à Florence.", "Moyenne", "Florence", null, "Le Procès de Savonarole", null },
                    { 3, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(6951), "Connor poursuit Charles Lee à New York.", "Difficile", "New York", null, "La Traque de Charles Lee", null },
                    { 4, new DateTime(2026, 2, 23, 9, 29, 2, 700, DateTimeKind.Local).AddTicks(6954), "Bayek infiltre une réception pour Cléopâtre.", "Facile", "Alexandrie", null, "Le Banquet de Cléopâtre", null }
                });

            migrationBuilder.InsertData(
                table: "MissionFactions",
                columns: new[] { "Id", "FactionId", "MissionId" },
                values: new object[,]
                {
                    { -4, 1, 4 },
                    { -3, 1, 3 },
                    { -2, 1, 2 },
                    { -1, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MissionFactions",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "MissionFactions",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "MissionFactions",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "MissionFactions",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Missions");
        }
    }
}
