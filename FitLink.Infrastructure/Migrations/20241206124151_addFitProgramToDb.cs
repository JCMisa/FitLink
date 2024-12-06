using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitLink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFitProgramToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitPrograms_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FitPrograms",
                columns: new[] { "Id", "CoachId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Strength Training Basics" },
                    { 2, 3, null, "Advanced Cardio Workouts" },
                    { 3, 4, null, "Yoga for Beginners" },
                    { 4, 8, null, "HIIT and Fat Loss" },
                    { 5, 1, null, "Holistic Wellness Plan" },
                    { 6, 3, null, "Endurance Building" },
                    { 7, 4, null, "Flexibility and Mobility" },
                    { 8, 5, null, "Nutritional Guidance" },
                    { 9, 8, null, "Strength and Conditioning" },
                    { 10, 3, null, "Meditation and Relaxation" },
                    { 11, 4, null, "Boot Camp Intensive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitPrograms_CoachId",
                table: "FitPrograms",
                column: "CoachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitPrograms");
        }
    }
}
