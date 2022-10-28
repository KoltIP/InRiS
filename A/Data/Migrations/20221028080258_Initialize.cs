using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UpperName = table.Column<string>(type: "text", nullable: false),
                    UpperDivisionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_divisions_divisions_UpperDivisionName",
                        column: x => x.UpperDivisionName,
                        principalTable: "divisions",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_divisions_Name",
                table: "divisions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_divisions_UpperDivisionName",
                table: "divisions",
                column: "UpperDivisionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "divisions");
        }
    }
}
