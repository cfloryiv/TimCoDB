using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string binding { get; set; }
        [Required]
        public int numberPages { get; set; }
        [Required]
        public DateTime pubDate { get; set; }
        public int personID { get; set; }
        public DateTime date { get; set; }
    }
}
