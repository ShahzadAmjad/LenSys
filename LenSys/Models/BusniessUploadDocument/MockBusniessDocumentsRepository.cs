using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessUploadDocument
{
    public class MockBusniessDocumentsRepository : IBusniessDocumentsRepository
    {
        private List<BusniessDocuments> _busniessDocuments;

        public MockBusniessDocumentsRepository()
        {
            _busniessDocuments = new List<BusniessDocuments>()
            {
                new BusniessDocuments{DocumentId=1, DocumentPath="path", DocumentName="SampleDoc"}

            };
        }
        public IEnumerable<BusniessDocuments> GetAllBusniessDocuments()
        {
            throw new NotImplementedException();
        }

        public BusniessDocuments GetBusniessDocument(int serviceabilityId)
        {
            throw new NotImplementedException();
        }

        public BusniessDocuments RemoveDocument(BusniessDocuments document)
        {
            throw new NotImplementedException();
        }

        public BusniessDocuments UploadDocument(BusniessDocuments document)
        {
            document.DocumentId = _busniessDocuments.Max(e => e.DocumentId) + 1;
            _busniessDocuments.Add(document);
            return document;
        }
    }
}
