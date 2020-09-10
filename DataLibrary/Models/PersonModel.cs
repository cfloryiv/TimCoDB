using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    /*
     *     int ID;
    QString name;
    QString username;
    QString password;
    */
    public class PersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
