using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiLPr.Migrations
{
    public partial class RemoveProfileIdFromAppUpser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserPupId",
                table: "Profiles",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserPupId",
                table: "Profiles",
                column: "UserPupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserPupId",
                table: "Profiles",
                column: "UserPupId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserPupId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserPupId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserPupId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
