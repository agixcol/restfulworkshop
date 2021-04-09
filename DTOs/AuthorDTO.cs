using System.Collections.Generic;
using Library.Models;
using Library.DTOs;

namespace Library.DTOs
{
    public class AuthorDTO
    {
  
        public int Id {get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }   
        public string Email { get; set; }
        public List<BookDTO> Books { get; set; }
    }

    
}