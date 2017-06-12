using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models.Results
{
    /// <summary>
    /// Generic Class for succeeding.
    /// </summary>
    public class ResultSuccess<R> : Result
    {
        public R Result { get; set; }
    }
}