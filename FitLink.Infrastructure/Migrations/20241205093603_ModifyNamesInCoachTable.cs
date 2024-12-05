using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitLink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyNamesInCoachTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Coaches",
                newName: "Updated_Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Coaches",
                newName: "Created_Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_Date",
                table: "Coaches",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "Coaches",
                newName: "CreatedDate");
        }
    }
}
