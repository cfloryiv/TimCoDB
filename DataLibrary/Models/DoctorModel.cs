using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*    int ID;
    int personID;
    QString name;
    QString hospital;
    QString telNo;
    QString speciality;
    */

    public class DoctorModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Hospital { get; set; }
        public string TelNo { get; set; }
        public string Speciality { get; set; }
    }
}
