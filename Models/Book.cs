using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Column("IdBook")]
        [Key]
        public int IdBook{get; set;}

        [Column("IdAuthor")]
        public int AuthorId {get; set;}
        public string Title { get; set; }   
        public string Description { get; set; }
        public string Section { get; set; } 
        public string Genre { get; set; }
        public int Year { get; set; }   
        public string Publisher { get; set; }      

       public Author Author { get; set; }
    }
} 