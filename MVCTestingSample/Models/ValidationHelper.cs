using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCTestingSample.Models
{
    public static class ValidationHelper
    {
        public static bool IsValidPrice(string price)
        {
            if(price == string.Empty)
            {
                return false;
            }
            Regex pattern = new Regex(@"^\$?\d{0,}\.?(\d{1,})?$");
            return pattern.IsMatch(price);
        }
    }
}
