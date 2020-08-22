using Microsoft.EntityFrameworkCore.Migrations;

namespace EMobile.DB.Migrations
{
    public partial class changedNameToImagesNameToUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "MobileSpecs");

            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "MobileSpecs");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MobileSpecs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "MobileSpecs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MobileSpecs");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "MobileSpecs");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "MobileSpecs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "MobileSpecs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
