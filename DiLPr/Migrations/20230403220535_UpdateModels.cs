using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiLPr.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Join_AspNetUsers_AppUserId",
                table: "Join");

            migrationBuilder.DropIndex(
                name: "IX_Join_AppUserId",
                table: "Join");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Join");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserPupprId",
                table: "Join",
                newName: "ProfilePupprId");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Profiles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Join",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Join_ProfileId",
                table: "Join",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Join_Profiles_ProfileId",
                table: "Join",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Join_Profiles_ProfileId",
                table: "Join");

            migrationBuilder.DropIndex(
                name: "IX_Join_ProfileId",
                table: "Join");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Join");

            migrationBuilder.RenameColumn(
                name: "ProfilePupprId",
                table: "Join",
                newName: "AppUserPupprId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Join",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Join_AppUserId",
                table: "Join",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Join_AspNetUsers_AppUserId",
                table: "Join",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
