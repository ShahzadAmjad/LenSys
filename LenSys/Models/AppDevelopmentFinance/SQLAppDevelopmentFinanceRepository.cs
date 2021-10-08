﻿using LenSys.Controllers;
using LenSys.Models.Home.AllApplications;
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

        public AppDevelopmentFinance AddBusniess(AppDevelopmentFinanceBusniess.AppDevelopmentFinanceBusniess busniess)
        {
            int id = HomeController.EditDevelopmentFinanceAppID;
            var appDevelopmentFinance = GetAppDevelopmentFinance(id); //Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("busniesses").FirstOrDefault();
            appDevelopmentFinance.busniesses.Add(busniess);
            Context.SaveChanges();
            return appDevelopmentFinance;
        }

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
            AppDevelopmentFinance appDevelopmentFinance = Context.AppDevelopmentFinance.Find(id);
            if (appDevelopmentFinance != null)
            {
                Context.AppDevelopmentFinance.Remove(appDevelopmentFinance);
                Context.SaveChanges();
            }
            return appDevelopmentFinance;
        }

        public IEnumerable<AppDevelopmentFinance> GetAllAppDevelopmentFinance()
        {
            return Context.AppDevelopmentFinance;
        }

        public IEnumerable<AllApplications> GetAllAppDevelopmentFinance_AllApplication()
        {
            throw new NotImplementedException();
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
