using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.BusniessUploadDocument
{
    public interface IBusniessDocumentsRepository
    {
        BusniessDocuments Add(BusniessDocuments document);
        BusniessDocuments Delete(int id);
        BusniessDocuments GetBusniessDocument(int id);
        IEnumerable<BusniessDocuments> GetAllBusniessDocuments();
        IEnumerable<BusniessDocuments> ClearBusniessDocumentsList();
        IEnumerable<BusniessDocuments> SetBusniessDocumentsList(IEnumerable<BusniessDocuments> BusniessDocumentsList);

    }
}
