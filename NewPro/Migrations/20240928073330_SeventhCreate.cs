using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewPro.Migrations
{
    /// <inheritdoc />
    public partial class SeventhCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "to",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "proof",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "acc_type",
                table: "withdraw",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "withdraw",
                keyColumn: "to",
                keyValue: null,
                column: "to",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "to",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.UpdateData(
                table: "withdraw",
                keyColumn: "proof",
                keyValue: null,
                column: "proof",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "proof",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.UpdateData(
                table: "withdraw",
                keyColumn: "bank_name",
                keyValue: null,
                column: "bank_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "bank_name",
                table: "withdraw",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "''",
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValueSql: "''")
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "acc_type",
                table: "withdraw",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);
        }
    }
}
