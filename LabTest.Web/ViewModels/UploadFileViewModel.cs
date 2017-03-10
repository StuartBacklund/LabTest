using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTest.Web.ViewModels
{
    public class UploadFileViewModel
    {
        public int Id { get; set; }
        public string Parameters { get; set; }
        public int MaxOccurringNumber { get; set; }
        public int Occurrences { get; set; }
        public int Result { get; set; }
        public string Message { get; set; }
    }
}