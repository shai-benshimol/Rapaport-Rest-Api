using RapaportRestApi.Models;
using RapaportRestApi.Models.CSV;
using RapaportRestApi.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RapaportRestApi.Controllers
{
    public class DiamondController : ApiController
    {

        private CSVEngine csvEngine = CSVEngine.Instance();

        //Return All Diamonds From CSV File
        public Result Get()
        {
            return csvEngine.GetDiamonds();
        }

        //Add new Diamond to CSV File
        public Result Post([FromBody]Diamond diamond)
        {
            return csvEngine.AddDiamond(diamond);
        }
    }
}
