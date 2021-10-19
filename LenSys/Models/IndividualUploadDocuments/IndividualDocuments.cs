using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LenSys.Models.IndividualUploadDocuments
{
    public class IndividualDocuments
    {
        [Key]
        public int DocumentId { get; set; }
        public int AppId { get; set; }
        public int IndividualIdId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public int DocumentGuid { get; set; }
        //public IFormFile Document { set; get; }
    }
}
