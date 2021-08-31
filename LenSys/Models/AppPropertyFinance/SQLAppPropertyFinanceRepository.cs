﻿using System;
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

        public AppPropertyFinance Delete(int id)
        {
            AppPropertyFinance appPropertyFinance = Context.AppPropertyFinance.Find(id);
            if (appPropertyFinance != null)
            {
                Context.AppPropertyFinance.Remove(appPropertyFinance);
                Context.SaveChanges();
            }
            return appPropertyFinance;
        }

        public IEnumerable<AppPropertyFinance> GetAllAppPropertyFinance()
        {
            return Context.AppPropertyFinance;
        }

        public AppPropertyFinance GetAppPropertyFinance(int id)
        {
            return Context.AppPropertyFinance.Find(id);
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