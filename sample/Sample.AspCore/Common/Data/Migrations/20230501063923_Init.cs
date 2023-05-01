#pragma warning disable IDE0005 // Using directive is unnecessary.
#pragma warning disable IDE0161 // Convert to file-scoped namespace
#pragma warning disable format

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.AspCore.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreationMoment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateMoment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}

#pragma warning restore format
#pragma warning restore IDE0161 // Convert to file-scoped namespace
#pragma warning restore IDE0005 // Using directive is unnecessary.
