using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_try.Migrations
{
    /// <inheritdoc />
    public partial class ReportUseVaksin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportUseVaksin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_rumah_sakit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_patient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_vaksin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time_vaksin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUseVaksin", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportUseVaksin");
        }
    }
}
