using RapaportRestApi.Models.Results;
using RapaportRestApi.Models.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RapaportRestApi.Models.CSV
{
    /// <summary>
    /// Very simple  Singletone class that read / write csv file 
    /// </summary>

    public class CSVEngine
    {
        private static CSVEngine _instance = null;

        private CSVEngine() { }
        /// <summary>
        /// Creating instance
        /// </summary>
        public static CSVEngine Instance()
        {
            if (_instance == null)
            {
                _instance = new CSVEngine();
            }
            return _instance;
        }

        /// <summary>
        /// Get all diamonds from csv
        /// Return Result class with list of diamonds
        /// </summary>
        public Result GetDiamonds()
        {
            try
            {
                //CSV file validation
                if (!IsCsvFileExist())
                {
                    return CSVNotFounded();
                }
                // Get All Diamonds from csv file
                var csvLines = File.ReadAllLines(GlobalConstants.CSV_FILE).Select(x => x.Split(','));
                var csv = from line in csvLines
                          select (from piece in line
                                  select piece).ToList();

                List<Diamond> diamonds = new List<Diamond>();

                //Add diamonds to list of diamonds
                foreach (var line in csv)
                {
                    diamonds.Add(new Diamond
                    {

                        Shape = line[0],
                        Size = float.Parse(line[1]), // Try catch surrounded if we getting invalid parameter 
                        Color = line[2],
                        Clarity = line[3],
                        Price = long.Parse(line[4]), // Try catch surrounded if we getting invalid parameter
                        ListPrice = long.Parse(line[5])// Try catch surrounded if we getting invalid parameter
                    });
                }
                // Check if we get diamonds, if not then return error result
                if (diamonds.Count > 0)
                {
                    return new ResultSuccess<List<Diamond>>
                    {
                        Success = true,
                        RequestName = GlobalConstants.GET_DIAMONDS,
                        Message = "Get All Diamonds Successfuly",
                        Result = diamonds
                    };
                }
                else
                {
                    return new ResultError
                    {
                        Success = false,
                        RequestName = GlobalConstants.GET_DIAMONDS,
                        ErrorCode = GlobalConstants.ERR_GET_DIAMONDS,
                        Message = "There is no diamonds"
                    };
                }
            }
            //Rapaport General Exception
            catch (RapaportException ex)
            {
                return new ResultError
                {
                    Success = false,
                    RequestName = GlobalConstants.GET_DIAMONDS,
                    ErrorCode = GlobalConstants.ERR_GET_DIAMONDS,
                    Message = ex.Message
                };
            }
        }
        /// <summary>
        /// Add Single Diamond
        /// Return Result
        /// </summary>
        public Result AddDiamond(Diamond diamond)
        {
            try
            {
                //CSV file validation
                if (!IsCsvFileExist())
                {
                    return CSVNotFounded();
                }

               
                var csvBuilder = new StringBuilder();
                var newLine = string.Format("{0},{1},{2},{3},{4},{5}", diamond.Shape, diamond.Size, diamond.Color, diamond.Clarity, diamond.Price, diamond.ListPrice);
                csvBuilder.AppendLine(newLine);
                File.AppendAllText(GlobalConstants.CSV_FILE, csvBuilder.ToString());

                return new ResultSuccess<DBNull>
                {
                    Success = true,
                    RequestName = GlobalConstants.ADD_DIAMOND,
                    Message = "Diamond inserted successfuly"
                };
            }
            catch (RapaportException ex)
            {
                return new ResultError
                {
                    Success = false,
                    RequestName = GlobalConstants.ADD_DIAMOND,
                    ErrorCode = GlobalConstants.ERR_ADD_DIAMOND,
                    Message = ex.Message
                };
            }
        }
        private bool IsCsvFileExist()
        {
            return File.Exists(GlobalConstants.CSV_FILE);
        }
        private Result CSVNotFounded()
        {
            return new ResultError
            {
                Success = false,
                ErrorCode = GlobalConstants.ERR_CSV_NOT_FOUNDED,
                RequestName = GlobalConstants.ADD_DIAMOND,
                Message = "CSV not founded"
            };
        }
    }
}