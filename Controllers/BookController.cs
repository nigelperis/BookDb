
using BookApp;
using BookApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataContext context;

        public BookController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return Ok(await this.context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> Get(int id)
        {
            var book = await this.context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            this.context.Books.Add(book);
            await this.context.SaveChangesAsync();
            return Ok(await this.context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
        {
            var dbBook = await this.context.Books.FindAsync(request.BookId);
            if (dbBook == null)
                return BadRequest("Book not found");


            dbBook.Title = request.Title;
            dbBook.Author = request.Author;
            dbBook.Price = request.Price;
            dbBook.CopiesInStock = request.CopiesInStock;

            await this.context.SaveChangesAsync();


            return Ok(await this.context.Books.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            {
                var dbBook = await this.context.Books.FindAsync(id);
                if (dbBook == null)
                    return BadRequest("Book not found");


                this.context.Books.Remove(dbBook);
                await this.context.SaveChangesAsync();

                return Ok(await this.context.Books.ToListAsync());
            }
        }
    }
}