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
                        Context.Entry(individual.individualDocuments).State = EntityState.Deleted;
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

                        Context.Entry(busniess.busniessDocuments).State = EntityState.Deleted;
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
            allApplicationsList = Context.AppDevelopmentFinance.Include(x => x.Lead).Select(p => new AllApplications { AppID = p.LoanId, Type = p.Lead.LoanPurpose, CompanyBusinessName = p.Lead.CompanyBusniessName }).ToList();
            return allApplicationsList;
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance(int id)
        {
            return Context.AppDevelopmentFinance.Find(id);
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance_appDevelopmentFinance(int id)
        {
            throw new NotImplementedException();
        }

        public AppDevelopmentFinance GetAppDevelopmentFinance_EditHome(int id)
        {
            throw new NotImplementedException();
        }

        public AppDevelopmentFinance Update(AppDevelopmentFinance appDevelopmentFinanceChanges)
        {
            var appDevelopmentFinance = Context.AppDevelopmentFinance.Attach(appDevelopmentFinanceChanges);
            appDevelopmentFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return appDevelopmentFinanceChanges;
        }
    }
}
