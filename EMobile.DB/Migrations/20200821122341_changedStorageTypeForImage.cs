using Microsoft.EntityFrameworkCore.Migrations;

namespace EMobile.DB.Migrations
{
    public partial class changedStorageTypeForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "MobileSpecs");

            migrationBuilder.DropColumn(
                name: "VideoPath",
                table: "MobileSpecs");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "MobileSpecs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "MobileSpecs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "MobileSpecs");

            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "MobileSpecs");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "MobileSpecs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoPath",
                table: "MobileSpecs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
