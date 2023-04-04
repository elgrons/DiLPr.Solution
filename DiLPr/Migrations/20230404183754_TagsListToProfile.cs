using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiLPr.Migrations
{
    public partial class TagsListToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Tags");
        }
    }
}
