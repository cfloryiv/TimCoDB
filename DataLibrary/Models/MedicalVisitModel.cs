using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*  int ID;
    QString date;
    QString doctor;
    QString notes;
    QString type;
    int personID;
    */
    public class MedicalVisitModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Doctor { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public int PersonID { get; set; }
    }
}
