using LenSys.Models.Home;
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

        public AppAssetFinance Delete(int id)
        {
            AppAssetFinance appAssetFinance = Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("Lead").Include("individuals").Include("busniesses").FirstOrDefault(); //Context.AppAssetFinance.Find(id);
            if (appAssetFinance!=null)
            {
                Context.AppAssetFinance.Remove(appAssetFinance);
                Context.SaveChanges();
            }
            return appAssetFinance;
        }

        public IEnumerable<AppAssetFinance> GetAllAppAssetFinance()
        {
            return Context.AppAssetFinance;
        }

        public AppAssetFinance GetAppAssetFinance(int id)
        {
             AppAssetFinance appAssetFinance = Context.AppAssetFinance.Where(h => h.AssetFinId==id).Include("Lead").Include("individuals").Include("busniesses").FirstOrDefault();

            //ThenInclude("PersonalDetails")
           // return Context.AppAssetFinance.Find(id);
            //AppAssetFinanceIndividual.AppAssetFinanceIndividual individual = new AppAssetFinanceIndividual.AppAssetFinanceIndividual();

            //individual = Context.a


            return appAssetFinance;
        }

        public AppAssetFinance Update(AppAssetFinance AppAssetFinanceChanges)
        {
            var appAssetFinance= Context.AppAssetFinance.Attach(AppAssetFinanceChanges);
            appAssetFinance.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return AppAssetFinanceChanges;
        }
    }
}
