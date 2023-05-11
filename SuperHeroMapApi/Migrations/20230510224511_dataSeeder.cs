using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroMapApi.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insérer les IncidentResources
            migrationBuilder.InsertData(
                table: "IncidentResources",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
            { 1, "Incendie" },
            { 2, "Accident routier" },
            { 3, "Accident fluviale" },
            { 4, "Accident aérien" },
            { 5, "Eboulement" },
            { 6, "Invasion de serpent" },
            { 7, "Fuite de gaz" },
            { 8, "Manifestation" },
            { 9, "Braquage" },
            { 10, "Evasion d’un prisonnier" },
                });

            // Insérer des SuperHeroes
            migrationBuilder.InsertData(
                table: "SuperHeroes",
                columns: new[] { "Id", "Name", "Latitude", "Longitude", "PhoneNumber" },
                values: new object[,]
                {
            { 1, "Superman", 48.8566, 2.3522, "0123456789" },
            { 2, "Batman", 40.7128, -74.0060, "0987654321" },
            { 3, "Wonder Woman", 37.7749, -122.4194, "1122334455" }
                });

            // Insérer des SuperHeroIncidentResources
            migrationBuilder.InsertData(
                table: "SuperHeroIncidentResources",
                columns: new[] { "Id", "SuperHeroId", "IncidentResourceId" },
                values: new object[,]
                {
            { 1, 1, 1 },
            { 2, 2, 2 },
            { 3, 3, 3 }
                });

            // Insérer des Incidents
            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "IncidentResourceId", "CityName", "Latitude", "Longitude", "IsResolved" },
                values: new object[,]
                {
            { 1, 1, "Paris", 48.8566, 2.3522, false },
            { 2, 2, "New York", 40.7128, -74.0060, false },
            { 3, 3, "San Francisco", 37.7749, -122.4194, false }
                });

            // Insérer des SuperHeroIncidents
            migrationBuilder.InsertData(
                table: "SuperHeroIncidents",
                columns: new[] { "Id", "SuperHeroId", "IncidentId" },
                values: new object[,]
                {
            { 1, 1, 1 },
            { 2, 2, 2 },
            { 3, 3, 3 }
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Supprimer les SuperHeroIncidents
            migrationBuilder.DeleteData(
                table: "SuperHeroIncidents",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Supprimer les Incidents
            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Supprimer les SuperHeroIncidentResources
            migrationBuilder.DeleteData(
                table: "SuperHeroIncidentResources",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Supprimer les SuperHeroes
            migrationBuilder.DeleteData(
                table: "SuperHeroes",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });

            // Supprimer les IncidentResources
            migrationBuilder.DeleteData(
                table: "IncidentResources",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

    }
}
