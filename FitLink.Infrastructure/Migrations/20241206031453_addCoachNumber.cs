using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitLink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCoachNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coaches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CoachNumbers",
                columns: table => new
                {
                    Coach_Number = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachNumbers", x => x.Coach_Number);
                    table.ForeignKey(
                        name: "FK_CoachNumbers_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoachNumbers",
                columns: new[] { "Coach_Number", "CoachId", "SpecialDetails" },
                values: new object[,]
                {
                    { 101, 1, null },
                    { 102, 1, null },
                    { 103, 3, null },
                    { 201, 3, null },
                    { 202, 4, null },
                    { 203, 4, null },
                    { 301, 4, null },
                    { 302, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachNumbers_CoachId",
                table: "CoachNumbers",
                column: "CoachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
