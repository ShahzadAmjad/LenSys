using LenSys.Models.AppAssetFinance;
using LenSys.Models.AppBusniessFinance;
using LenSys.Models.AppDevelopmentFinance;
using LenSys.Models.AppPropertyFinance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.AllApplications
{
    public class SQLAllApplicationsRepository : IAllApplicationsRepository
    {
        private IAppAssetFinanceRepository _appAssetFinanceRepository;
        private IAppBusniessFinanceRepository _appBusniessFinanceRepository;
        private IAppDevelopmentFinanceRepository _appDevelopmentFinanceRepository;
        private IAppPropertyFinanceRepository _appPropertyFinanceRepository;
        private readonly AppDbContext Context;
        public SQLAllApplicationsRepository(AppDbContext context, IAppAssetFinanceRepository appAssetFinanceRepository, IAppBusniessFinanceRepository appBusniessFinanceRepository, IAppDevelopmentFinanceRepository appDevelopmentFinanceRepository, IAppPropertyFinanceRepository appPropertyFinanceRepository)
        {
            Context = context;
            _appAssetFinanceRepository = appAssetFinanceRepository;
            _appBusniessFinanceRepository = appBusniessFinanceRepository;
            _appDevelopmentFinanceRepository = appDevelopmentFinanceRepository;
            _appPropertyFinanceRepository = appPropertyFinanceRepository;
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
            IEnumerable<AppAssetFinance.AppAssetFinance> appAssetFinanceLst = Context.AppAssetFinance.Where(h => h.AssetFinId == id).Include("Lead").Include("individuals").Include("busniesses");
            

            AppAssetFinance.AppAssetFinance appAssetFinance = appAssetFinanceLst.First(); //Context.AppAssetFinance.Find(id);
            if (appAssetFinance != null)
            {
                Context.AppAssetFinance.Remove(appAssetFinance);
                Context.SaveChanges();
            }
            return appAssetFinance;
        }

        public IEnumerable<AllApplications> GetAllApplications()
        {
            var appAssetFinanceApplication_AllAppFormat = _appAssetFinanceRepository.GetAllAppAssetFinance_AllApplication();
            var appBusinessFinanceApplication_AllAppFormat = _appBusniessFinanceRepository.GetAllAppBusniessFinance_AllApplication();
            var appDevelopmentFinanceApplication_AllAppFormat = _appDevelopmentFinanceRepository.GetAllAppDevelopmentFinance_AllApplication();
            var appPropertyFinanceApplication_AllAppFormat = _appPropertyFinanceRepository.GetAllAppPropertyFinance_AllApplication();

            var _allApplications = ((appAssetFinanceApplication_AllAppFormat.Concat(appBusinessFinanceApplication_AllAppFormat)
                .Concat(appDevelopmentFinanceApplication_AllAppFormat)).Concat(appPropertyFinanceApplication_AllAppFormat));
            //AllApplications app = appAssetFinanceApplication.FirstOrDefault();
            return _allApplications;
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
