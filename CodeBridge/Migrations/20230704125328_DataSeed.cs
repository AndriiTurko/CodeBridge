using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeBridge.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Dogs",
                schema: "dbo",
                newName: "Dogs");

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Color", "Name", "TailLength", "Weight" },
                values: new object[,]
                {
                    { new Guid("cd82410c-ff48-4156-8429-8aa790e98a97"), "red & amber", "Neo", 22, 32 },
                    { new Guid("f3d2044d-9811-4e1f-8d72-4241c0cb2dd7"), "black & white", "Jessy", 7, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("cd82410c-ff48-4156-8429-8aa790e98a97"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: new Guid("f3d2044d-9811-4e1f-8d72-4241c0cb2dd7"));

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Dogs",
                newName: "Dogs",
                newSchema: "dbo");
        }
    }
}
