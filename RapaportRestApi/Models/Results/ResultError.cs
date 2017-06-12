using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models.Results
{
    /// <summary>
    /// Error Result class, inheritance result class
    /// </summary>
    public class ResultError : Result
    {
        public int ErrorCode { get; set; }
    }
}