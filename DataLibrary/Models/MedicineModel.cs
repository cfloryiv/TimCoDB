using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DataLibrary.Models
{
    /*    int ID;
    QString name;
    int pillSize;
    double cost;
    QString doctor;
    */
    public class MedicineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PillSize { get; set; }
        public Decimal Cost { get; set; }
        public string Doctor { get; set; }
    }
}
