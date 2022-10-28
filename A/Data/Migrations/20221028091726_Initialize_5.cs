using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A.Migrations
{
    /// <inheritdoc />
    public partial class Initialize5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions",
                column: "UpperName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions",
                column: "UpperName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
