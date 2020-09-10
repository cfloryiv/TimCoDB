using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*
     *   QString item;
  QString date;
  QString qty;
  int ID;
  int personID;
     */
    public class TrackingModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public String Qty { get; set; }
        public int PersonID { get; set; }
        public string Item { get; set; }
        public string Depleted { get; set; }
        public DateTime DepletedDate { get; set; }
    }
}
