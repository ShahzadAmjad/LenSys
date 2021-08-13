using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.ViewModels.IndividualUploadDocuments
{
    public class IndividualDocumentsViewModel
    {
        //public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        //public string DocumentPath { get; set; }
        public IFormFile Document { set; get; }
    }
}
