using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapaportRestApi.Models.Utils
{
    public class GlobalConstants
    {
        //Data
        private static string DATA_PATH = (string)AppDomain.CurrentDomain.GetData("DataDirectory") + @"\";
        public static string CSV_FILE = DATA_PATH + "rapaprot-data.csv";

        //Request Parameters:
        public static string ADD_DIAMOND = "add_diamond";
        public static string GET_DIAMONDS = "get_diamonds";

        //Error Code Numbers:
        public static int ERR_CSV_NOT_FOUNDED = 401;
        public static int ERR_GET_DIAMONDS = 403;
        public static int ERR_ADD_DIAMOND = 405;

    }
}