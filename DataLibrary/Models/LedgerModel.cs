using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class LedgerModel
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string ClassID { get; set; }
        public int Year { get; set; }
        public decimal Budget { get; set; }
        public decimal Actual { get; set; }
    }
}
