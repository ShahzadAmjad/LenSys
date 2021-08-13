using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualUploadDocuments
{
    public interface IindividualDocumentsRepository
    {
        IndividualDocuments UploadDocument(IndividualDocuments document);
        IndividualDocuments RemoveDocument(IndividualDocuments document);
        IndividualDocuments GetIndividulDocument(int serviceabilityId);
        IEnumerable<IndividualDocuments> GetAllIndividualDocuments();
    }
}
