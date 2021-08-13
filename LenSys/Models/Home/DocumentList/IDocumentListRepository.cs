using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.Home.DocumentList
{
    public interface IDocumentListRepository
    {
        DocumentList Add(DocumentList lead);
    }
}
