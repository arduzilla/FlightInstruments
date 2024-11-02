using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace FlightInstruments
{
    public static class CondorMessageParser
    {
        public static string Parse(string condorDataLine)
        {
            var dataRow = new Dictionary<string, string>();

            // Split the line on semicolons to get each parameter=value pair
            var entries = condorDataLine.Split(';');

            foreach (var entry in entries)
            {
                // Split each entry on '=' to separate the key and value
                var keyValue = entry.Split('=');
                if (keyValue.Length == 2) // Ensure valid key-value pair
                {
                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim();
                    dataRow[key] = value;
                }
            }

            // Convert the dictionary to a JSON string
            return JsonConvert.SerializeObject(dataRow, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
