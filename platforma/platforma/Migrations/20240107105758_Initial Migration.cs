using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace platforma.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailableForAdoption = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostAnimals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAnimals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalPostAnimal",
                columns: table => new
                {
                    AnimalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostAnimalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalPostAnimal", x => new { x.AnimalsId, x.PostAnimalsId });
                    table.ForeignKey(
                        name: "FK_AnimalPostAnimal_Animals_AnimalsId",
                        column: x => x.AnimalsId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalPostAnimal_PostAnimals_PostAnimalsId",
                        column: x => x.PostAnimalsId,
                        principalTable: "PostAnimals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalPostAnimal_PostAnimalsId",
                table: "AnimalPostAnimal",
                column: "PostAnimalsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalPostAnimal");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "PostAnimals");
        }
    }
}
