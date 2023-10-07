using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbAPI.Migrations
{
    /// <inheritdoc />
    public partial class CompanyJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company_job",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    jobDescription = table.Column<string>(type: "TEXT", nullable: false),
                    jobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    companyRefid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_job", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_job_Companii_companyRefid",
                        column: x => x.companyRefid,
                        principalTable: "Companii",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_job_companyRefid",
                table: "company_job",
                column: "companyRefid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company_job");
        }
    }
}
