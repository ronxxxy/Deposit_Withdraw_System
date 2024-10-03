using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewPro.Migrations
{
    /// <inheritdoc />
    public partial class SixthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderAccType",
                table: "withdraw",
                type: "longtext",
                nullable: false,
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<string>(
                name: "SenderBankName",
                table: "withdraw",
                type: "longtext",
                nullable: false,
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderAccType",
                table: "withdraw");

            migrationBuilder.DropColumn(
                name: "SenderBankName",
                table: "withdraw");
        }
    }
}
