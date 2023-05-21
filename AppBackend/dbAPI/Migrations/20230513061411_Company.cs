using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dbAPI.Migrations
{
    /// <inheritdoc />
    public partial class Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Companii",
                table: "Companii");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Companii",
                newName: "password");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Companii",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companii",
                table: "Companii",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Companii",
                table: "Companii");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Companii");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Companii",
                newName: "address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companii",
                table: "Companii",
                column: "name");
        }
    }
}
