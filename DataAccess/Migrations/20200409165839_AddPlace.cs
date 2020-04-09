using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhoods_Districts_DistrictId",
                table: "Neighborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Neighborhoods_DistrictId",
                table: "Neighborhoods");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Neighborhoods");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Neighborhoods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Adverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_PlaceId",
                table: "Neighborhoods",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_PlaceId",
                table: "Adverts",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_DistrictId",
                table: "Places",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Places_PlaceId",
                table: "Adverts",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhoods_Places_PlaceId",
                table: "Neighborhoods",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Places_PlaceId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhoods_Places_PlaceId",
                table: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Neighborhoods_PlaceId",
                table: "Neighborhoods");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_PlaceId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Neighborhoods");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Adverts");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Neighborhoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_DistrictId",
                table: "Neighborhoods",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhoods_Districts_DistrictId",
                table: "Neighborhoods",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
