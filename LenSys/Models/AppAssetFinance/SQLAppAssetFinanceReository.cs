using LenSys.Controllers;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.Home;
using LenSys.Models.IndividualPropertySchedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppAssetFinance
{
    public class SQLAppAssetFinanceReository : IAppAssetFinanceRepository
    {
        private readonly AppDbContext Context;
        public SQLAppAssetFinanceReository(AppDbContext context)
        {
            Context = context;
        }
        public AppAssetFinance Add(AppAssetFinance appAssetFinance)
        {
            //appAssetFinance.Lead.LeadId = 1;
            //Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Lead ON");
            Context.AppAssetFinance.Add(appAssetFinance);
            Context.SaveChanges();
            return appAssetFinance;
        }
        //Not Used
        public AppAssetFinance AddIndividual(AppAssetFinanceIndividual.AppAssetFinanceIndividual individual)
        {
            int id = HomeController.EditAssetFinanceAppID;
            //var appAssetFinance = Context.AppAssetFinance.Single(e => e.AssetFinId == id);
            //var appAssetFinance =Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("individuals").FirstOrDefault();
            var appAssetFinance = GetAppAssetFinance(id);
            appAssetFinance.individuals.Add(individual);
            Context.SaveChanges();
            return appAssetFinance;
        }
        //Not Used
        public AppAssetFinance AddBusniess(AppAssetFinanceBusniess.AppAssetFinanceBusniess busniess)
        {
            int id = HomeController.EditAssetFinanceAppID;
            var appAssetFinance = Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("busniesses").FirstOrDefault();
            appAssetFinance.busniesses.Add(busniess);
            Context.SaveChanges();
            return appAssetFinance;
        }
        public AppAssetFinance Delete(int id)
        {
            //AppAssetFinance appAssetFinance = Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("Lead").Include("individuals").Include("busniesses").FirstOrDefault(); //Context.AppAssetFinance.Find(id);
            AppAssetFinance appAssetFinance = Context.AppAssetFinance
               .Include(x => x.Lead)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.personalDetails)
               .Include(a => a.individuals)
                   .ThenInclude(b => b.addressDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.employmentDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyIncome)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyExpenditure)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.asset)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.liabilities)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.propertySchedule)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.creditHistory)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.individualDocuments)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDetails)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.keyPrincipals)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessLiabilities)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.serviceability)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDocuments)
               .Where(h => h.AssetFinId == id)
               .FirstOrDefault();

            if (appAssetFinance != null)
            {
                Context.AppAssetFinance.Remove(appAssetFinance);
                Context.Entry(appAssetFinance.Lead).State = EntityState.Deleted;

                if (appAssetFinance.individuals.Count > 0)
                {
                    foreach (AppAssetFinanceIndividual.AppAssetFinanceIndividual individual in appAssetFinance.individuals)
                    {
                        Context.Entry(individual).State = EntityState.Deleted;
                        Context.Entry(individual.personalDetails).State = EntityState.Deleted;
                        Context.Entry(individual.addressDetails).State = EntityState.Deleted;
                        Context.Entry(individual.employmentDetails).State = EntityState.Deleted;
                        Context.Entry(individual.monthlyIncome).State = EntityState.Deleted;
                        Context.Entry(individual.monthlyExpenditure).State = EntityState.Deleted;
                        Context.Entry(individual.asset).State = EntityState.Deleted;
                        Context.Entry(individual.liabilities).State = EntityState.Deleted;

                        foreach (PropertySchedule propertySchedule in individual.propertySchedule)
                        {
                            Context.Entry(propertySchedule).State = EntityState.Deleted;
                        }

                        Context.Entry(individual.creditHistory).State = EntityState.Deleted;
                        Context.Entry(individual.individualDocuments).State = EntityState.Deleted;
                    }
                }

                if (appAssetFinance.busniesses.Count > 0)
                {
                    foreach (AppAssetFinanceBusniess.AppAssetFinanceBusniess busniess in appAssetFinance.busniesses)
                    {
                        Context.Entry(busniess).State = EntityState.Deleted;
                        Context.Entry(busniess.busniessDetails).State = EntityState.Deleted;

                        foreach (KeyPrincipals keyPrincipals in busniess.keyPrincipals)
                        {
                            Context.Entry(keyPrincipals).State = EntityState.Deleted;
                        }

                        foreach (BusniessLiabilities.BusniessLiabilities busniessLiabilities in busniess.busniessLiabilities)
                        {
                            Context.Entry(busniessLiabilities).State = EntityState.Deleted;
                        }

                        foreach (Serviceability serviceability in busniess.serviceability)
                        {
                            Context.Entry(serviceability).State = EntityState.Deleted;
                        }

                        Context.Entry(busniess.busniessDocuments).State = EntityState.Deleted;
                    }
                }
                Context.SaveChanges();
            }
            return appAssetFinance;
        }
        public IEnumerable<AppAssetFinance> GetAllAppAssetFinance()
        {
            IEnumerable<AppAssetFinance> appAssetFinancesList;
            appAssetFinancesList = Context.AppAssetFinance.Include(x => x.Lead);
            return appAssetFinancesList;
        }
        public AppAssetFinance GetAppAssetFinance(int id)
        {
            AppAssetFinance appAssetFinance = Context.AppAssetFinance
               .Include(x => x.Lead)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.personalDetails)
               .Include(a => a.individuals)
                   .ThenInclude(b => b.addressDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.employmentDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyIncome)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyExpenditure)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.asset)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.liabilities)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.propertySchedule)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.creditHistory)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.individualDocuments)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDetails)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.keyPrincipals)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessLiabilities)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.serviceability)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDocuments)
               .Where(h => h.AssetFinId == id)
               .FirstOrDefault();

            return appAssetFinance;
        }
        public AppAssetFinance GetAppAssetFinance_EditHome(int id)
        {
            //WithoutLeadData
            AppAssetFinance appAssetFinance = Context.AppAssetFinance
               .Include(x => x.individuals)
                   .ThenInclude(y => y.personalDetails)
               .Include(a => a.individuals)
                   .ThenInclude(b => b.addressDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.employmentDetails)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyIncome)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.monthlyExpenditure)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.asset)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.liabilities)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.propertySchedule)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.creditHistory)
               .Include(x => x.individuals)
                   .ThenInclude(y => y.individualDocuments)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDetails)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.keyPrincipals)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessLiabilities)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.serviceability)
               .Include(x => x.busniesses)
                   .ThenInclude(z => z.busniessDocuments)
               .Where(h => h.AssetFinId == id)
               .FirstOrDefault();


            return appAssetFinance;
        }
        public AppAssetFinance Update(AppAssetFinance AppAssetFinanceChanges)
        {
            int id = HomeController.EditAssetFinanceAppID;
            var ExistingappAssetFinance = GetAppAssetFinance(id);

            if (ExistingappAssetFinance != null)
            {
                //Update Main application Partent part
                Context.Entry(ExistingappAssetFinance).CurrentValues.SetValues(AppAssetFinanceChanges);
                             
                // Delete children Individual
                foreach (var existingChild in ExistingappAssetFinance.individuals.ToList())
                {
                    if (!AppAssetFinanceChanges.individuals.Any(c => c.IndividualId == existingChild.IndividualId))
                    {
                        ExistingappAssetFinance.individuals.Remove(existingChild);
                    }
                }
                // Delete children Busniess
                foreach (var existingChildBusniess in ExistingappAssetFinance.busniesses.ToList())
                {
                    if (!AppAssetFinanceChanges.busniesses.Any(c => c.BusniessId == existingChildBusniess.BusniessId))
                    {
                        ExistingappAssetFinance.busniesses.Remove(existingChildBusniess);
                    }
                }
                // Update and Insert children Individual
                foreach (var Childindivdual in AppAssetFinanceChanges.individuals)
                {
                    var existingChild = ExistingappAssetFinance.individuals
                        .Where(c => c.IndividualId == Childindivdual.IndividualId && c.IndividualId != default(int))
                        .SingleOrDefault();

                    // Update child Individual (Inside There is PropertySchedule List)
                    if (existingChild != null)
                    {
                        Context.Entry(existingChild.personalDetails).CurrentValues.SetValues(Childindivdual.personalDetails);
                        Context.Entry(existingChild.addressDetails).CurrentValues.SetValues(Childindivdual.addressDetails);
                        Context.Entry(existingChild.employmentDetails).CurrentValues.SetValues(Childindivdual.employmentDetails);
                        Context.Entry(existingChild.monthlyIncome).CurrentValues.SetValues(Childindivdual.monthlyIncome);
                        Context.Entry(existingChild.monthlyExpenditure).CurrentValues.SetValues(Childindivdual.monthlyExpenditure);
                        Context.Entry(existingChild.asset).CurrentValues.SetValues(Childindivdual.asset);
                        Context.Entry(existingChild.liabilities).CurrentValues.SetValues(Childindivdual.liabilities);
                        //Context.Entry(existingChild.propertySchedule).CurrentValues.SetValues(Childindivdual.propertySchedule);

                        //Delete Individual Property
                        foreach (var existingChildIndividualProperty in existingChild.propertySchedule.ToList())
                        {                           
                            if (!Childindivdual.propertySchedule.Any(c => c.PropertyId == existingChildIndividualProperty.PropertyId))
                            {
                                existingChild.propertySchedule.Remove(existingChildIndividualProperty);
                            }
                        }
                        // Update and Insert Individual PropertDetails
                        foreach (var childProperty in Childindivdual.propertySchedule)
                        {
                            var existingChildProperty = existingChild.propertySchedule
                                .Where(c => c.PropertyId == childProperty.PropertyId && c.PropertyId != default(int))
                                .SingleOrDefault();
                            
                            // Update child Individual Property
                            if (existingChildProperty != null)
                            {
                                Context.Entry(existingChildProperty).CurrentValues.SetValues(childProperty);
                            }
                            // Insert child Individual Property
                            else
                            {
                                var Property = new PropertySchedule
                                {
                                    //PropertyId = childProperty.PropertyId,
                                    Owner= childProperty.Owner,
                                    PropertyAddress = childProperty.PropertyAddress,
                                    Lender = childProperty.Lender,
                                    PurchaseDate = childProperty.PurchaseDate,
                                    PurchasePrice = childProperty.PurchasePrice,
                                    OrigionalMortgageAmount = childProperty.OrigionalMortgageAmount,
                                    CurrentMarketValue = childProperty.CurrentMarketValue,
                                    OutstandingMortgage = childProperty.OutstandingMortgage,
                                    RemainingTerm = childProperty.RemainingTerm,
                                    TypeOfRate = childProperty.TypeOfRate,
                                    InterestRate = childProperty.InterestRate,
                                    RentPcm = childProperty.RentPcm,
                                    MortgagePcm = childProperty.MortgagePcm,
                                    LTV = childProperty.LTV,
                                    PropertyType = childProperty.PropertyType,
                                    PropertyDescription = childProperty.PropertyDescription,
                                    TypeOfTenancyLeaseASTBoth = childProperty.TypeOfTenancyLeaseASTBoth,
                                    RemainingTermOfLease = childProperty.RemainingTermOfLease,

                                };
                                existingChild.propertySchedule.Add(Property);
                            }
                        }

                        Context.Entry(existingChild.creditHistory).CurrentValues.SetValues(Childindivdual.creditHistory);
                        Context.Entry(existingChild.individualDocuments).CurrentValues.SetValues(Childindivdual.individualDocuments);
                    }

                    // Insert child Individual Property
                    else
                    {                       
                        var newChildAppAssetFinanceIndividual = new AppAssetFinanceIndividual.AppAssetFinanceIndividual
                        {
                            //IndividualId = Childindivdual.IndividualId,
                            personalDetails= Childindivdual.personalDetails,
                            addressDetails = Childindivdual.addressDetails,
                            employmentDetails = Childindivdual.employmentDetails,
                            monthlyIncome = Childindivdual.monthlyIncome,
                            monthlyExpenditure = Childindivdual.monthlyExpenditure,
                            asset = Childindivdual.asset,
                            liabilities = Childindivdual.liabilities,
                            propertySchedule = Childindivdual.propertySchedule,
                            creditHistory = Childindivdual.creditHistory,
                            individualDocuments = Childindivdual.individualDocuments
                        };
                        ExistingappAssetFinance.individuals.Add(newChildAppAssetFinanceIndividual);
                    }
                }
                // Update and Insert children Busniess
                foreach (var ChildBusniess in AppAssetFinanceChanges.busniesses)
                {
                    var existingChild = ExistingappAssetFinance.busniesses
                        .Where(c => c.BusniessId == ChildBusniess.BusniessId && c.BusniessId != default(int))
                        .SingleOrDefault();

                    // Update child Busniess
                    if (existingChild != null)
                    {
                       
                        Context.Entry(existingChild.busniessDetails).CurrentValues.SetValues(ChildBusniess.busniessDetails);
                        //Context.Entry(existingChild.keyPrincipals).CurrentValues.SetValues(ChildBusniess.keyPrincipals);
                        
                        //Delete Busniess KeyPrincipals
                        foreach (var existingChildBusniessKeyPrincipal in existingChild.keyPrincipals.ToList())
                        {
                            if (!ChildBusniess.keyPrincipals.Any(c => c.KeyPrincipalsId == existingChildBusniessKeyPrincipal.KeyPrincipalsId))
                            {
                                existingChild.keyPrincipals.Remove(existingChildBusniessKeyPrincipal);
                            }
                        }
                        // Update and Insert Busniess KeyPrincipals
                        foreach (var childKeyPrincipal in ChildBusniess.keyPrincipals)
                        {
                            var existingChildKeyPrincipal = existingChild.keyPrincipals
                                .Where(c => c.KeyPrincipalsId == childKeyPrincipal.KeyPrincipalsId && c.KeyPrincipalsId != default(int))
                                .SingleOrDefault();

                            // Update child Busniess KeyPrincipals
                            if (existingChildKeyPrincipal != null)
                            {
                                Context.Entry(existingChildKeyPrincipal).CurrentValues.SetValues(childKeyPrincipal);
                            }
                            // Insert child Busniess KeyPrincipals
                            else
                            {
                                var keyPrincipal = new KeyPrincipals
                                {
                                    //KeyPrincipalsId = childKeyPrincipal.KeyPrincipalsId,
                                    Title = childKeyPrincipal.Title,
                                    FirstName = childKeyPrincipal.FirstName,
                                    MiddleName = childKeyPrincipal.MiddleName,
                                    Surname = childKeyPrincipal.Surname,
                                    Position = childKeyPrincipal.Position,
                                    PercentageShareholding = childKeyPrincipal.PercentageShareholding                      
                                };
                                existingChild.keyPrincipals.Add(keyPrincipal);
                            }
                        }

                        //Context.Entry(existingChild.busniessLiabilities).CurrentValues.SetValues(ChildBusniess.busniessLiabilities);
                        
                        //Delete Busniess Liabilities
                        foreach (var existingChildBusniessLiabilities in existingChild.busniessLiabilities.ToList())
                        {
                            if (!ChildBusniess.busniessLiabilities.Any(c => c.BusniessLiabilityId == existingChildBusniessLiabilities.BusniessLiabilityId))
                            {
                                existingChild.busniessLiabilities.Remove(existingChildBusniessLiabilities);
                            }
                        }
                        // Update and Insert Busniess Liabilities
                        foreach (var childLiability in ChildBusniess.busniessLiabilities)
                        {
                            var existingChildLiability = existingChild.busniessLiabilities
                                .Where(c => c.BusniessLiabilityId == childLiability.BusniessLiabilityId && c.BusniessLiabilityId != default(int))
                                .SingleOrDefault();

                            // Update child Busniess Liabilities
                            if (existingChildLiability != null)
                            {
                                Context.Entry(existingChildLiability).CurrentValues.SetValues(childLiability);
                            }
                            // Insert child Busniess Liabilities
                            else
                            {
                                var Liability = new BusniessLiabilities.BusniessLiabilities
                                {
                                    //KeyPrincipalsId = childKeyPrincipal.KeyPrincipalsId,
                                    Lender = childLiability.Lender,
                                    OrigionalLoanAmount = childLiability.OrigionalLoanAmount,
                                    OutstandingBalance = childLiability.OutstandingBalance,
                                    MonthlyPayment = childLiability.MonthlyPayment,
                                    InitialTerm = childLiability.InitialTerm,
                                    RemainingTerm = childLiability.RemainingTerm,

                                    Rate = childLiability.Rate,
                                    FixedOrVariable = childLiability.FixedOrVariable,
                                    FixedTerm = childLiability.FixedTerm,
                                    CommitmentTerm = childLiability.CommitmentTerm,
                                    EarlyRepaymentCharge = childLiability.EarlyRepaymentCharge
                                };
                                existingChild.busniessLiabilities.Add(Liability);
                            }
                        }
                        //Context.Entry(existingChild.serviceability).CurrentValues.SetValues(ChildBusniess.serviceability);

                        //Context.Entry(existingChild.busniessDocuments).CurrentValues.SetValues(ChildBusniess.busniessDocuments);
                    }

                    // Insert child Busniess(ParentChild)
                    else
                    {
                        var newChildAppAssetFinanceBusniess = new AppAssetFinanceBusniess.AppAssetFinanceBusniess
                        {
                            //BusniessId = ChildBusniess.BusniessId,
                            busniessDetails = ChildBusniess.busniessDetails,
                            keyPrincipals = ChildBusniess.keyPrincipals,
                            busniessLiabilities = ChildBusniess.busniessLiabilities,
                            serviceability = ChildBusniess.serviceability,
                            busniessDocuments = ChildBusniess.busniessDocuments,
                            
                        };
                        ExistingappAssetFinance.busniesses.Add(newChildAppAssetFinanceBusniess);
                    }
                }
                Context.SaveChanges();
                return AppAssetFinanceChanges;
            }

            return AppAssetFinanceChanges;

            //var appAssetFinance = Context.AppAssetFinance.Attach(AppAssetFinanceChanges);
            //appAssetFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //Context.AppAssetFinance.Update(AppAssetFinanceChanges);
            //Context.SaveChanges();
        }
        public AppAssetFinance GetAppAssetFinance_appAssetFinance(int id)
        {
            AppAssetFinance appAssetFinance = Context.AppAssetFinance
               .Include(x => x.Lead)               
               .Where(h => h.AssetFinId == id)
               .FirstOrDefault();

            return appAssetFinance;
        }
    }
}
