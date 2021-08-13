using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualUploadDocuments
{
    public class MockIndividualDocumentsRepository : IindividualDocumentsRepository
    {
        private List<IndividualDocuments> _individualDocuments;
        public MockIndividualDocumentsRepository()
        {
            _individualDocuments = new List<IndividualDocuments>()
            {
                new IndividualDocuments{DocumentId=1, DocumentPath="path", DocumentName="SampleDoc"}
                
            };
        }
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
            document.DocumentId = _individualDocuments.Max(e => e.DocumentId) + 1;
            _individualDocuments.Add(document);
            return document;
        }
    }
}
