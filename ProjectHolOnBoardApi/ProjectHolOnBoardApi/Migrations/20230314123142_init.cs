using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHolOnBoardApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anchor",
                columns: table => new
                {
                    id_anchor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_string_anchor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place_anchor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description_place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anchor", x => x.id_anchor);
                });

            migrationBuilder.CreateTable(
                name: "Circuit",
                columns: table => new
                {
                    id_circuit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_circuit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description_circuit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuit", x => x.id_circuit);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    id_stage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description_stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_circuit = table.Column<int>(type: "int", nullable: false),
                    id_Anchor = table.Column<int>(type: "int", nullable: false),
                    Circuitid_circuit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.id_stage);
                    table.ForeignKey(
                        name: "FK_Stage_Anchor_id_Anchor",
                        column: x => x.id_Anchor,
                        principalTable: "Anchor",
                        principalColumn: "id_anchor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stage_Circuit_Circuitid_circuit",
                        column: x => x.Circuitid_circuit,
                        principalTable: "Circuit",
                        principalColumn: "id_circuit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stage_Circuitid_circuit",
                table: "Stage",
                column: "Circuitid_circuit");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_id_Anchor",
                table: "Stage",
                column: "id_Anchor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Anchor");

            migrationBuilder.DropTable(
                name: "Circuit");
        }
    }
}
