using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public class SQLAllApplicationsRepository : IAllApplicationsRepository
    {
        private readonly AppDbContext Context;
        public SQLAllApplicationsRepository(AppDbContext context)
        {
            Context = context;
        }
        public AllApplications Add(AllApplications Applications)
        {
            throw new NotImplementedException();
        }

        public AllApplications Delete(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public AppAssetFinance.AppAssetFinance DeleteAssetFinanceApplication(int id)
        {
            AppAssetFinance.AppAssetFinance appAssetFinance = Context.AppAssetFinance.Find(id);
            if (appAssetFinance != null)
            {
                Context.AppAssetFinance.Remove(appAssetFinance);
                Context.SaveChanges();
            }
            return appAssetFinance;
        }

        public IEnumerable<AllApplications> GetAllApplications()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppAssetFinance.AppAssetFinance> GetAllAssetFinanceApplication()
        {
            return Context.AppAssetFinance;
        }

        public AllApplications GetApplication(int KeyPrincipalsId)
        {
            throw new NotImplementedException();
        }

        public AppAssetFinance.AppAssetFinance GetAssetFinanceApplication(int Id)
        {
            return Context.AppAssetFinance.Find(Id);
        }

        public AllApplications Update(AllApplications ApplicationsChanges)
        {
            throw new NotImplementedException();
        }
    }
}
