using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LenSys.Migrations
{
    public partial class MigrationAllFourApps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBusniessFinance",
                columns: table => new
                {
                    BusniessFinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfFinance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountOfFinance = table.Column<int>(type: "int", nullable: false),
                    RepaymentTermMonths = table.Column<int>(type: "int", nullable: false),
                    BrokerFee = table.Column<int>(type: "int", nullable: false),
                    SecurityOffered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCA_RegulatedLoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillApplicantOrFamilyMemOwn40PercentOfSecurityatmortgageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EverLivedinThisProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantPhoneNo = table.Column<int>(type: "int", nullable: false),
                    AccountantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBusniessFinance", x => x.BusniessFinId);
                });

            migrationBuilder.CreateTable(
                name: "AppDevelopmentFinance",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    MarketValueOfLand = table.Column<int>(type: "int", nullable: false),
                    ConstructionCost = table.Column<int>(type: "int", nullable: false),
                    TotalDevelopmentCost = table.Column<int>(type: "int", nullable: false),
                    GrossDevelopmentValue = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<int>(type: "int", nullable: false),
                    LoanTermMonths = table.Column<int>(type: "int", nullable: false),
                    AmountOfExistingLoanToBe = table.Column<int>(type: "int", nullable: false),
                    TargetCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceOfDeposit = table.Column<int>(type: "int", nullable: false),
                    ExistStrategy = table.Column<int>(type: "int", nullable: false),
                    Demolition = table.Column<int>(type: "int", nullable: false),
                    MaterialsCost = table.Column<int>(type: "int", nullable: false),
                    GasInstallation = table.Column<int>(type: "int", nullable: false),
                    ElectricInstallation = table.Column<int>(type: "int", nullable: false),
                    WaterInstallation = table.Column<int>(type: "int", nullable: false),
                    LandScapingCost = table.Column<int>(type: "int", nullable: false),
                    Labour = table.Column<int>(type: "int", nullable: false),
                    CIL = table.Column<int>(type: "int", nullable: false),
                    Insert1 = table.Column<int>(type: "int", nullable: false),
                    Insert2 = table.Column<int>(type: "int", nullable: false),
                    Insert3 = table.Column<int>(type: "int", nullable: false),
                    Insert4 = table.Column<int>(type: "int", nullable: false),
                    StampDuty = table.Column<int>(type: "int", nullable: false),
                    LegalFees = table.Column<int>(type: "int", nullable: false),
                    OtherCostFinance = table.Column<int>(type: "int", nullable: false),
                    TotalCosts = table.Column<int>(type: "int", nullable: false),
                    EstateAgentFees = table.Column<int>(type: "int", nullable: false),
                    SellingCosts_LegalFees = table.Column<int>(type: "int", nullable: false),
                    SellingCosts_Insert1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingCosts_Insert2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellingCosts_Total = table.Column<int>(type: "int", nullable: false),
                    Acquistion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlainingPermission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlainingConditions = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartConstruction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildingSignOff = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleLetWholeBuilding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DetailsOfPlainingPermission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsOfBuildersContrators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FCA_RegulatedLoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillApplicantOrFamilyMemOwn40PercentOfSecurityatmortgageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EverLivedinThisProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevelopmentFinance", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "AppPropertyFinance",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmount = table.Column<int>(type: "int", nullable: false),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepaymentTermMonths = table.Column<int>(type: "int", nullable: false),
                    TargetCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrokerFee = table.Column<int>(type: "int", nullable: false),
                    SourceOfDeposit = table.Column<int>(type: "int", nullable: false),
                    FCA_RegulatedLoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WillApplicantOrFamilyMemOwn40PercentOfSecurityatmortgageTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EverLivedinThisProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantPhoneNo = table.Column<int>(type: "int", nullable: false),
                    AccountantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountantAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitorCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitorPhoneNo = table.Column<int>(type: "int", nullable: false),
                    SolicitorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitorAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitorDXnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPropertyFinance", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "AppBusniessFinanceSecurityDetails",
                columns: table => new
                {
                    SecurityDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalChargeOverProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfPropertyOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    YearsRemainingOnLeaseIfLeaseHold = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false),
                    OriginalPurchasePrice = table.Column<int>(type: "int", nullable: false),
                    AddressForPropertyOfSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    AppBusniessFinanceBusniessFinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBusniessFinanceSecurityDetails", x => x.SecurityDetailsId);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceSecurityDetails_AppBusniessFinance_AppBusniessFinanceBusniessFinId",
                        column: x => x.AppBusniessFinanceBusniessFinId,
                        principalTable: "AppBusniessFinance",
                        principalColumn: "BusniessFinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDevelopmentFinanceSecurityDetails",
                columns: table => new
                {
                    SecurityDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfProperty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyCurrentUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfPropertyOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    YearsRemainingOnLeaseIfLeaseHold = table.Column<int>(type: "int", nullable: false),
                    AddressForPropertyOfSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    AppDevelopmentFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevelopmentFinanceSecurityDetails", x => x.SecurityDetailsId);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceSecurityDetails_AppDevelopmentFinance_AppDevelopmentFinanceLoanId",
                        column: x => x.AppDevelopmentFinanceLoanId,
                        principalTable: "AppDevelopmentFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppPropertyFinanceSecurityDetails",
                columns: table => new
                {
                    SecurityDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecurityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlreadyOwned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfPropertyOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    YearsRemainingOnLeaseIfLeaseHold = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false),
                    OriginalPurchasePrice = table.Column<int>(type: "int", nullable: false),
                    UseOfFunds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    HMO_MUFB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressForPropertyOfSecurity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    AppPropertyFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPropertyFinanceSecurityDetails", x => x.SecurityDetailsId);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceSecurityDetails_AppPropertyFinance_AppPropertyFinanceLoanId",
                        column: x => x.AppPropertyFinanceLoanId,
                        principalTable: "AppPropertyFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceSecurityDetails_AppBusniessFinanceBusniessFinId",
                table: "AppBusniessFinanceSecurityDetails",
                column: "AppBusniessFinanceBusniessFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceSecurityDetails_AppDevelopmentFinanceLoanId",
                table: "AppDevelopmentFinanceSecurityDetails",
                column: "AppDevelopmentFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceSecurityDetails_AppPropertyFinanceLoanId",
                table: "AppPropertyFinanceSecurityDetails",
                column: "AppPropertyFinanceLoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBusniessFinanceSecurityDetails");

            migrationBuilder.DropTable(
                name: "AppDevelopmentFinanceSecurityDetails");

            migrationBuilder.DropTable(
                name: "AppPropertyFinanceSecurityDetails");

            migrationBuilder.DropTable(
                name: "AppBusniessFinance");

            migrationBuilder.DropTable(
                name: "AppDevelopmentFinance");

            migrationBuilder.DropTable(
                name: "AppPropertyFinance");
        }
    }
}
