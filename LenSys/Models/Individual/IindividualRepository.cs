using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Individual
{
    public interface IindividualRepository
    {
        Individual GetIndividual(int IndividualId);
        IEnumerable<Individual> GetAllIndividual();
        Individual Add(Individual individual);
        Individual Update(Individual individualchanges );
        Individual Delete(int IndividualId);
    }
}
