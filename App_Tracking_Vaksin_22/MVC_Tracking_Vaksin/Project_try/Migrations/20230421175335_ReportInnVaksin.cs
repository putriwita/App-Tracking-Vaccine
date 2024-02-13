using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_try.Migrations
{
    /// <inheritdoc />
    public partial class ReportInnVaksin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "ReportInnVaksin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportInnVaksin",
                table: "ReportInnVaksin",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportInnVaksin",
                table: "ReportInnVaksin");

            migrationBuilder.RenameTable(
                name: "ReportInnVaksin",
                newName: "Report");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "id");
        }
    }
}
