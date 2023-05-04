using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SuperHeroMapApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    IncidentResourceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentResources_IncidentResourceId",
                        column: x => x.IncidentResourceId,
                        principalTable: "IncidentResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroIncidentResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SuperHeroId = table.Column<int>(type: "integer", nullable: false),
                    ResourceId = table.Column<int>(type: "integer", nullable: false),
                    IncidentResourceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroIncidentResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroIncidentResources_IncidentResources_IncidentResour~",
                        column: x => x.IncidentResourceId,
                        principalTable: "IncidentResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperHeroIncidentResources_SuperHeros_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperHeroIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SuperHeroId = table.Column<int>(type: "integer", nullable: false),
                    IncidentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroIncidents_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperHeroIncidents_SuperHeros_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentResourceId",
                table: "Incidents",
                column: "IncidentResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroIncidentResources_IncidentResourceId",
                table: "SuperHeroIncidentResources",
                column: "IncidentResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroIncidentResources_SuperHeroId",
                table: "SuperHeroIncidentResources",
                column: "SuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroIncidents_IncidentId",
                table: "SuperHeroIncidents",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroIncidents_SuperHeroId",
                table: "SuperHeroIncidents",
                column: "SuperHeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroIncidentResources");

            migrationBuilder.DropTable(
                name: "SuperHeroIncidents");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "SuperHeros");

            migrationBuilder.DropTable(
                name: "IncidentResources");
        }
    }
}
