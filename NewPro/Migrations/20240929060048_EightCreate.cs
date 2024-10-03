using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewPro.Migrations
{
    /// <inheritdoc />
    public partial class EightCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "withdraw",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "pendingusers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "deposit",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "withdraw",
                keyColumn: "user_id",
                keyValue: null,
                column: "user_id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "withdraw",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.UpdateData(
                table: "pendingusers",
                keyColumn: "user_id",
                keyValue: null,
                column: "user_id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "pendingusers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.UpdateData(
                table: "deposit",
                keyColumn: "user_id",
                keyValue: null,
                column: "user_id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "deposit",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");
        }
    }
}
