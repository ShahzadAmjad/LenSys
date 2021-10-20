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
                //new BusniessDocuments{DocumentId=1, DocumentPath="path", DocumentName="SampleDoc"}

            };
        }
        public IEnumerable<BusniessDocuments> GetAllBusniessDocuments()
        {
            return _busniessDocuments;
        }

        public BusniessDocuments GetBusniessDocument(int id)
        {
            return _busniessDocuments.FirstOrDefault(e => e.DocumentId == id);
        }
        public BusniessDocuments Delete(int id)
        {
            BusniessDocuments busniessDocuments = _busniessDocuments.FirstOrDefault(e => e.DocumentId == id);
            if (_busniessDocuments != null)
            {
                _busniessDocuments.Remove(busniessDocuments);
            }
            return busniessDocuments;
        }

        public BusniessDocuments Add(BusniessDocuments document)
        {
            if (_busniessDocuments.Count == 0)
            {
                document.DocumentId = 1;
            }
            else
            {
                document.DocumentId = _busniessDocuments.Max(e => e.DocumentId) + 1;
            }
            _busniessDocuments.Add(document);
            return document;
        }
        public IEnumerable<BusniessDocuments> ClearBusniessDocumentsList()
        {
            _busniessDocuments.Clear();
            return _busniessDocuments;
        }

        public IEnumerable<BusniessDocuments> SetBusniessDocumentsList(IEnumerable<BusniessDocuments> busniessDocumentsList)
        {
            _busniessDocuments = (List<BusniessDocuments>)busniessDocumentsList;
            return _busniessDocuments;
        }
    }
}
