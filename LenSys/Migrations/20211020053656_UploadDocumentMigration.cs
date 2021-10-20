using Microsoft.EntityFrameworkCore.Migrations;

namespace LenSys.Migrations
{
    public partial class UploadDocumentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAssetFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess");

            migrationBuilder.DropForeignKey(
                name: "FK_AppAssetFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual");

            migrationBuilder.DropForeignKey(
                name: "FK_AppBusniessFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess");

            migrationBuilder.DropForeignKey(
                name: "FK_AppBusniessFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDevelopmentFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDevelopmentFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppDevelopmentFinanceIndividual_individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppDevelopmentFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess");

            migrationBuilder.DropIndex(
                name: "IX_AppBusniessFinanceIndividual_individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppBusniessFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess");

            migrationBuilder.DropIndex(
                name: "IX_AppAssetFinanceIndividual_individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual");

            migrationBuilder.DropIndex(
                name: "IX_AppAssetFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess");

            migrationBuilder.DropColumn(
                name: "individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual");

            migrationBuilder.DropColumn(
                name: "busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "AppDevelopmentFinance");

            migrationBuilder.DropColumn(
                name: "individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual");

            migrationBuilder.DropColumn(
                name: "busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "AppBusniessFinance");

            migrationBuilder.DropColumn(
                name: "individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual");

            migrationBuilder.DropColumn(
                name: "busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess");

            migrationBuilder.AddColumn<int>(
                name: "AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "IndividualDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentGuid",
                table: "IndividualDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "IndividualDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndividualId",
                table: "IndividualDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "BusniessDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusniessId",
                table: "BusniessDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentGuid",
                table: "BusniessDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDocuments_AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppAssetFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDocuments_AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppBusniessFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDocuments_AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppDevelopmentFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessDocuments_AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppAssetFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessDocuments_AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppBusniessFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessDocuments_AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppDevelopmentFinanceBusniessBusniessId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusniessDocuments_AppAssetFinanceBusniess_AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppAssetFinanceBusniessBusniessId",
                principalTable: "AppAssetFinanceBusniess",
                principalColumn: "BusniessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusniessDocuments_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppBusniessFinanceBusniessBusniessId",
                principalTable: "AppBusniessFinanceBusniess",
                principalColumn: "BusniessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusniessDocuments_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments",
                column: "AppDevelopmentFinanceBusniessBusniessId",
                principalTable: "AppDevelopmentFinanceBusniess",
                principalColumn: "BusniessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDocuments_AppAssetFinanceIndividual_AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppAssetFinanceIndividualIndividualId",
                principalTable: "AppAssetFinanceIndividual",
                principalColumn: "IndividualId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDocuments_AppBusniessFinanceIndividual_AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppBusniessFinanceIndividualIndividualId",
                principalTable: "AppBusniessFinanceIndividual",
                principalColumn: "IndividualId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualDocuments_AppDevelopmentFinanceIndividual_AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments",
                column: "AppDevelopmentFinanceIndividualIndividualId",
                principalTable: "AppDevelopmentFinanceIndividual",
                principalColumn: "IndividualId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusniessDocuments_AppAssetFinanceBusniess_AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_BusniessDocuments_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_BusniessDocuments_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDocuments_AppAssetFinanceIndividual_AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDocuments_AppBusniessFinanceIndividual_AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualDocuments_AppDevelopmentFinanceIndividual_AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_IndividualDocuments_AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_IndividualDocuments_AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_IndividualDocuments_AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropIndex(
                name: "IX_BusniessDocuments_AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropIndex(
                name: "IX_BusniessDocuments_AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropIndex(
                name: "IX_BusniessDocuments_AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "AppAssetFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "AppBusniessFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "AppDevelopmentFinanceIndividualIndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentGuid",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "IndividualId",
                table: "IndividualDocuments");

            migrationBuilder.DropColumn(
                name: "AppAssetFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "AppBusniessFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "BusniessId",
                table: "BusniessDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentGuid",
                table: "BusniessDocuments");

            migrationBuilder.AddColumn<int>(
                name: "individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationType",
                table: "AppDevelopmentFinance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationType",
                table: "AppBusniessFinance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAssetFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess",
                column: "busniessDocumentsDocumentId",
                principalTable: "BusniessDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppAssetFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual",
                column: "individualDocumentsDocumentId",
                principalTable: "IndividualDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppBusniessFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess",
                column: "busniessDocumentsDocumentId",
                principalTable: "BusniessDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppBusniessFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual",
                column: "individualDocumentsDocumentId",
                principalTable: "IndividualDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDevelopmentFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess",
                column: "busniessDocumentsDocumentId",
                principalTable: "BusniessDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDevelopmentFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual",
                column: "individualDocumentsDocumentId",
                principalTable: "IndividualDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
