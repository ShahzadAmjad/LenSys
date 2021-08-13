using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessUploadDocument
{
    public class MockBusniessDocumentsRepository : IBusniessDocumentsRepository
    {
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
            throw new NotImplementedException();
        }
    }
}
