using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Entities.Messages
{
    public class ErrorMessages
    {
        public string UnableToRetrieveApiData { get; } = "Unable to retrieve data from the Api";
        public string InvalidCurrencyCode { get; } = "The provided currency code is invalid";
    }
}
