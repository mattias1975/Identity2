using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Options",
                table: "People",
                newName: "UserEmail");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "People",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "People",
                newName: "Options");
        }
    }
}
