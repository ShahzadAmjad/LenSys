using Microsoft.EntityFrameworkCore.Migrations;

namespace LenSys.Migrations
{
    public partial class UpdteProprtyFinac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPropertyFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPropertyFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppPropertyFinanceIndividual_individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppPropertyFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess");

            migrationBuilder.DropColumn(
                name: "individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual");

            migrationBuilder.DropColumn(
                name: "busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess");

            migrationBuilder.AddColumn<int>(
                name: "AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDocuments_AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppPropertyFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessDocuments_AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppPropertyFinanceBusniessBusniessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusniessDocuments_AppPropertyFinanceBusniess_AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppPropertyFinanceBusniessBusniessId",
                principalTable: "AppPropertyFinanceBusniess",
                principalColumn: "BusniessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDocuments_AppPropertyFinanceIndividual_AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppPropertyFinanceIndividualIndividualId",
                principalTable: "AppPropertyFinanceIndividual",
                principalColumn: "IndividualId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusniessDocuments_AppPropertyFinanceBusniess_AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDocuments_AppPropertyFinanceIndividual_AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_IndividualDocuments_AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_BusniessDocuments_AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "AppPropertyFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "AppPropertyFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.AddColumn<int>(
                name: "individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPropertyFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess",
                column: "busniessDocumentsDocumentId",
                principalTable: "BusniessDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPropertyFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual",
                column: "individualDocumentsDocumentId",
                principalTable: "IndividualDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
