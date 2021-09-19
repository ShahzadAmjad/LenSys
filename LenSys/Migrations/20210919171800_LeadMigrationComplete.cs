using Microsoft.EntityFrameworkCore.Migrations;

namespace LenSys.Migrations
{
    public partial class LeadMigrationComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "AppPropertyFinance",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "AppDevelopmentFinance",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "AppBusniessFinance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinance_LeadId",
                table: "AppPropertyFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinance_LeadId",
                table: "AppDevelopmentFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinance_LeadId",
                table: "AppBusniessFinance",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBusniessFinance_Lead_LeadId",
                table: "AppBusniessFinance",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDevelopmentFinance_Lead_LeadId",
                table: "AppDevelopmentFinance",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPropertyFinance_Lead_LeadId",
                table: "AppPropertyFinance",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBusniessFinance_Lead_LeadId",
                table: "AppBusniessFinance");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDevelopmentFinance_Lead_LeadId",
                table: "AppDevelopmentFinance");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPropertyFinance_Lead_LeadId",
                table: "AppPropertyFinance");

            migrationBuilder.DropIndex(
                name: "IX_AppPropertyFinance_LeadId",
                table: "AppPropertyFinance");

            migrationBuilder.DropIndex(
                name: "IX_AppDevelopmentFinance_LeadId",
                table: "AppDevelopmentFinance");

            migrationBuilder.DropIndex(
                name: "IX_AppBusniessFinance_LeadId",
                table: "AppBusniessFinance");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "AppPropertyFinance");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "AppDevelopmentFinance");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "AppBusniessFinance");
        }
    }
}
