using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Genre { get; set; }
        public string Image {  get; set; }  
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Editions { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }   
        public int Review {  get; set; }
        public string Category { get; set; }
        public bool Status  { get; set; }

    }
}
