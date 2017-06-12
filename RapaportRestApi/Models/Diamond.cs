using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models
{
    public class Diamond
    {
        public string Shape { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public float Size { get; set; }
        public long Price { get; set; }
        public long ListPrice { get; set; }

    }
}