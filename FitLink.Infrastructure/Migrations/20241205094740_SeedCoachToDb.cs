using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitLink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoachToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Contact", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Updated_Date" },
                values: new object[,]
                {
                    { 1, "alex.johnson@fitlink.com", null, "Certified Personal Trainer specializing in strength training and HIIT workouts.", "https://via.placeholder.com/150", "Alex Johnson", 5, 50.0, null },
                    { 2, "maria.lopez@fitlink.com", null, "Yoga instructor with 10 years of experience in Vinyasa and Hatha yoga.", "https://via.placeholder.com/150", "Maria Lopez", 8, 60.0, null },
                    { 3, "david.kim@fitlink.com", null, "Nutritionist and fitness coach focusing on holistic health and wellness.", "https://via.placeholder.com/150", "David Kim", 10, 70.0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
