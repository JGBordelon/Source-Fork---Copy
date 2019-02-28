using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Psych1 {
    /// <summary>
    /// Class to store one CSV row
    /// </summary>
    public class CsvRow : List<string> {
        public string LineText { get; set; }
    }
}