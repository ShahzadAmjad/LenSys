using LenSys.Controllers;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.BusniessUploadDocument;
using LenSys.Models.Home.AllApplications;
using LenSys.Models.IndividualPropertySchedule;
using LenSys.Models.IndividualUploadDocuments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppDevelopmentFinance
{
    public class SQLAppDevelopmentFinanceRepository : IAppDevelopmentFinanceRepository
    {
        private readonly AppDbContext Context;

        public SQLAppDevelopmentFinanceRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDevelopmentFinance Add(AppDevelopmentFinance appDevelopmentFinance)
        {
            Context.AppDevelopmentFinance.Add(appDevelopmentFinance);
            Context.SaveChanges();
            return appDevelopmentFinance;
        }
        //Not Used
        public AppDevelopmentFinance AddBusniess(AppDevelopmentFinanceBusniess.AppDevelopmentFinanceBusniess busniess)
        {
            int id = HomeController.EditDevelopmentFinanceAppID;
            var appDevelopmentFinance = GetAppDevelopmentFinance(id); //Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("busniesses").FirstOrDefault();
            appDevelopmentFinance.busniesses.Add(busniess);
            Context.SaveChanges();
            return appDevelopmentFinance;
        }
        //Not Used
        public AppDevelopmentFinance AddIndividual(AppDevelopmentFinanceIndividual.AppDevelopmentFinanceIndividual individual)
        {
            int id = HomeController.EditDevelopmentFinanceAppID;
            var appDevelopmentFinance = GetAppDevelopmentFinance(id);
            appDevelopmentFinance.individuals.Add(individual);
            Context.SaveChanges();
            return appDevelopmentFinance;
        }

        public AppDevelopmentFinance Delete(int id)
        {
            AppDevelopmentFinance appDevelopmentFinance = GetAppDevelopmentFinance(id);

            if (appDevelopmentFinance != null)
            {
                Context.AppDevelopmentFinance.Remove(appDevelopmentFinance);
                Context.Entry(appDevelopmentFinance.Lead).State = EntityState.Deleted;

                if (appDevelopmentFinance.individuals.Count > 0)
                {
                    foreach (AppDevelopmentFinanceIndividual.AppDevelopmentFinanceIndividual individual in appDevelopmentFinance.individuals)
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
                        //Context.Entry(individual.individualDocuments).State = EntityState.Deleted;
                        //Delete Individual document List
                        foreach (IndividualUploadDocuments.IndividualDocuments Individualdocument in individual.individualDocuments)
                        {
                            Context.Entry(Individualdocument).State = EntityState.Deleted;
                        }
                    }
                }

                if (appDevelopmentFinance.busniesses.Count > 0)
                {
                    foreach (AppDevelopmentFinanceBusniess.AppDevelopmentFinanceBusniess busniess in appDevelopmentFinance.busniesses)
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

                        //Context.Entry(busniess.busniessDocuments).State = EntityState.Deleted;
                        //Delete Busniess Document List
                        foreach (BusniessUploadDocument.BusniessDocuments busniessDocument in busniess.busniessDocuments)
                        {
                            Context.Entry(busniessDocument).State = EntityState.Deleted;
                        }
                    }
                }
                if (appDevelopmentFinance.securityDetails.Count > 0)
                {
                    foreach (AppDevelopmentFinanceSecurityDetails security in appDevelopmentFinance.securityDetails)
                    {
                        Context.Entry(security).State = EntityState.Deleted;
                    }
                }
                Context.SaveChanges();
            }
            return appDevelopmentFinance;
        }

        public IEnumerable<AppDevelopmentFinance> GetAllAppDevelopmentFinance()
        {
            return Context.AppDevelopmentFinance.Include(x => x.Lead);
        }

        public IEnumerable<AllApplications> GetAllAppDevelopmentFinance_AllApplication()
        {
            List<AllApplications> allApplicationsList = new List<AllApplications>();
            allApplicationsList = Context.AppDevelopmentFinance.Include(x => x.Lead).Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName }).ToList();
            return allApplicationsList;
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance(int id)
        {
            AppDevelopmentFinance appDevelopmentFinance = Context.AppDevelopmentFinance
               .Include(x => x.Lead)
               .Include(x => x.securityDetails)
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
               .Where(h => h.LoanId == id)
               .FirstOrDefault();

            return appDevelopmentFinance;
            //return Context.AppDevelopmentFinance.Find(id);
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance_appDevelopmentFinance(int id)
        {
            AppDevelopmentFinance appDevelopmentFinance = Context.AppDevelopmentFinance
               .Include(x => x.Lead)
               .Where(h => h.LoanId == id)
               .FirstOrDefault();

            return appDevelopmentFinance;
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance_EditHome(int id)
        {
            //Without Lead
            AppDevelopmentFinance appDevelopmentFinance = Context.AppDevelopmentFinance
               .Include(x => x.securityDetails)
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
               .Where(h => h.LoanId == id)
               .FirstOrDefault();

            return appDevelopmentFinance;
        }

        public IEnumerable<AllApplications> SearchAppDevelopmentFinance(string SearchAttribute, string SearchParam)
        {

            List<AllApplications> allApplicationsList = new List<AllApplications>();
            allApplicationsList = Context.AppDevelopmentFinance.Include(x => x.Lead).Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName }).ToList();

            if (SearchAttribute == "Application Id")
            {
                int id = Int32.Parse(SearchParam);
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.LoanId == id)
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }
            else if (SearchAttribute == "Busniess Id")
            {
                int id = Int32.Parse(SearchParam);
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.busniesses.Any(c => c.BusniessId == id))
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }
            else if (SearchAttribute == "Individual Id")
            {
                int id = Int32.Parse(SearchParam);
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.individuals.Any(c => c.IndividualId == id))
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }
            else if (SearchAttribute == "First Name")
            {
                string id = SearchParam;
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.individuals.Any(c => c.personalDetails.FirstName == id))
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }
            else if (SearchAttribute == "Phone No")
            {
                int id = Int32.Parse(SearchParam);
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.individuals.Any(c => c.personalDetails.PhoneNo == id))
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }
            else if (SearchAttribute == "Company Name")
            {
                string id = SearchParam;
                allApplicationsList = Context.AppDevelopmentFinance
                    .Include(x => x.Lead)
                    .Where(h => h.busniesses.Any(c => c.busniessDetails.CompanyBusniessName == id))
                    .Select(p => new AllApplications { AppID = p.LoanId, LeadId = p.Lead.LeadId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName })
                    .ToList();
            }

            return allApplicationsList;
        }

        public AppDevelopmentFinance Update(AppDevelopmentFinance appDevelopmentFinanceChanges)
        {
            int id = HomeController.EditDevelopmentFinanceAppID;
            var ExistingappDevelopmentFinance = GetAppDevelopmentFinance(id);
            //Delete,Update,Insert Child & Sub child Entities

            if (ExistingappDevelopmentFinance != null)
            {
                //Update Main application Partent part
                Context.Entry(ExistingappDevelopmentFinance).CurrentValues.SetValues(appDevelopmentFinanceChanges);
                // Delete children Individual(ParentChild)
                foreach (var existingChild in ExistingappDevelopmentFinance.individuals.ToList())
                {
                    if (!appDevelopmentFinanceChanges.individuals.Any(c => c.IndividualId == existingChild.IndividualId))
                    {
                        ExistingappDevelopmentFinance.individuals.Remove(existingChild);

                        Context.Entry(existingChild).State = EntityState.Deleted;
                        Context.Entry(existingChild.personalDetails).State = EntityState.Deleted;
                        Context.Entry(existingChild.addressDetails).State = EntityState.Deleted;
                        Context.Entry(existingChild.employmentDetails).State = EntityState.Deleted;
                        Context.Entry(existingChild.monthlyIncome).State = EntityState.Deleted;
                        Context.Entry(existingChild.monthlyExpenditure).State = EntityState.Deleted;
                        Context.Entry(existingChild.asset).State = EntityState.Deleted;
                        Context.Entry(existingChild.liabilities).State = EntityState.Deleted;
                        //Delete Individual Properties
                        foreach (var existingChildIndividualProperty in existingChild.propertySchedule.ToList())
                        {
                            existingChild.propertySchedule.Remove(existingChildIndividualProperty);
                            Context.Entry(existingChildIndividualProperty).State = EntityState.Deleted;
                        }
                        Context.Entry(existingChild.creditHistory).State = EntityState.Deleted;
                        //Context.Entry(existingChild.individualDocuments).State = EntityState.Deleted;
                        //Delete Individual Documents
                        foreach (var existingChildIndividualDocument in existingChild.individualDocuments.ToList())
                        {
                            existingChild.individualDocuments.Remove(existingChildIndividualDocument);
                            Context.Entry(existingChildIndividualDocument).State = EntityState.Deleted;
                        }
                    }
                }
                // Delete children Busniess(ParentChild)
                foreach (var existingChildBusniess in ExistingappDevelopmentFinance.busniesses.ToList())
                {
                    if (!appDevelopmentFinanceChanges.busniesses.Any(c => c.BusniessId == existingChildBusniess.BusniessId))
                    {
                        ExistingappDevelopmentFinance.busniesses.Remove(existingChildBusniess);

                        Context.Entry(existingChildBusniess).State = EntityState.Deleted;

                        foreach (var keyPrincipals in existingChildBusniess.keyPrincipals.ToList())
                        {
                            existingChildBusniess.keyPrincipals.Remove(keyPrincipals);
                            Context.Entry(keyPrincipals).State = EntityState.Deleted;
                        }

                        foreach (var busniessLiabilities in existingChildBusniess.busniessLiabilities.ToList())
                        {
                            existingChildBusniess.busniessLiabilities.Remove(busniessLiabilities);
                            Context.Entry(busniessLiabilities).State = EntityState.Deleted;
                        }

                        foreach (var serviceability in existingChildBusniess.serviceability.ToList())
                        {
                            existingChildBusniess.serviceability.Remove(serviceability);
                            Context.Entry(serviceability).State = EntityState.Deleted;
                        }
                        //Remove Busniess Documents
                        foreach (var BusniesssDocument in existingChildBusniess.busniessDocuments.ToList())
                        {
                            existingChildBusniess.busniessDocuments.Remove(BusniesssDocument);
                            Context.Entry(BusniesssDocument).State = EntityState.Deleted;
                        }
                    }
                }
                // Delete children SecurityDetail(ParentChild)
                foreach (var existingChild in ExistingappDevelopmentFinance.securityDetails.ToList())
                {
                    if (!appDevelopmentFinanceChanges.securityDetails.Any(c => c.SecurityDetailsId == existingChild.SecurityDetailsId))
                    {
                        ExistingappDevelopmentFinance.securityDetails.Remove(existingChild);
                        Context.Entry(existingChild).State = EntityState.Deleted;
                    }
                }
                // Update and Insert children Individual(ParentChild)
                foreach (var Childindivdual in appDevelopmentFinanceChanges.individuals)
                {
                    var existingChild = ExistingappDevelopmentFinance.individuals
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
                                Context.Entry(existingChildIndividualProperty).State = EntityState.Deleted;
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
                                    Owner = childProperty.Owner,
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
                        
                        //Context.Entry(existingChild.individualDocuments).CurrentValues.SetValues(Childindivdual.individualDocuments);
                        //Delete Individual Document on update of parent child
                        foreach (var existingChildIndividualDocument in existingChild.individualDocuments.ToList())
                        {
                            if (!Childindivdual.individualDocuments.Any(c => c.DocumentId == existingChildIndividualDocument.DocumentId))
                            {
                                existingChild.individualDocuments.Remove(existingChildIndividualDocument);
                                Context.Entry(existingChildIndividualDocument).State = EntityState.Deleted;
                            }
                        }
                        // Update and Insert Individual Document on update of parent child
                        foreach (var childDocument in Childindivdual.individualDocuments)
                        {
                            var existingChildDocument = existingChild.individualDocuments
                                .Where(c => c.DocumentId == childDocument.DocumentId && c.DocumentId != default(int))
                                .SingleOrDefault();

                            // Update child Individual document
                            if (existingChildDocument != null)
                            {
                                Context.Entry(existingChildDocument).CurrentValues.SetValues(childDocument);
                            }
                            // Insert child Individual document
                            else
                            {
                                var document = new IndividualDocuments
                                {
                                    //DocumentId = childDocument.DocumentId,
                                    AppId = childDocument.AppId,
                                    IndividualId = childDocument.IndividualId,
                                    DocumentName = childDocument.DocumentName,
                                    DocumentType = childDocument.DocumentType,
                                    DocumentGuid = childDocument.DocumentGuid,
                                    DocumentPath = childDocument.DocumentPath
                                };
                                existingChild.individualDocuments.Add(document);
                            }
                        }

                    }

                    // Insert child Individual Property
                    else
                    {
                        var newChildAppDevelopmentFinanceIndividual = new AppDevelopmentFinanceIndividual.AppDevelopmentFinanceIndividual
                        {
                            //IndividualId = Childindivdual.IndividualId,
                            personalDetails = Childindivdual.personalDetails,
                            addressDetails = Childindivdual.addressDetails,
                            employmentDetails = Childindivdual.employmentDetails,
                            monthlyIncome = Childindivdual.monthlyIncome,
                            monthlyExpenditure = Childindivdual.monthlyExpenditure,
                            asset = Childindivdual.asset,
                            liabilities = Childindivdual.liabilities,
                            //propertySchedule = Childindivdual.propertySchedule,
                            creditHistory = Childindivdual.creditHistory,
                            //individualDocuments = Childindivdual.individualDocuments
                        };
                        //Inilizing List
                        // List<PropertySchedule> _propertySchedule = new List<PropertySchedule>(){};
                        newChildAppDevelopmentFinanceIndividual.propertySchedule = new List<PropertySchedule>() { };
                        newChildAppDevelopmentFinanceIndividual.individualDocuments = new List<IndividualDocuments>() { };
                        //Add Properties in new Individual(ParentChild) objects
                        foreach (var childProperty in Childindivdual.propertySchedule)
                        {
                            var Property = new PropertySchedule
                            {
                                //PropertyId = childProperty.PropertyId,
                                Owner = childProperty.Owner,
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
                            newChildAppDevelopmentFinanceIndividual.propertySchedule.Add(Property);
                        }
                        //Add Properties in new Individual(ParentChild) objects
                        foreach (var childDocument in Childindivdual.individualDocuments)
                        {
                            var document = new IndividualDocuments
                            {
                                //DocumentId = childDocument.DocumentId,
                                AppId = childDocument.AppId,
                                IndividualId = childDocument.IndividualId,
                                DocumentName = childDocument.DocumentName,
                                DocumentType = childDocument.DocumentType,
                                DocumentGuid = childDocument.DocumentGuid,
                                DocumentPath = childDocument.DocumentPath
                            };
                            newChildAppDevelopmentFinanceIndividual.individualDocuments.Add(document);
                        }
                        ExistingappDevelopmentFinance.individuals.Add(newChildAppDevelopmentFinanceIndividual);
                    }
                }
                // Update and Insert children Busniess(ParentChild)
                foreach (var ChildBusniess in appDevelopmentFinanceChanges.busniesses)
                {
                    var existingChild = ExistingappDevelopmentFinance.busniesses
                        .Where(c => c.BusniessId == ChildBusniess.BusniessId && c.BusniessId != default(int))
                        .SingleOrDefault();

                    // Update child Busniess(ParentChild)
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
                                Context.Entry(existingChildBusniessKeyPrincipal).State = EntityState.Deleted;
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
                                Context.Entry(existingChildBusniessLiabilities).State = EntityState.Deleted;
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

                        //Delete Busniess Serviceability
                        foreach (var existingChildBusniessServiceability in existingChild.serviceability.ToList())
                        {
                            if (!ChildBusniess.serviceability.Any(c => c.ServiceabilityId == existingChildBusniessServiceability.ServiceabilityId))
                            {
                                existingChild.serviceability.Remove(existingChildBusniessServiceability);
                                Context.Entry(existingChildBusniessServiceability).State = EntityState.Deleted;
                            }
                        }
                        // Update and Insert Busniess Serviceability
                        foreach (var childServiceability in ChildBusniess.serviceability)
                        {
                            var existingChildServiceability = existingChild.serviceability
                                .Where(c => c.ServiceabilityId == childServiceability.ServiceabilityId && c.ServiceabilityId != default(int))
                                .SingleOrDefault();

                            // Update child Busniess Serviceability
                            if (existingChildServiceability != null)
                            {
                                Context.Entry(existingChildServiceability).CurrentValues.SetValues(childServiceability);
                            }
                            // Insert child Busniess Serviceability
                            else
                            {
                                var _serviceability = new Serviceability
                                {
                                    //KeyPrincipalsId = childKeyPrincipal.KeyPrincipalsId,
                                    Year = childServiceability.Year,
                                    TurnOver = childServiceability.TurnOver,
                                    NetProfit = childServiceability.NetProfit,
                                    EBITDA = childServiceability.EBITDA

                                };
                                existingChild.serviceability.Add(_serviceability);
                            }
                        }

                        //Context.Entry(existingChild.busniessDocuments).CurrentValues.SetValues(ChildBusniess.busniessDocuments);

                        //Delete Busniess Documents
                        foreach (var existingChildBusniessDocument in existingChild.busniessDocuments.ToList())
                        {
                            if (!ChildBusniess.busniessDocuments.Any(c => c.DocumentId == existingChildBusniessDocument.DocumentId))
                            {
                                existingChild.busniessDocuments.Remove(existingChildBusniessDocument);
                                Context.Entry(existingChildBusniessDocument).State = EntityState.Deleted;
                            }
                        }
                        // Update and Insert Busniess Document
                        foreach (var childDocument in ChildBusniess.busniessDocuments)
                        {
                            var existingChildDocument = existingChild.busniessDocuments
                                .Where(c => c.DocumentId == childDocument.DocumentId && c.DocumentId != default(int))
                                .SingleOrDefault();

                            // Update child Busniess Serviceability
                            if (existingChildDocument != null)
                            {
                                Context.Entry(existingChildDocument).CurrentValues.SetValues(childDocument);
                            }
                            // Insert child Busniess Serviceability
                            else
                            {
                                var Document = new BusniessDocuments
                                {
                                    //DocumentId = childDocument.DocumentId,
                                    AppId = childDocument.AppId,
                                    BusniessId = childDocument.BusniessId,
                                    DocumentName = childDocument.DocumentName,
                                    DocumentGuid = childDocument.DocumentGuid,
                                    DocumentPath = childDocument.DocumentPath
                                };
                                existingChild.busniessDocuments.Add(Document);
                            }
                        }
                    }

                    // Insert child Busniess(ParentChild)
                    else
                    {
                        var newChildAppDevelopmentFinanceBusniess = new AppDevelopmentFinanceBusniess.AppDevelopmentFinanceBusniess
                        {
                            //BusniessId = ChildBusniess.BusniessId,
                            busniessDetails = ChildBusniess.busniessDetails
                            //newChildAppAssetFinanceBusniess.busniessDocuments = ChildBusniess.busniessDocuments;
                        };
                        newChildAppDevelopmentFinanceBusniess.keyPrincipals = new List<KeyPrincipals>() { };
                        newChildAppDevelopmentFinanceBusniess.busniessLiabilities = new List<BusniessLiabilities.BusniessLiabilities>() { };
                        newChildAppDevelopmentFinanceBusniess.serviceability = new List<Serviceability>() { };
                        //Inilize document List
                        newChildAppDevelopmentFinanceBusniess.busniessDocuments = new List<BusniessDocuments>() { };
                        //New add busniess Keyprincipal add
                        foreach (var childKeyPrincipal in ChildBusniess.keyPrincipals)
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
                            newChildAppDevelopmentFinanceBusniess.keyPrincipals.Add(keyPrincipal);
                        }
                        //New add busniess Liabilities add
                        foreach (var childLiability in ChildBusniess.busniessLiabilities)
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
                            newChildAppDevelopmentFinanceBusniess.busniessLiabilities.Add(Liability);
                        }
                        //New add busniess Serviceability add
                        foreach (var childServiceability in ChildBusniess.serviceability)
                        {
                            var _serviceability = new Serviceability
                            {
                                //KeyPrincipalsId = childKeyPrincipal.KeyPrincipalsId,
                                Year = childServiceability.Year,
                                TurnOver = childServiceability.TurnOver,
                                NetProfit = childServiceability.NetProfit,
                                EBITDA = childServiceability.EBITDA

                            };
                            newChildAppDevelopmentFinanceBusniess.serviceability.Add(_serviceability);
                        }
                        //New add busniess Document add
                        foreach (var childDocument in ChildBusniess.busniessDocuments)
                        {
                            var Document = new BusniessDocuments
                            {
                                //DocumentId = childDocument.DocumentId,
                                AppId = childDocument.AppId,
                                BusniessId = childDocument.BusniessId,
                                DocumentName = childDocument.DocumentName,
                                DocumentGuid = childDocument.DocumentGuid,
                                DocumentPath = childDocument.DocumentPath
                            };
                            newChildAppDevelopmentFinanceBusniess.busniessDocuments.Add(Document);
                        }
                        ExistingappDevelopmentFinance.busniesses.Add(newChildAppDevelopmentFinanceBusniess);
                    }
                }
                // Update and Insert children SecurityDetail(ParentChild)
                foreach (var ChildSecurityDetail in appDevelopmentFinanceChanges.securityDetails)
                {
                    var existingChild = ExistingappDevelopmentFinance.securityDetails
                        .Where(c => c.SecurityDetailsId == ChildSecurityDetail.SecurityDetailsId && c.SecurityDetailsId != default(int))
                        .SingleOrDefault();

                    // Update child SecurityDetail
                    if (existingChild != null)
                    {
                        Context.Entry(existingChild).CurrentValues.SetValues(ChildSecurityDetail);
                    }

                    // Insert child SecurityDetail
                    else
                    {
                        var newChildAppDevelopmentFinanceSecurityDetail = new AppDevelopmentFinanceSecurityDetails
                        {
                            //SecurityDetailsId = ChildSecurityDetail.SecurityDetailsId,                            
                            SecurityType = ChildSecurityDetail.SecurityType,
                            DescriptionOfProperty = ChildSecurityDetail.DescriptionOfProperty,
                            PropertyCurrentUse = ChildSecurityDetail.PropertyCurrentUse,           
                            NameOfPropertyOwner = ChildSecurityDetail.NameOfPropertyOwner,
                            Tenure = ChildSecurityDetail.Tenure,
                            YearsRemainingOnLeaseIfLeaseHold = ChildSecurityDetail.YearsRemainingOnLeaseIfLeaseHold,                           
                            AddressForPropertyOfSecurity = ChildSecurityDetail.AddressForPropertyOfSecurity,
                            SecondLineAddress = ChildSecurityDetail.SecondLineAddress,
                            City = ChildSecurityDetail.City,
                            PostCode = ChildSecurityDetail.PostCode
                        };
                        ExistingappDevelopmentFinance.securityDetails.Add(newChildAppDevelopmentFinanceSecurityDetail);
                    }
                }
                Context.SaveChanges();
                return appDevelopmentFinanceChanges;
            }

            //var appDevelopmentFinance = Context.AppDevelopmentFinance.Attach(appDevelopmentFinanceChanges);
            //appDevelopmentFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //Context.SaveChanges();
            return appDevelopmentFinanceChanges;
        }
    }
}
