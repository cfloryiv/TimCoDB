using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*
     *     int ID;
    QString name;
    QString date;
    int pillSize;
    double cost;
    int personID;
    int period;
    QString doctor;
     */
    public class RefillModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PillSize { get; set; }
        public decimal Cost { get; set; }
        public int PersonID { get; set; }
        public int Period { get; set; }
        public string Doctor { get; set; }
    }
}
