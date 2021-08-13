using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessUploadDocument
{
    public interface IBusniessDocumentsRepository
    {
        BusniessDocuments UploadDocument(BusniessDocuments document);
        BusniessDocuments RemoveDocument(BusniessDocuments document);

        BusniessDocuments GetBusniessDocument(int serviceabilityId);
        IEnumerable<BusniessDocuments> GetAllBusniessDocuments();
    }
}
