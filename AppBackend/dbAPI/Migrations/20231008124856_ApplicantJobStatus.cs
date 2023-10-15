using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantJobStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "ApplicantJobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "ApplicantJobs");
        }
    }
}
