using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualUploadDocuments
{
    public interface IindividualDocumentsRepository
    {
        IndividualDocuments Add(IndividualDocuments document);
        IndividualDocuments Delete(int id);
        IndividualDocuments GetIndividulDocument(int id);
        IEnumerable<IndividualDocuments> GetAllIndividualDocuments();
        IEnumerable<IndividualDocuments> ClearIndividualDocumentsList();
        IEnumerable<IndividualDocuments> SetIndividualDocumentsList(IEnumerable<IndividualDocuments> IndividualDocumentsList);
    }
}
