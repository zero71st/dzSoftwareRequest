using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace dz.SoftwareRequest.Migrations
{
    public partial class request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevelopTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionBy = table.Column<string>(type: "TEXT", nullable: true),
                    AttrachFile = table.Column<string>(type: "TEXT", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Holiday = table.Column<int>(type: "INTEGER", nullable: false),
                    Manday = table.Column<int>(type: "INTEGER", nullable: false),
                    Remark = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApprovedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ApprovedProjectBy = table.Column<string>(type: "TEXT", nullable: true),
                    CodeReviewId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeploymentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    DevelopmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    DocNo = table.Column<string>(type: "TEXT", nullable: true),
                    MeetingDate = table.Column<string>(type: "TEXT", nullable: true),
                    MeetingRemark = table.Column<string>(type: "TEXT", nullable: true),
                    RequestBy = table.Column<string>(type: "TEXT", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SecurityTestId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    UATId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_DevelopTask_CodeReviewId",
                        column: x => x.CodeReviewId,
                        principalTable: "DevelopTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_DevelopTask_DeploymentId",
                        column: x => x.DeploymentId,
                        principalTable: "DevelopTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_DevelopTask_DevelopmentId",
                        column: x => x.DevelopmentId,
                        principalTable: "DevelopTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_DevelopTask_SecurityTestId",
                        column: x => x.SecurityTestId,
                        principalTable: "DevelopTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_DevelopTask_UATId",
                        column: x => x.UATId,
                        principalTable: "DevelopTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CodeReviewId",
                table: "Requests",
                column: "CodeReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeploymentId",
                table: "Requests",
                column: "DeploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DevelopmentId",
                table: "Requests",
                column: "DevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SecurityTestId",
                table: "Requests",
                column: "SecurityTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UATId",
                table: "Requests",
                column: "UATId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "DevelopTask");
        }
    }
}
