using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.DocumentList
{
    public class MockDocumentListRepository : IDocumentListRepository
    {
        public MockDocumentListRepository()
        {

        }
        public DocumentList Add(DocumentList lead)
        {
            throw new NotImplementedException();
        }
    }
}
