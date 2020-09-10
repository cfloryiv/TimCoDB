using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*     int ID;
    QString platform;
    QString name;
    QString author;
    double cost;
    int personID;
    QString date;
    */

    public class CourseModel
    {
        public int ID { get; set; }
        public string Platform { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Decimal Cost { get; set; }
        public int PersonID { get; set; }
        public DateTime Date { get; set; }
    }
}
