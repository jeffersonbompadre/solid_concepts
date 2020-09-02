using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidateTesting.JeffersonBompadre.AdjacentMaxDistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ValueArray",
                columns: table => new
                {
                    Value_Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value_Array = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ValueArray", x => x.Value_Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Indice",
                columns: table => new
                {
                    Indice_Id = table.Column<int>(nullable: false),
                    Value_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Indice", x => x.Indice_Id);
                    table.ForeignKey(
                        name: "FK_Indice_ValueArray",
                        column: x => x.Value_Id,
                        principalTable: "TBL_ValueArray",
                        principalColumn: "Value_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_Indice_Value_Id",
                table: "TBL_Indice",
                column: "Value_Id");

            migrationBuilder.CreateIndex(
                name: "IDX_Value",
                table: "TBL_ValueArray",
                column: "Value_Array",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Indice");

            migrationBuilder.DropTable(
                name: "TBL_ValueArray");
        }
    }
}
