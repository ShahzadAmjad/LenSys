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
            Context.Lead.Add(lead);
            Context.SaveChanges();
            return lead;

        }

        public IEnumerable<Lead> ClearLeadList()
        {
            throw new NotImplementedException();
        }

        public Lead Delete(int id)
        {
            Lead lead = GetLead(id);
            if (lead != null)
            {
                Context.Lead.Remove(lead);
                Context.SaveChanges();
            }
            return lead;
        }

        public IEnumerable<Lead> GetAllLeads()
        {
            return Context.Lead;
        }

        public Lead GetLead(int Id)
        {
            Lead lead = Context.Lead.Find(Id);
            return lead;
        }

        public IEnumerable<Lead> SetLeadList(IEnumerable<Lead> LeadList)
        {
            throw new NotImplementedException();
        }

        public Lead Update(Lead leadChanges)
        {
            var lead = Context.Lead.Attach(leadChanges);
            lead.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return leadChanges;
        }
    }
}
