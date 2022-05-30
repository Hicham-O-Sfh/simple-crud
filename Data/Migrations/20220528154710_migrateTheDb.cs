using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_crud.Data.Migrations
{
    public partial class migrateTheDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoyenneGenerale = table.Column<double>(type: "float", nullable: false),
                    IsExclut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "Id", "DateNaissance", "IsExclut", "MoyenneGenerale", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 28, 15, 47, 10, 762, DateTimeKind.Local).AddTicks(5307), false, 17.5, "nom_1", "prenom_1" },
                    { 2, new DateTime(2022, 5, 28, 15, 47, 10, 762, DateTimeKind.Local).AddTicks(5329), false, 16.5, "nom_2", "prenom_2" },
                    { 3, new DateTime(2022, 5, 28, 15, 47, 10, 762, DateTimeKind.Local).AddTicks(5330), false, 15.5, "nom_3", "prenom_3" },
                    { 4, new DateTime(2022, 5, 28, 15, 47, 10, 762, DateTimeKind.Local).AddTicks(5331), false, 14.5, "nom_4", "prenom_4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
