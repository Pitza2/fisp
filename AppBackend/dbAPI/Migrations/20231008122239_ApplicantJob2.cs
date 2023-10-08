using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantJob2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantJobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    company_jobRefid = table.Column<int>(type: "INTEGER", nullable: false),
                    applicantRefid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ApplicantJobs_Applicants_applicantRefid",
                        column: x => x.applicantRefid,
                        principalTable: "Applicants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantJobs_company_jobs_company_jobRefid",
                        column: x => x.company_jobRefid,
                        principalTable: "company_jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobs_applicantRefid",
                table: "ApplicantJobs",
                column: "applicantRefid");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobs_company_jobRefid",
                table: "ApplicantJobs",
                column: "company_jobRefid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJobs");
        }
    }
}
