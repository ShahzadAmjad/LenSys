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
                //new IndividualDocuments{DocumentId=1, DocumentPath="path", DocumentName="SampleDoc"}             
            };
        }
        public IEnumerable<IndividualDocuments> GetAllIndividualDocuments()
        {
            return _individualDocuments;
        }
        public IndividualDocuments GetIndividulDocument(int id)
        {
            return _individualDocuments.FirstOrDefault(e => e.DocumentId == id);
        }
        public IndividualDocuments Delete(int id)
        {
            IndividualDocuments individualDocuments = _individualDocuments.FirstOrDefault(e => e.DocumentId == id);
            if (individualDocuments != null)
            {
                _individualDocuments.Remove(individualDocuments);
            }
            return individualDocuments;
        }
        public IndividualDocuments Add(IndividualDocuments document)
        {
            if (_individualDocuments.Count == 0)
            {
                document.DocumentId = 1;
            }
            else
            {
                document.DocumentId = _individualDocuments.Max(e => e.DocumentId) + 1;
            }
            _individualDocuments.Add(document);
            return document;
        }
        public IEnumerable<IndividualDocuments> ClearIndividualDocumentsList()
        {
            _individualDocuments.Clear();
            return _individualDocuments;
        }

        public IEnumerable<IndividualDocuments> SetIndividualDocumentsList(IEnumerable<IndividualDocuments> IndividualDocumentsList)
        {
            _individualDocuments = (List<IndividualDocuments>)IndividualDocumentsList;
            return _individualDocuments;
        }
    }
}
