using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPanda.Api.Migrations
{
    public partial class TestPandaDbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateBlocked = table.Column<DateTime>(nullable: false),
                    TestUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Block_TestUsers_TestUserId",
                        column: x => x.TestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    TestUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRuns_TestUsers_TestUserId",
                        column: x => x.TestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    TestRunId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "TestUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestRuns_TestRunId",
                        column: x => x.TestRunId,
                        principalTable: "TestRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "TestUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ActiveBlockId = table.Column<int>(nullable: true),
                    TestPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_Block_ActiveBlockId",
                        column: x => x.ActiveBlockId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCases_TestUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "TestUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCases_TestPlans_TestPlanId",
                        column: x => x.TestPlanId,
                        principalTable: "TestPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Block_TestUserId",
                table: "Block",
                column: "TestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_ActiveBlockId",
                table: "TestCases",
                column: "ActiveBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_CreatedById",
                table: "TestCases",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_TestPlanId",
                table: "TestCases",
                column: "TestPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_CreatedById",
                table: "TestPlans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_TestRunId",
                table: "TestPlans",
                column: "TestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_UpdatedById",
                table: "TestPlans",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_TestUserId",
                table: "TestRuns",
                column: "TestUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "TestPlans");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropTable(
                name: "TestUsers");
        }
    }
}
