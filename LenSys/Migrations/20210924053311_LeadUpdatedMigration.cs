using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LenSys.Migrations
{
    public partial class LeadUpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    AddressDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    DateMovedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidentialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketValue = table.Column<int>(type: "int", nullable: false),
                    OutstandingMortgageBalance = table.Column<int>(type: "int", nullable: false),
                    LessThanThreeYears = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousFirstLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousSecondLineAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousPostCode = table.Column<int>(type: "int", nullable: false),
                    PreviousDateMovedIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.AddressDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    Shares = table.Column<int>(type: "int", nullable: false),
                    LifePolicy = table.Column<int>(type: "int", nullable: false),
                    PersonalDewellingHouse = table.Column<int>(type: "int", nullable: false),
                    OtherInvestments = table.Column<int>(type: "int", nullable: false),
                    TotalAssets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "BusniessDetails",
                columns: table => new
                {
                    BusniessDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyBusniessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredNumber = table.Column<int>(type: "int", nullable: false),
                    NatureOfBusniess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAddress = table.Column<int>(type: "int", nullable: false),
                    TradingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrespondenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradingSince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusniessDetails", x => x.BusniessDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "BusniessDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusniessDocuments", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "CreditHistory",
                columns: table => new
                {
                    CreditHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalCreditRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IVAorCVA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclaredBankrupt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyRepossessed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuarantorOnLoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriminalConvictions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditHistory", x => x.CreditHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossSalary = table.Column<int>(type: "int", nullable: false),
                    NationalInsuranceNumber = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestEarnedIncomeYearOne = table.Column<int>(type: "int", nullable: false),
                    LatestEarnedIncomeYearTwo = table.Column<int>(type: "int", nullable: false),
                    LatestEarnedIncomeYearThree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.EmploymentDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "IndividualDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualDocuments", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    LeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmount = table.Column<int>(type: "int", nullable: false),
                    IntroducerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyBusniessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.LeadId);
                });

            migrationBuilder.CreateTable(
                name: "Liabilities",
                columns: table => new
                {
                    LiabilitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Overdraft = table.Column<int>(type: "int", nullable: false),
                    ResidentialMortgage = table.Column<int>(type: "int", nullable: false),
                    CarLoanHP = table.Column<int>(type: "int", nullable: false),
                    PersonalLoan1 = table.Column<int>(type: "int", nullable: false),
                    PersonalLoan2 = table.Column<int>(type: "int", nullable: false),
                    PersonalLoan3 = table.Column<int>(type: "int", nullable: false),
                    StoreCreditCard1 = table.Column<int>(type: "int", nullable: false),
                    StoreCreditCard2 = table.Column<int>(type: "int", nullable: false),
                    StoreCreditCard3 = table.Column<int>(type: "int", nullable: false),
                    PersonalGuaranteesSigned = table.Column<int>(type: "int", nullable: false),
                    Others = table.Column<int>(type: "int", nullable: false),
                    TotalLiabilities = table.Column<int>(type: "int", nullable: false),
                    NetAssets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liabilities", x => x.LiabilitiesId);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyExpenditure",
                columns: table => new
                {
                    MonthlyExpenditureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MortgageRent = table.Column<int>(type: "int", nullable: false),
                    LifeAssurancePension = table.Column<int>(type: "int", nullable: false),
                    RatesCouncilTax = table.Column<int>(type: "int", nullable: false),
                    WaterGasElectricityTelephoneBill = table.Column<int>(type: "int", nullable: false),
                    HomeBuildingContentsInsurance = table.Column<int>(type: "int", nullable: false),
                    TravelToWork = table.Column<int>(type: "int", nullable: false),
                    PetrolCarMaintenance = table.Column<int>(type: "int", nullable: false),
                    CarInsuranceRoadTax = table.Column<int>(type: "int", nullable: false),
                    FoodAndClothing = table.Column<int>(type: "int", nullable: false),
                    LoanHPCreditCardPayments = table.Column<int>(type: "int", nullable: false),
                    EntertainmentSubscriptions = table.Column<int>(type: "int", nullable: false),
                    OtherCostChristmisHolidays = table.Column<int>(type: "int", nullable: false),
                    TotalExpenditure = table.Column<int>(type: "int", nullable: false),
                    MonthlyDisposableIncome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyExpenditure", x => x.MonthlyExpenditureId);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyIncome",
                columns: table => new
                {
                    MonthlyIncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryAfterTax = table.Column<int>(type: "int", nullable: false),
                    DividendsAfterTax = table.Column<int>(type: "int", nullable: false),
                    PartnerEaningAfterTax = table.Column<int>(type: "int", nullable: false),
                    OtherIncomeInvestments = table.Column<int>(type: "int", nullable: false),
                    TotalIncome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyIncome", x => x.MonthlyIncomeId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDetails",
                columns: table => new
                {
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    PermanentRightForUkResident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthOfResidencyYears = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDetails", x => x.PersonalDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "AppAssetFinance",
                columns: table => new
                {
                    AssetFinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePriceOfAssetValue = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<int>(type: "int", nullable: false),
                    VATincluded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepaymentTermMonths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalloonPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssetFinance", x => x.AssetFinId);
                    table.ForeignKey(
                        name: "FK_AppAssetFinance_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppBusniessFinance",
                columns: table => new
                {
                    BusniessFinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AppBusniessFinance_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDevelopmentFinance",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinance_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppPropertyFinance",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AppPropertyFinance_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppAssetFinanceBusniess",
                columns: table => new
                {
                    BusniessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusniessDetailsId = table.Column<int>(type: "int", nullable: true),
                    busniessDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppAssetFinanceAssetFinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssetFinanceBusniess", x => x.BusniessId);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceBusniess_AppAssetFinance_AppAssetFinanceAssetFinId",
                        column: x => x.AppAssetFinanceAssetFinId,
                        principalTable: "AppAssetFinance",
                        principalColumn: "AssetFinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceBusniess_BusniessDetails_BusniessDetailsId",
                        column: x => x.BusniessDetailsId,
                        principalTable: "BusniessDetails",
                        principalColumn: "BusniessDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                        column: x => x.busniessDocumentsDocumentId,
                        principalTable: "BusniessDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppAssetFinanceIndividual",
                columns: table => new
                {
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: true),
                    MonthlyIncomeId = table.Column<int>(type: "int", nullable: true),
                    MonthlyExpenditureId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    LiabilitiesId = table.Column<int>(type: "int", nullable: true),
                    CreditHistoryId = table.Column<int>(type: "int", nullable: true),
                    individualDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppAssetFinanceAssetFinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAssetFinanceIndividual", x => x.IndividualId);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_AppAssetFinance_AppAssetFinanceAssetFinId",
                        column: x => x.AppAssetFinanceAssetFinId,
                        principalTable: "AppAssetFinance",
                        principalColumn: "AssetFinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_CreditHistory_CreditHistoryId",
                        column: x => x.CreditHistoryId,
                        principalTable: "CreditHistory",
                        principalColumn: "CreditHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_EmploymentDetails_EmploymentDetailsId",
                        column: x => x.EmploymentDetailsId,
                        principalTable: "EmploymentDetails",
                        principalColumn: "EmploymentDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                        column: x => x.individualDocumentsDocumentId,
                        principalTable: "IndividualDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_Liabilities_LiabilitiesId",
                        column: x => x.LiabilitiesId,
                        principalTable: "Liabilities",
                        principalColumn: "LiabilitiesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_MonthlyExpenditure_MonthlyExpenditureId",
                        column: x => x.MonthlyExpenditureId,
                        principalTable: "MonthlyExpenditure",
                        principalColumn: "MonthlyExpenditureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_MonthlyIncome_MonthlyIncomeId",
                        column: x => x.MonthlyIncomeId,
                        principalTable: "MonthlyIncome",
                        principalColumn: "MonthlyIncomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppAssetFinanceIndividual_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppBusniessFinanceBusniess",
                columns: table => new
                {
                    BusniessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusniessDetailsId = table.Column<int>(type: "int", nullable: true),
                    busniessDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceBusniessFinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBusniessFinanceBusniess", x => x.BusniessId);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceBusniess_AppBusniessFinance_AppBusniessFinanceBusniessFinId",
                        column: x => x.AppBusniessFinanceBusniessFinId,
                        principalTable: "AppBusniessFinance",
                        principalColumn: "BusniessFinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceBusniess_BusniessDetails_BusniessDetailsId",
                        column: x => x.BusniessDetailsId,
                        principalTable: "BusniessDetails",
                        principalColumn: "BusniessDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                        column: x => x.busniessDocumentsDocumentId,
                        principalTable: "BusniessDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppBusniessFinanceIndividual",
                columns: table => new
                {
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: true),
                    MonthlyIncomeId = table.Column<int>(type: "int", nullable: true),
                    MonthlyExpenditureId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    LiabilitiesId = table.Column<int>(type: "int", nullable: true),
                    CreditHistoryId = table.Column<int>(type: "int", nullable: true),
                    individualDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceBusniessFinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBusniessFinanceIndividual", x => x.IndividualId);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_AppBusniessFinance_AppBusniessFinanceBusniessFinId",
                        column: x => x.AppBusniessFinanceBusniessFinId,
                        principalTable: "AppBusniessFinance",
                        principalColumn: "BusniessFinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_CreditHistory_CreditHistoryId",
                        column: x => x.CreditHistoryId,
                        principalTable: "CreditHistory",
                        principalColumn: "CreditHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_EmploymentDetails_EmploymentDetailsId",
                        column: x => x.EmploymentDetailsId,
                        principalTable: "EmploymentDetails",
                        principalColumn: "EmploymentDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                        column: x => x.individualDocumentsDocumentId,
                        principalTable: "IndividualDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_Liabilities_LiabilitiesId",
                        column: x => x.LiabilitiesId,
                        principalTable: "Liabilities",
                        principalColumn: "LiabilitiesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_MonthlyExpenditure_MonthlyExpenditureId",
                        column: x => x.MonthlyExpenditureId,
                        principalTable: "MonthlyExpenditure",
                        principalColumn: "MonthlyExpenditureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_MonthlyIncome_MonthlyIncomeId",
                        column: x => x.MonthlyIncomeId,
                        principalTable: "MonthlyIncome",
                        principalColumn: "MonthlyIncomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppBusniessFinanceIndividual_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AppDevelopmentFinanceBusniess",
                columns: table => new
                {
                    BusniessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusniessDetailsId = table.Column<int>(type: "int", nullable: true),
                    busniessDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevelopmentFinanceBusniess", x => x.BusniessId);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceBusniess_AppDevelopmentFinance_AppDevelopmentFinanceLoanId",
                        column: x => x.AppDevelopmentFinanceLoanId,
                        principalTable: "AppDevelopmentFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceBusniess_BusniessDetails_BusniessDetailsId",
                        column: x => x.BusniessDetailsId,
                        principalTable: "BusniessDetails",
                        principalColumn: "BusniessDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                        column: x => x.busniessDocumentsDocumentId,
                        principalTable: "BusniessDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDevelopmentFinanceIndividual",
                columns: table => new
                {
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: true),
                    MonthlyIncomeId = table.Column<int>(type: "int", nullable: true),
                    MonthlyExpenditureId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    LiabilitiesId = table.Column<int>(type: "int", nullable: true),
                    CreditHistoryId = table.Column<int>(type: "int", nullable: true),
                    individualDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevelopmentFinanceIndividual", x => x.IndividualId);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_AppDevelopmentFinance_AppDevelopmentFinanceLoanId",
                        column: x => x.AppDevelopmentFinanceLoanId,
                        principalTable: "AppDevelopmentFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_CreditHistory_CreditHistoryId",
                        column: x => x.CreditHistoryId,
                        principalTable: "CreditHistory",
                        principalColumn: "CreditHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_EmploymentDetails_EmploymentDetailsId",
                        column: x => x.EmploymentDetailsId,
                        principalTable: "EmploymentDetails",
                        principalColumn: "EmploymentDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                        column: x => x.individualDocumentsDocumentId,
                        principalTable: "IndividualDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_Liabilities_LiabilitiesId",
                        column: x => x.LiabilitiesId,
                        principalTable: "Liabilities",
                        principalColumn: "LiabilitiesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_MonthlyExpenditure_MonthlyExpenditureId",
                        column: x => x.MonthlyExpenditureId,
                        principalTable: "MonthlyExpenditure",
                        principalColumn: "MonthlyExpenditureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_MonthlyIncome_MonthlyIncomeId",
                        column: x => x.MonthlyIncomeId,
                        principalTable: "MonthlyIncome",
                        principalColumn: "MonthlyIncomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppDevelopmentFinanceIndividual_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId",
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
                name: "AppPropertyFinanceBusniess",
                columns: table => new
                {
                    BusniessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusniessDetailsId = table.Column<int>(type: "int", nullable: true),
                    busniessDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPropertyFinanceBusniess", x => x.BusniessId);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceBusniess_AppPropertyFinance_AppPropertyFinanceLoanId",
                        column: x => x.AppPropertyFinanceLoanId,
                        principalTable: "AppPropertyFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceBusniess_BusniessDetails_BusniessDetailsId",
                        column: x => x.BusniessDetailsId,
                        principalTable: "BusniessDetails",
                        principalColumn: "BusniessDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceBusniess_BusniessDocuments_busniessDocumentsDocumentId",
                        column: x => x.busniessDocumentsDocumentId,
                        principalTable: "BusniessDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppPropertyFinanceIndividual",
                columns: table => new
                {
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalDetailsId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailsId = table.Column<int>(type: "int", nullable: true),
                    EmploymentDetailsId = table.Column<int>(type: "int", nullable: true),
                    MonthlyIncomeId = table.Column<int>(type: "int", nullable: true),
                    MonthlyExpenditureId = table.Column<int>(type: "int", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    LiabilitiesId = table.Column<int>(type: "int", nullable: true),
                    CreditHistoryId = table.Column<int>(type: "int", nullable: true),
                    individualDocumentsDocumentId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPropertyFinanceIndividual", x => x.IndividualId);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_AddressDetails_AddressDetailsId",
                        column: x => x.AddressDetailsId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_AppPropertyFinance_AppPropertyFinanceLoanId",
                        column: x => x.AppPropertyFinanceLoanId,
                        principalTable: "AppPropertyFinance",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_CreditHistory_CreditHistoryId",
                        column: x => x.CreditHistoryId,
                        principalTable: "CreditHistory",
                        principalColumn: "CreditHistoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_EmploymentDetails_EmploymentDetailsId",
                        column: x => x.EmploymentDetailsId,
                        principalTable: "EmploymentDetails",
                        principalColumn: "EmploymentDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_IndividualDocuments_individualDocumentsDocumentId",
                        column: x => x.individualDocumentsDocumentId,
                        principalTable: "IndividualDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_Liabilities_LiabilitiesId",
                        column: x => x.LiabilitiesId,
                        principalTable: "Liabilities",
                        principalColumn: "LiabilitiesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_MonthlyExpenditure_MonthlyExpenditureId",
                        column: x => x.MonthlyExpenditureId,
                        principalTable: "MonthlyExpenditure",
                        principalColumn: "MonthlyExpenditureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_MonthlyIncome_MonthlyIncomeId",
                        column: x => x.MonthlyIncomeId,
                        principalTable: "MonthlyIncome",
                        principalColumn: "MonthlyIncomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppPropertyFinanceIndividual_PersonalDetails_PersonalDetailsId",
                        column: x => x.PersonalDetailsId,
                        principalTable: "PersonalDetails",
                        principalColumn: "PersonalDetailsId",
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

            migrationBuilder.CreateTable(
                name: "BusniessLiabilities",
                columns: table => new
                {
                    BusniessLiabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrigionalLoanAmount = table.Column<int>(type: "int", nullable: false),
                    OutstandingBalance = table.Column<int>(type: "int", nullable: false),
                    MonthlyPayment = table.Column<int>(type: "int", nullable: false),
                    InitialTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    FixedOrVariable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommitmentTerm = table.Column<int>(type: "int", nullable: false),
                    EarlyRepaymentCharge = table.Column<int>(type: "int", nullable: false),
                    AppAssetFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusniessLiabilities", x => x.BusniessLiabilityId);
                    table.ForeignKey(
                        name: "FK_BusniessLiabilities_AppAssetFinanceBusniess_AppAssetFinanceBusniessBusniessId",
                        column: x => x.AppAssetFinanceBusniessBusniessId,
                        principalTable: "AppAssetFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusniessLiabilities_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessBusniessId",
                        column: x => x.AppBusniessFinanceBusniessBusniessId,
                        principalTable: "AppBusniessFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusniessLiabilities_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceBusniessBusniessId",
                        column: x => x.AppDevelopmentFinanceBusniessBusniessId,
                        principalTable: "AppDevelopmentFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusniessLiabilities_AppPropertyFinanceBusniess_AppPropertyFinanceBusniessBusniessId",
                        column: x => x.AppPropertyFinanceBusniessBusniessId,
                        principalTable: "AppPropertyFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KeyPrincipals",
                columns: table => new
                {
                    KeyPrincipalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentageShareholding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppAssetFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPrincipals", x => x.KeyPrincipalsId);
                    table.ForeignKey(
                        name: "FK_KeyPrincipals_AppAssetFinanceBusniess_AppAssetFinanceBusniessBusniessId",
                        column: x => x.AppAssetFinanceBusniessBusniessId,
                        principalTable: "AppAssetFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPrincipals_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessBusniessId",
                        column: x => x.AppBusniessFinanceBusniessBusniessId,
                        principalTable: "AppBusniessFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPrincipals_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceBusniessBusniessId",
                        column: x => x.AppDevelopmentFinanceBusniessBusniessId,
                        principalTable: "AppDevelopmentFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KeyPrincipals_AppPropertyFinanceBusniess_AppPropertyFinanceBusniessBusniessId",
                        column: x => x.AppPropertyFinanceBusniessBusniessId,
                        principalTable: "AppPropertyFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Serviceability",
                columns: table => new
                {
                    ServiceabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurnOver = table.Column<int>(type: "int", nullable: false),
                    NetProfit = table.Column<int>(type: "int", nullable: false),
                    EBITDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppAssetFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceBusniessBusniessId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviceability", x => x.ServiceabilityId);
                    table.ForeignKey(
                        name: "FK_Serviceability_AppAssetFinanceBusniess_AppAssetFinanceBusniessBusniessId",
                        column: x => x.AppAssetFinanceBusniessBusniessId,
                        principalTable: "AppAssetFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serviceability_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessBusniessId",
                        column: x => x.AppBusniessFinanceBusniessBusniessId,
                        principalTable: "AppBusniessFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serviceability_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceBusniessBusniessId",
                        column: x => x.AppDevelopmentFinanceBusniessBusniessId,
                        principalTable: "AppDevelopmentFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serviceability_AppPropertyFinanceBusniess_AppPropertyFinanceBusniessBusniessId",
                        column: x => x.AppPropertyFinanceBusniessBusniessId,
                        principalTable: "AppPropertyFinanceBusniess",
                        principalColumn: "BusniessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertySchedule",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    OrigionalMortgageAmount = table.Column<int>(type: "int", nullable: false),
                    CurrentMarketValue = table.Column<int>(type: "int", nullable: false),
                    OutstandingMortgage = table.Column<int>(type: "int", nullable: false),
                    RemainingTerm = table.Column<int>(type: "int", nullable: false),
                    TypeOfRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestRate = table.Column<int>(type: "int", nullable: false),
                    RentPcm = table.Column<int>(type: "int", nullable: false),
                    MortgagePcm = table.Column<int>(type: "int", nullable: false),
                    LTV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfTenancyLeaseASTBoth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTermOfLease = table.Column<int>(type: "int", nullable: false),
                    AppAssetFinanceIndividualIndividualId = table.Column<int>(type: "int", nullable: true),
                    AppBusniessFinanceIndividualIndividualId = table.Column<int>(type: "int", nullable: true),
                    AppDevelopmentFinanceIndividualIndividualId = table.Column<int>(type: "int", nullable: true),
                    AppPropertyFinanceIndividualIndividualId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySchedule", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_PropertySchedule_AppAssetFinanceIndividual_AppAssetFinanceIndividualIndividualId",
                        column: x => x.AppAssetFinanceIndividualIndividualId,
                        principalTable: "AppAssetFinanceIndividual",
                        principalColumn: "IndividualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertySchedule_AppBusniessFinanceIndividual_AppBusniessFinanceIndividualIndividualId",
                        column: x => x.AppBusniessFinanceIndividualIndividualId,
                        principalTable: "AppBusniessFinanceIndividual",
                        principalColumn: "IndividualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertySchedule_AppDevelopmentFinanceIndividual_AppDevelopmentFinanceIndividualIndividualId",
                        column: x => x.AppDevelopmentFinanceIndividualIndividualId,
                        principalTable: "AppDevelopmentFinanceIndividual",
                        principalColumn: "IndividualId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertySchedule_AppPropertyFinanceIndividual_AppPropertyFinanceIndividualIndividualId",
                        column: x => x.AppPropertyFinanceIndividualIndividualId,
                        principalTable: "AppPropertyFinanceIndividual",
                        principalColumn: "IndividualId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinance_LeadId",
                table: "AppAssetFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceBusniess_AppAssetFinanceAssetFinId",
                table: "AppAssetFinanceBusniess",
                column: "AppAssetFinanceAssetFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceBusniess_BusniessDetailsId",
                table: "AppAssetFinanceBusniess",
                column: "BusniessDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppAssetFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_AddressDetailsId",
                table: "AppAssetFinanceIndividual",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_AppAssetFinanceAssetFinId",
                table: "AppAssetFinanceIndividual",
                column: "AppAssetFinanceAssetFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_AssetId",
                table: "AppAssetFinanceIndividual",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_CreditHistoryId",
                table: "AppAssetFinanceIndividual",
                column: "CreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_EmploymentDetailsId",
                table: "AppAssetFinanceIndividual",
                column: "EmploymentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_individualDocumentsDocumentId",
                table: "AppAssetFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_LiabilitiesId",
                table: "AppAssetFinanceIndividual",
                column: "LiabilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_MonthlyExpenditureId",
                table: "AppAssetFinanceIndividual",
                column: "MonthlyExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_MonthlyIncomeId",
                table: "AppAssetFinanceIndividual",
                column: "MonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAssetFinanceIndividual_PersonalDetailsId",
                table: "AppAssetFinanceIndividual",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinance_LeadId",
                table: "AppBusniessFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceBusniess_AppBusniessFinanceBusniessFinId",
                table: "AppBusniessFinanceBusniess",
                column: "AppBusniessFinanceBusniessFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceBusniess_BusniessDetailsId",
                table: "AppBusniessFinanceBusniess",
                column: "BusniessDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppBusniessFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_AddressDetailsId",
                table: "AppBusniessFinanceIndividual",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_AppBusniessFinanceBusniessFinId",
                table: "AppBusniessFinanceIndividual",
                column: "AppBusniessFinanceBusniessFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_AssetId",
                table: "AppBusniessFinanceIndividual",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_CreditHistoryId",
                table: "AppBusniessFinanceIndividual",
                column: "CreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_EmploymentDetailsId",
                table: "AppBusniessFinanceIndividual",
                column: "EmploymentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_individualDocumentsDocumentId",
                table: "AppBusniessFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_LiabilitiesId",
                table: "AppBusniessFinanceIndividual",
                column: "LiabilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_MonthlyExpenditureId",
                table: "AppBusniessFinanceIndividual",
                column: "MonthlyExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_MonthlyIncomeId",
                table: "AppBusniessFinanceIndividual",
                column: "MonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceIndividual_PersonalDetailsId",
                table: "AppBusniessFinanceIndividual",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBusniessFinanceSecurityDetails_AppBusniessFinanceBusniessFinId",
                table: "AppBusniessFinanceSecurityDetails",
                column: "AppBusniessFinanceBusniessFinId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinance_LeadId",
                table: "AppDevelopmentFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceBusniess_AppDevelopmentFinanceLoanId",
                table: "AppDevelopmentFinanceBusniess",
                column: "AppDevelopmentFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceBusniess_BusniessDetailsId",
                table: "AppDevelopmentFinanceBusniess",
                column: "BusniessDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppDevelopmentFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_AddressDetailsId",
                table: "AppDevelopmentFinanceIndividual",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_AppDevelopmentFinanceLoanId",
                table: "AppDevelopmentFinanceIndividual",
                column: "AppDevelopmentFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_AssetId",
                table: "AppDevelopmentFinanceIndividual",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_CreditHistoryId",
                table: "AppDevelopmentFinanceIndividual",
                column: "CreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_EmploymentDetailsId",
                table: "AppDevelopmentFinanceIndividual",
                column: "EmploymentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_individualDocumentsDocumentId",
                table: "AppDevelopmentFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_LiabilitiesId",
                table: "AppDevelopmentFinanceIndividual",
                column: "LiabilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_MonthlyExpenditureId",
                table: "AppDevelopmentFinanceIndividual",
                column: "MonthlyExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_MonthlyIncomeId",
                table: "AppDevelopmentFinanceIndividual",
                column: "MonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceIndividual_PersonalDetailsId",
                table: "AppDevelopmentFinanceIndividual",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDevelopmentFinanceSecurityDetails_AppDevelopmentFinanceLoanId",
                table: "AppDevelopmentFinanceSecurityDetails",
                column: "AppDevelopmentFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinance_LeadId",
                table: "AppPropertyFinance",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceBusniess_AppPropertyFinanceLoanId",
                table: "AppPropertyFinanceBusniess",
                column: "AppPropertyFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceBusniess_BusniessDetailsId",
                table: "AppPropertyFinanceBusniess",
                column: "BusniessDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceBusniess_busniessDocumentsDocumentId",
                table: "AppPropertyFinanceBusniess",
                column: "busniessDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_AddressDetailsId",
                table: "AppPropertyFinanceIndividual",
                column: "AddressDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_AppPropertyFinanceLoanId",
                table: "AppPropertyFinanceIndividual",
                column: "AppPropertyFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_AssetId",
                table: "AppPropertyFinanceIndividual",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_CreditHistoryId",
                table: "AppPropertyFinanceIndividual",
                column: "CreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_EmploymentDetailsId",
                table: "AppPropertyFinanceIndividual",
                column: "EmploymentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_individualDocumentsDocumentId",
                table: "AppPropertyFinanceIndividual",
                column: "individualDocumentsDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_LiabilitiesId",
                table: "AppPropertyFinanceIndividual",
                column: "LiabilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_MonthlyExpenditureId",
                table: "AppPropertyFinanceIndividual",
                column: "MonthlyExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_MonthlyIncomeId",
                table: "AppPropertyFinanceIndividual",
                column: "MonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceIndividual_PersonalDetailsId",
                table: "AppPropertyFinanceIndividual",
                column: "PersonalDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPropertyFinanceSecurityDetails_AppPropertyFinanceLoanId",
                table: "AppPropertyFinanceSecurityDetails",
                column: "AppPropertyFinanceLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessLiabilities_AppAssetFinanceBusniessBusniessId",
                table: "BusniessLiabilities",
                column: "AppAssetFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessLiabilities_AppBusniessFinanceBusniessBusniessId",
                table: "BusniessLiabilities",
                column: "AppBusniessFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessLiabilities_AppDevelopmentFinanceBusniessBusniessId",
                table: "BusniessLiabilities",
                column: "AppDevelopmentFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusniessLiabilities_AppPropertyFinanceBusniessBusniessId",
                table: "BusniessLiabilities",
                column: "AppPropertyFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPrincipals_AppAssetFinanceBusniessBusniessId",
                table: "KeyPrincipals",
                column: "AppAssetFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPrincipals_AppBusniessFinanceBusniessBusniessId",
                table: "KeyPrincipals",
                column: "AppBusniessFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPrincipals_AppDevelopmentFinanceBusniessBusniessId",
                table: "KeyPrincipals",
                column: "AppDevelopmentFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyPrincipals_AppPropertyFinanceBusniessBusniessId",
                table: "KeyPrincipals",
                column: "AppPropertyFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySchedule_AppAssetFinanceIndividualIndividualId",
                table: "PropertySchedule",
                column: "AppAssetFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySchedule_AppBusniessFinanceIndividualIndividualId",
                table: "PropertySchedule",
                column: "AppBusniessFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySchedule_AppDevelopmentFinanceIndividualIndividualId",
                table: "PropertySchedule",
                column: "AppDevelopmentFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySchedule_AppPropertyFinanceIndividualIndividualId",
                table: "PropertySchedule",
                column: "AppPropertyFinanceIndividualIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviceability_AppAssetFinanceBusniessBusniessId",
                table: "Serviceability",
                column: "AppAssetFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviceability_AppBusniessFinanceBusniessBusniessId",
                table: "Serviceability",
                column: "AppBusniessFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviceability_AppDevelopmentFinanceBusniessBusniessId",
                table: "Serviceability",
                column: "AppDevelopmentFinanceBusniessBusniessId");

            migrationBuilder.CreateIndex(
                name: "IX_Serviceability_AppPropertyFinanceBusniessBusniessId",
                table: "Serviceability",
                column: "AppPropertyFinanceBusniessBusniessId");
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
                name: "BusniessLiabilities");

            migrationBuilder.DropTable(
                name: "KeyPrincipals");

            migrationBuilder.DropTable(
                name: "PropertySchedule");

            migrationBuilder.DropTable(
                name: "Serviceability");

            migrationBuilder.DropTable(
                name: "AppAssetFinanceIndividual");

            migrationBuilder.DropTable(
                name: "AppBusniessFinanceIndividual");

            migrationBuilder.DropTable(
                name: "AppDevelopmentFinanceIndividual");

            migrationBuilder.DropTable(
                name: "AppPropertyFinanceIndividual");

            migrationBuilder.DropTable(
                name: "AppAssetFinanceBusniess");

            migrationBuilder.DropTable(
                name: "AppBusniessFinanceBusniess");

            migrationBuilder.DropTable(
                name: "AppDevelopmentFinanceBusniess");

            migrationBuilder.DropTable(
                name: "AppPropertyFinanceBusniess");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "CreditHistory");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "IndividualDocuments");

            migrationBuilder.DropTable(
                name: "Liabilities");

            migrationBuilder.DropTable(
                name: "MonthlyExpenditure");

            migrationBuilder.DropTable(
                name: "MonthlyIncome");

            migrationBuilder.DropTable(
                name: "PersonalDetails");

            migrationBuilder.DropTable(
                name: "AppAssetFinance");

            migrationBuilder.DropTable(
                name: "AppBusniessFinance");

            migrationBuilder.DropTable(
                name: "AppDevelopmentFinance");

            migrationBuilder.DropTable(
                name: "AppPropertyFinance");

            migrationBuilder.DropTable(
                name: "BusniessDetails");

            migrationBuilder.DropTable(
                name: "BusniessDocuments");

            migrationBuilder.DropTable(
                name: "Lead");
        }
    }
}
