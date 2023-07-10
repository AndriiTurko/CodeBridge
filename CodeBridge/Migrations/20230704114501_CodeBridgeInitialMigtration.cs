using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBridge.Migrations
{
    /// <inheritdoc />
    public partial class CodeBridgeInitialMigtration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Dogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    TailLength = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs",
                schema: "dbo");
        }
    }
}
