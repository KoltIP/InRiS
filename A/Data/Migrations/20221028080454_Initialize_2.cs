using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A.Migrations
{
    /// <inheritdoc />
    public partial class Initialize2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions");

            migrationBuilder.AlterColumn<string>(
                name: "UpperDivisionName",
                table: "divisions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions",
                column: "UpperDivisionName",
                principalTable: "divisions",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions");

            migrationBuilder.AlterColumn<string>(
                name: "UpperDivisionName",
                table: "divisions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions",
                column: "UpperDivisionName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
