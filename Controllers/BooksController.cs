using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Library.DTOs;




namespace Library.Controllers{

    [Route("api/v1/library/[controller]")]
     public  class BooksController : Controller{

        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;


     public BooksController(LibraryDbContext context, IMapper mapper)
     {
           _context = context;
           _mapper = mapper;
           
         }
        //get all the books
        [HttpGet]
         public List<BookDTO> Get(){

            //var keeper = _mapper.Map<List<BookDTO>>( _context.Books.ToList());
            List<BookDTO> books = _mapper.Map<List<Book>, List<BookDTO>>(_context.Books.Include(db => db.Author).ToList());
         
         return books;
         }

         //Get books by id
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var book = this._context.Books.SingleOrDefault(ct =>ct.IdBook == id);
            if(book !=null){
                return Ok(book);

            }else{
                return NotFound();
            }
        }

///Get the books by name

     [HttpGet("name/{name}")]
         public IActionResult Get(string name){

             var keeper = this._context.Books
             .Where(ct=> string.Equals(ct.Title, name, StringComparison.CurrentCultureIgnoreCase))
            .ToArray();
            return Ok(keeper);      
         }

// POST api/values

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            this._context.Books.Add(book);
            this._context.SaveChanges();
            return Created($"library/books/{book.IdBook}", book);
        }


        // PUT: api/v1/library/authors/7
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( [FromRoute]int id, [FromBody] Book book)
        {
            if (id != book.IdBook)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookIdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book target = this._context.Books.SingleOrDefault(ct=> ct.IdBook ==id);
            if(target != null){
                this._context.Books.Remove(target);
                this._context.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

        private bool BookIdExists(long id) => _context.Books.Any(e => e.IdBook == id);
    }

}