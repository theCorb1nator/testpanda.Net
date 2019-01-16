using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPanda.Api.Migrations
{
    public partial class TestPandaInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestUsers",
                columns: table => new
                {
                    TestUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestUsers", x => x.TestUserId);
                });

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    TestRunId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    TesterTestUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.TestRunId);
                    table.ForeignKey(
                        name: "FK_TestRuns_TestUsers_TesterTestUserId",
                        column: x => x.TesterTestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "TestUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestPlans",
                columns: table => new
                {
                    TestPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AuthorTestUserId = table.Column<int>(nullable: true),
                    UpdatedByTestUserId = table.Column<int>(nullable: true),
                    TestRunId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPlans", x => x.TestPlanId);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestUsers_AuthorTestUserId",
                        column: x => x.AuthorTestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "TestUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestRuns_TestRunId",
                        column: x => x.TestRunId,
                        principalTable: "TestRuns",
                        principalColumn: "TestRunId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestPlans_TestUsers_UpdatedByTestUserId",
                        column: x => x.UpdatedByTestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "TestUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    TestCaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    AuthorTestUserId = table.Column<int>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    TestPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.TestCaseId);
                    table.ForeignKey(
                        name: "FK_TestCases_TestUsers_AuthorTestUserId",
                        column: x => x.AuthorTestUserId,
                        principalTable: "TestUsers",
                        principalColumn: "TestUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCases_TestPlans_TestPlanId",
                        column: x => x.TestPlanId,
                        principalTable: "TestPlans",
                        principalColumn: "TestPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_AuthorTestUserId",
                table: "TestCases",
                column: "AuthorTestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_TestPlanId",
                table: "TestCases",
                column: "TestPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_AuthorTestUserId",
                table: "TestPlans",
                column: "AuthorTestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_TestRunId",
                table: "TestPlans",
                column: "TestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlans_UpdatedByTestUserId",
                table: "TestPlans",
                column: "UpdatedByTestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_TesterTestUserId",
                table: "TestRuns",
                column: "TesterTestUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "TestPlans");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropTable(
                name: "TestUsers");
        }
    }
}
