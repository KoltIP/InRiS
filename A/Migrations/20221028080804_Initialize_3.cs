using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A.Migrations
{
    /// <inheritdoc />
    public partial class Initialize3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_divisions_UpperDivisionName",
                table: "divisions");

            migrationBuilder.DropColumn(
                name: "UpperDivisionName",
                table: "divisions");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_UpperName",
                table: "divisions",
                column: "UpperName");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions",
                column: "UpperName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions");

            migrationBuilder.DropIndex(
                name: "IX_divisions_UpperName",
                table: "divisions");

            migrationBuilder.AddColumn<string>(
                name: "UpperDivisionName",
                table: "divisions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_divisions_UpperDivisionName",
                table: "divisions",
                column: "UpperDivisionName");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperDivisionName",
                table: "divisions",
                column: "UpperDivisionName",
                principalTable: "divisions",
                principalColumn: "Name");
        }
    }
}
