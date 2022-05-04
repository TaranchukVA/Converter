using System;
using System.Collections.Generic;

namespace Converter.Data.Params
{
    public class CbrData
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }

        public SortedDictionary<string, Valute> valute { get; set; }
    }
}
