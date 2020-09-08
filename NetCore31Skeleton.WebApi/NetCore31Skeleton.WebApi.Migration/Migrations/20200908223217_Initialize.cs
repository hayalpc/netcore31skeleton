using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCore31Skeleton.WebApi.MigrationTool.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AppRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "varchar", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 64, nullable: false),
                    Username = table.Column<string>(type: "varchar", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "varchar", maxLength: 128, nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Application = table.Column<string>(nullable: true),
                    Logged = table.Column<DateTime>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    CallSite = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    TraceId = table.Column<string>(maxLength: 128, nullable: true),
                    SessionId = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    MerchantId = table.Column<long>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false),
                    OperatorId = table.Column<long>(nullable: false),
                    Msisdn = table.Column<string>(type: "varchar", maxLength: 16, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ChargeDate = table.Column<DateTime>(nullable: true),
                    Item = table.Column<string>(type: "varchar", maxLength: 64, nullable: false),
                    RefundDate = table.Column<DateTime>(nullable: true),
                    RefundSource = table.Column<string>(type: "varchar", maxLength: 64, nullable: true),
                    OperatorTransId = table.Column<string>(type: "varchar", maxLength: 64, nullable: true),
                    OrderId = table.Column<string>(type: "varchar", maxLength: 64, nullable: true),
                    UserIp = table.Column<string>(type: "varchar", maxLength: 32, nullable: true),
                    Channel = table.Column<string>(type: "varchar", maxLength: 32, nullable: true),
                    Error = table.Column<string>(type: "varchar", maxLength: 128, nullable: true),
                    ErrDesc = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    SubId = table.Column<long>(nullable: true),
                    Guid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false),
                    AppRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRole_AppRoleId",
                        column: x => x.AppRoleId,
                        principalSchema: "dbo",
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "dbo",
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_AppRoleId",
                schema: "dbo",
                table: "AppUserRole",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_AppUserId",
                schema: "dbo",
                table: "AppUserRole",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CategoryId",
                schema: "dbo",
                table: "Note",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Log",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Note",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AppUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
