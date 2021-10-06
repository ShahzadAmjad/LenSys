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
                //Update Main application Part
                Context.Entry(ExistingappAssetFinance).CurrentValues.SetValues(AppAssetFinanceChanges);
                //var appAssetFinance = Context.AppAssetFinance.Attach(AppAssetFinanceChanges);
                //appAssetFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // Delete children Individual
                foreach (var existingChild in ExistingappAssetFinance.individuals.ToList())
                {
                    if (!AppAssetFinanceChanges.individuals.Any(c => c.IndividualId == existingChild.IndividualId))
                    {
                        //Context.AppAssetFinance..Remove(existingChild);
                        ExistingappAssetFinance.individuals.Remove(existingChild);
                    }
                }
                // Delete children Busniess
                foreach (var existingChildBusniess in ExistingappAssetFinance.busniesses.ToList())
                {
                    if (!AppAssetFinanceChanges.busniesses.Any(c => c.BusniessId == existingChildBusniess.BusniessId))
                    {
                        //Context.AppAssetFinance..Remove(existingChild);
                        ExistingappAssetFinance.busniesses.Remove(existingChildBusniess);
                    }
                }


                // Update and Insert children Individual
                foreach (var Childindivdual in AppAssetFinanceChanges.individuals)
                {
                    //Hint: Remove inner childs of Individual and then insert
                    var existingChild = ExistingappAssetFinance.individuals
                .Where(c => c.IndividualId == Childindivdual.IndividualId && c.IndividualId != default(int))
                .SingleOrDefault();

                    // Update child
                    if (existingChild != null)
                    {
                        Context.Entry(existingChild).CurrentValues.SetValues(Childindivdual);
                    }

                    // Insert child
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

                    // Update child
                    if (existingChild != null)
                    {
                        //Hint: Remove inner childs of Busniess
                        Context.Entry(existingChild).CurrentValues.SetValues(ChildBusniess);
                       
                    }

                    // Insert child
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


            //appAssetFinance.individuals.Add(individual);
            //var appAssetFinance=new AppAssetFinance();

            //var appAssetFinance = Context.AppAssetFinance.Attach(AppAssetFinanceChanges);
            //appAssetFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Context.AppAssetFinance.Update(AppAssetFinanceChanges);

            //Context.SaveChanges();
            //
        }
//public AppAssetFinance GetAppAssetFinance_appAssetFinance(int KeyPrincipalsId)
//        {
//            throw new NotImplementedException();
//        }

        
        

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
