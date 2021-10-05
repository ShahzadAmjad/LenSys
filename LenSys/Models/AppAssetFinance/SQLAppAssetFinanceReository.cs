﻿using LenSys.Controllers;
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
            Context.AppAssetFinance.Add(appAssetFinance);
            Context.SaveChanges();
            return appAssetFinance;
        }

        public AppAssetFinance AddIndividual(AppAssetFinanceIndividual.AppAssetFinanceIndividual individual)
        {
            int id = HomeController.EditAssetFinanceAppID;
            //var appAssetFinance = Context.AppAssetFinance.Single(e => e.AssetFinId == id);
            //var appAssetFinance =Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("individuals").FirstOrDefault();
            var appAssetFinance=GetAppAssetFinance(id);
            appAssetFinance.individuals. Add(individual);
            Context.SaveChanges();
            return appAssetFinance;
        }
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

            if (appAssetFinance!=null)
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
            appAssetFinancesList= Context.AppAssetFinance.Include(x => x.Lead);
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
            //var appAssetFinance=new AppAssetFinance();

            var appAssetFinance = Context.AppAssetFinance.Attach(AppAssetFinanceChanges);
            appAssetFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Context.AppAssetFinance.Update(AppAssetFinanceChanges);




            Context.SaveChanges();
            return AppAssetFinanceChanges;
        }
    }
}
