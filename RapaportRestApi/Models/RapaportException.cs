using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models
{
    [Serializable]
    public class RapaportException : Exception
    {
        public RapaportException(string message)
        : base(String.Format("Error: ", message))
        {

        }
    }
}