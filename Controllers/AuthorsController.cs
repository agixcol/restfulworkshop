using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.DTOs;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/v1/library/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(LibraryDbContext context, IMapper mapper){

            _context = context; 
            _mapper = mapper;
        }

        // GET all authors
        //List<AuthorDTO>
        [HttpGet]
        public List<AuthorDTO> Get()
        {
            List<AuthorDTO> uthor = _mapper.Map<List<Author>, List<AuthorDTO>>(_context.Authors.Include(db => db.Books).ToList());
            return uthor;    
        }
    
        // GET author by name
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
           
            var author = this._context.Authors
                .Where(t => 
                       t.AuthorName.ToLower().Contains(name.ToLower()) || 
                       t.AuthorLastName.ToLower().Contains(name.ToLower())).ToArray();

            return Ok(author);      
        }
        
            // GET author by id
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try{
                var author = _context.Authors.Where(x=> x.AuthorId == id).Include(x=> x.Books).FirstOrDefault();
                return Ok(author);
            
            }catch(Exception e){
                return Ok(e.Message);
            }
           
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            this._context.Authors.Add(author);
            this._context.SaveChanges();
            return Created($"library/authors/{author.AuthorId}", author);
        }

        // PUT: api/v1/library/authors/7
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( [FromRoute]int id, [FromBody] Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorIdExists(id))
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
            Author target = this._context.Authors.SingleOrDefault(ct=> ct.AuthorId ==id);
            if(target != null){
                this._context.Authors.Remove(target);
                this._context.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

        private bool AuthorIdExists(long id) => _context.Authors.Any(e => e.AuthorId == id);
    }
}