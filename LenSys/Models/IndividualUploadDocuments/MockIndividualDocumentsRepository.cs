using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualUploadDocuments
{
    public class MockIndividualDocumentsRepository : IindividualDocumentsRepository
    {
        public IEnumerable<IndividualDocuments> GetAllIndividualDocuments()
        {
            throw new NotImplementedException();
        }

        public IndividualDocuments GetIndividulDocument(int serviceabilityId)
        {
            throw new NotImplementedException();
        }

        public IndividualDocuments RemoveDocument(IndividualDocuments document)
        {
            throw new NotImplementedException();
        }

        public IndividualDocuments UploadDocument(IndividualDocuments document)
        {
            throw new NotImplementedException();
        }
    }
}
