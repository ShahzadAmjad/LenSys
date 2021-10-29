using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LenSys.Models.Home.Lead;

namespace LenSys.Models.Home.Lead
{
    public class SQLLeadRepository : ILeadRepository
    {
        private readonly AppDbContext Context;
        public SQLLeadRepository(AppDbContext context)
        {
            Context = context;
        }

        public Lead Add(Lead lead)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lead> ClearLeadList()
        {
            throw new NotImplementedException();
        }

        public Lead Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lead> GetAllLeads()
        {
            throw new NotImplementedException();
        }

        public Lead GetLead(int serviceabilityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lead> SetLeadList(IEnumerable<Lead> LeadList)
        {
            throw new NotImplementedException();
        }

        public Lead Update(Lead lead)
        {
            throw new NotImplementedException();
        }
    }
}
