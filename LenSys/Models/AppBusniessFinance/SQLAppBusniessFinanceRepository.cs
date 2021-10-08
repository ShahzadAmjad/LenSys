using LenSys.Models.Home.AllApplications;
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

        public AppBusniessFinance AddBusniess(AppBusniessFinanceBusniess.AppBusniessFinanceBusniess busniess)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinance AddIndividual(AppBusniessFinanceIndividual.AppBusniessFinanceIndividual individual)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinance Delete(int id)
        {
            AppBusniessFinance appBusniessFinance = Context.AppBusniessFinance.Find(id);
            if (appBusniessFinance != null)
            {
                Context.AppBusniessFinance.Remove(appBusniessFinance);
                Context.SaveChanges();
            }
            return appBusniessFinance;
        }

        public IEnumerable<AppBusniessFinance> GetAllAppBusniessFinance()
        {
            return Context.AppBusniessFinance;
        }

        public IEnumerable<AllApplications> GetAllAppBusniessFinance_AllApplication()
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinance GetAppBusniessFinance(int id)
        {
            return Context.AppBusniessFinance.Find(id);
        }

        public AppBusniessFinance GetAppBusniessFinance_appBusniessFinance(int id)
        {
            throw new NotImplementedException();
        }

        public AppBusniessFinance GetAppBusniessFinance_EditHome(int id)
        {
            throw new NotImplementedException();
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
