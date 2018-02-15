using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdditionOfStrings.Controllers
{
    [RoutePrefix("api/stringCalculator")]
    public class StringAdditionController : ApiController
    {
        public int Add(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Replace('\n', ',');
                var numbersArr = value.Split(',');
                if (numbersArr.Length == 1)
                {
                    return ParseNumber(numbersArr[0]);
                }
                if (numbersArr.Length > 1)
                {
                    int total = 0;
                    foreach (var item in numbersArr)
                    {
                        total = total + ParseNumber(item);
                    }
                    return total;
                }
            }
            return 0;
        }

        private int ParseNumber(string value)
        {
            int parsedValue;
            var isParsed = int.TryParse(value, out parsedValue);
            if (isParsed)
                return parsedValue;
            return 0;
        }
    }
}
