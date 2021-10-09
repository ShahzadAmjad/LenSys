using LenSys.Controllers;
using LenSys.Models.BusniessKeyPrincipals;
using LenSys.Models.BusniessServiceability;
using LenSys.Models.Home.AllApplications;
using LenSys.Models.IndividualPropertySchedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.AppPropertyFinance
{
    public class SQLAppPropertyFinanceRepository : IAppPropertyFinanceRepository
    {
        private readonly AppDbContext Context;

        public SQLAppPropertyFinanceRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppPropertyFinance Add(AppPropertyFinance appPropertyFinance)
        {
            Context.AppPropertyFinance.Add(appPropertyFinance);
            Context.SaveChanges();
            return appPropertyFinance;
        }
        //Not used
        public AppPropertyFinance AddBusniess(AppPropertyFinanceBusniess.AppPropertyFinanceBusniess busniess)
        {
            int id = HomeController.EditPropertyFinanceAppID;
            var appPropertyFinance = GetAppPropertyFinance(id); //Context.AppPropertyFinance.Where(h => h.LoanId == id).Include("busniesses").FirstOrDefault();
            appPropertyFinance.busniesses.Add(busniess);
            Context.SaveChanges();
            return appPropertyFinance;
        }
        //not used
        public AppPropertyFinance AddIndividual(AppPropertyFinanceIndividual.AppPropertyFinanceIndividual individual)
        {
            int id = HomeController.EditPropertyFinanceAppID;
            var appPropertyFinance = GetAppPropertyFinance(id);
            appPropertyFinance.individuals.Add(individual);
            Context.SaveChanges();
            return appPropertyFinance;
        }

        public AppPropertyFinance Delete(int id)
        {
            AppPropertyFinance appPropertyFinance = GetAppPropertyFinance(id);
            if (appPropertyFinance != null)
            {
                Context.AppPropertyFinance.Remove(appPropertyFinance);
                Context.Entry(appPropertyFinance.Lead).State = EntityState.Deleted;

                if (appPropertyFinance.individuals.Count > 0)
                {
                    foreach (AppPropertyFinanceIndividual.AppPropertyFinanceIndividual individual in appPropertyFinance.individuals)
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

                if (appPropertyFinance.busniesses.Count > 0)
                {
                    foreach (AppPropertyFinanceBusniess.AppPropertyFinanceBusniess busniess in appPropertyFinance.busniesses)
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
            return appPropertyFinance;
        }

        public IEnumerable<AppPropertyFinance> GetAllAppPropertyFinance()
        {
            return Context.AppPropertyFinance.Include(x => x.Lead);
        }

        public IEnumerable<AllApplications> GetAllAppPropertyFinance_AllApplication()
        {
            List<AllApplications> allApplicationsList = new List<AllApplications>();
            allApplicationsList = Context.AppPropertyFinance.Include(x => x.Lead).Select(p => new AllApplications { AppID = p.LoanId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName }).ToList();
            return allApplicationsList;
        }

        public AppPropertyFinance GetAppPropertyFinance(int id)
        {
            return Context.AppPropertyFinance.Find(id);
        }

        public AppPropertyFinance GetAppPropertyFinance_appPropertyFinance(int id)
        {
            throw new NotImplementedException();
        }

        public AppPropertyFinance GetAppPropertyFinance_EditHome(int id)
        {
            throw new NotImplementedException();
        }

        public AppPropertyFinance Update(AppPropertyFinance appPropertyFinanceChanges)
        {
            var appPropertyFinance = Context.AppPropertyFinance.Attach(appPropertyFinanceChanges);
            appPropertyFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return appPropertyFinanceChanges;
        }
    }
}
