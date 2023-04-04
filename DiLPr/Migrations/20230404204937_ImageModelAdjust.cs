using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiLPr.Migrations
{
    public partial class ImageModelAdjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }
    }
}
