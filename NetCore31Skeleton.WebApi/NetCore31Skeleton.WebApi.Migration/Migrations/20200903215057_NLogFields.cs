using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore31Skeleton.WebApi.MigrationTool.Migrations
{
    public partial class NLogFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                schema: "dbo",
                table: "Log",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TraceId",
                schema: "dbo",
                table: "Log",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "dbo",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "TraceId",
                schema: "dbo",
                table: "Log");
        }
    }
}
