using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StefaniniQuiz.DAL.Migrations
{
    public partial class addIsActiveIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Candidates");
        }
    }
}
