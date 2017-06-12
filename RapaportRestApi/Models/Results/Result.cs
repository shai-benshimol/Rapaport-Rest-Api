using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models.Results
{ /// <summary>
  /// Result class
  /// </summary>
    public class Result
    {
        public bool Success { get; set; }
        public string RequestName { get; set; }
        public string Message { get; set; }
    }
}