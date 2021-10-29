using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LenSys.Models.Home.Lead;

namespace LenSys.Models.Home
{
    public interface ILeadRepository
    {
        Lead.Lead Add(Lead.Lead lead);
        IEnumerable<Lead.Lead> ClearLeadList();
        IEnumerable<Lead.Lead> SetLeadList(IEnumerable<Lead.Lead> LeadList);
        Lead.Lead GetLead(int serviceabilityId);
        IEnumerable<Lead.Lead> GetAllLeads();
        Lead.Lead Update(Lead.Lead lead);
        Lead.Lead Delete(int id);
       
    }
}
