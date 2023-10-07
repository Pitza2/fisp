using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbAPI.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_job_Companii_companyRefid",
                table: "company_job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_job",
                table: "company_job");

            migrationBuilder.RenameTable(
                name: "company_job",
                newName: "company_jobs");

            migrationBuilder.RenameIndex(
                name: "IX_company_job_companyRefid",
                table: "company_jobs",
                newName: "IX_company_jobs_companyRefid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_jobs",
                table: "company_jobs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_company_jobs_Companii_companyRefid",
                table: "company_jobs",
                column: "companyRefid",
                principalTable: "Companii",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_jobs_Companii_companyRefid",
                table: "company_jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_jobs",
                table: "company_jobs");

            migrationBuilder.RenameTable(
                name: "company_jobs",
                newName: "company_job");

            migrationBuilder.RenameIndex(
                name: "IX_company_jobs_companyRefid",
                table: "company_job",
                newName: "IX_company_job_companyRefid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_job",
                table: "company_job",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_company_job_Companii_companyRefid",
                table: "company_job",
                column: "companyRefid",
                principalTable: "Companii",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
