using LenSys.Controllers;
using LenSys.Models.AppBusniessFinance.AppBusniessFinanceBusniess;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.Home.AllApplications;
using LenSys.Models.IndividualPropertySchedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppBusniessFinance
{
    public class SQLAppBusniessFinanceRepository : IAppBusniessFinanceRepository
    {
        private readonly AppDbContext Context;

        public SQLAppBusniessFinanceRepository(AppDbContext context)
        {
            Context = context;
        }        
        public AppBusniessFinance Add(AppBusniessFinance appBusniessFinance)
        {
            Context.AppBusniessFinance.Add(appBusniessFinance);
            Context.SaveChanges();
            return appBusniessFinance;
        }
        //Not Used
        public AppBusniessFinance AddBusniess(AppBusniessFinanceBusniess.AppBusniessFinanceBusniess busniess)
        {
            int id = HomeController.EditBusinessFinanceAppID;
            var appBusniessFinance = GetAppBusniessFinance(id);
            appBusniessFinance.busniesses.Add(busniess);
            Context.SaveChanges();
            return appBusniessFinance;
        }
        //Not Used
        public AppBusniessFinance AddIndividual(AppBusniessFinanceIndividual.AppBusniessFinanceIndividual individual)
        {
            int id = HomeController.EditBusinessFinanceAppID;
            var appBusniessFinance = GetAppBusniessFinance(id);
            appBusniessFinance.individuals.Add(individual);
            Context.SaveChanges();
            return appBusniessFinance;
        }

        public AppBusniessFinance Delete(int id)
        {
            AppBusniessFinance appBusniessFinance = GetAppBusniessFinance(id);
            if (appBusniessFinance != null)
            {
                Context.AppBusniessFinance.Remove(appBusniessFinance);
                Context.Entry(appBusniessFinance.Lead).State = EntityState.Deleted;
                
                if (appBusniessFinance.individuals.Count > 0)
                {
                    foreach (AppBusniessFinanceIndividual.AppBusniessFinanceIndividual individual in appBusniessFinance.individuals)
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

                if (appBusniessFinance.busniesses.Count > 0)
                {
                    foreach (AppBusniessFinanceBusniess.AppBusniessFinanceBusniess busniess in appBusniessFinance.busniesses)
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
            return appBusniessFinance;
        }

        public IEnumerable<AppBusniessFinance> GetAllAppBusniessFinance()
        {
            return Context.AppBusniessFinance.Include(x => x.Lead);
        }

        public IEnumerable<AllApplications> GetAllAppBusniessFinance_AllApplication()
        {
            List<AllApplications> allApplicationsList = new List<AllApplications>();
            allApplicationsList = Context.AppBusniessFinance.Include(x => x.Lead).Select(p => new AllApplications { AppID = p.BusniessFinId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName }).ToList();
            return allApplicationsList;
        }

        public AppBusniessFinance GetAppBusniessFinance(int id)
        {
            AppBusniessFinance appBusniessFinance = Context.AppBusniessFinance
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
               .Where(h => h.BusniessFinId == id)
               .FirstOrDefault();

            return appBusniessFinance;
            //return Context.AppBusniessFinance.Find(id);
        }

        public AppBusniessFinance GetAppBusniessFinance_appBusniessFinance(int id)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinance GetAppBusniessFinance_EditHome(int id)
        {
            //Without Lead
            AppBusniessFinance appBusniessFinance = Context.AppBusniessFinance
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
               .Where(h => h.BusniessFinId == id)
               .FirstOrDefault();

            return appBusniessFinance;
        }

        public AppBusniessFinance Update(AppBusniessFinance appBusniessFinanceChanges)
        {
            var appBusniessFinance = Context.AppBusniessFinance.Attach(appBusniessFinanceChanges);
            appBusniessFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return appBusniessFinanceChanges;
        }
    }
}
