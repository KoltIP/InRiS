using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A.Migrations
{
    /// <inheritdoc />
    public partial class Initialize8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions");

            migrationBuilder.RenameColumn(
                name: "UpperName",
                table: "divisions",
                newName: "ParentName");

            migrationBuilder.RenameIndex(
                name: "IX_divisions_UpperName",
                table: "divisions",
                newName: "IX_divisions_ParentName");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_ParentName",
                table: "divisions",
                column: "ParentName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divisions_divisions_ParentName",
                table: "divisions");

            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "divisions",
                newName: "UpperName");

            migrationBuilder.RenameIndex(
                name: "IX_divisions_ParentName",
                table: "divisions",
                newName: "IX_divisions_UpperName");

            migrationBuilder.AddForeignKey(
                name: "FK_divisions_divisions_UpperName",
                table: "divisions",
                column: "UpperName",
                principalTable: "divisions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
