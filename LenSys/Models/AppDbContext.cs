using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LenSys.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<AppAssetFinance.AppAssetFinance> AppAssetFinance { get; set; }
        public DbSet<AppBusniessFinance.AppBusniessFinance> AppBusniessFinance { get; set; }
        public DbSet<AppDevelopmentFinance.AppDevelopmentFinance> AppDevelopmentFinance { get; set; }
        public DbSet<AppPropertyFinance.AppPropertyFinance> AppPropertyFinance { get; set; }

    }
}
