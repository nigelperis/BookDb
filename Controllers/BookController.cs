using BookApp;
using BookApp.Data;
using BookApp.Models;
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
        public async Task<ActionResult<List<Book>>> Get([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var book = await this.context.Books.FindAsync(id.Value);

                if (book == null)
                {
                    return StatusCode(204);
                }

                return Ok(book);
            }
            else
            {
                var books = await this.context.Books.ToListAsync();

                if (books == null || books.Count == 0)
                {
                    return StatusCode(204);
                }

                return Ok(books);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.context.Books.Add(book);
            var saveResult = await this.context.SaveChangesAsync();

            if (saveResult == 1)
            {
                return CreatedAtAction("Get", new { id = book.BookId }, book);
            }
            else
            {
                return BadRequest("An error occurred while adding the book");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(Book request)
        {
            var dbBook = await this.context.Books.FindAsync(request.BookId);

            if (dbBook == null)
            {
                this.context.Books.Add(request);
                await this.context.SaveChangesAsync();
                return CreatedAtAction("Get",new {id=request.BookId},request);
            }
            else
            {
                dbBook.Title = request.Title;
                dbBook.Author = request.Author;
                dbBook.Price = request.Price;
                dbBook.CopiesInStock = request.CopiesInStock;
            }

            var saveResult = await this.context.SaveChangesAsync();

            if (saveResult > 0)
            {
                return Ok(request); 
            }
            else
            {
                return BadRequest("Failed to update or create the book");
            }
        }
        [HttpDelete]
        public async Task<ActionResult<List<Book>>> DeleteBook([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var dbBook = await this.context.Books.FindAsync(id.Value);

                if (dbBook == null)
                {
                    return BadRequest("Book not found");
                }

                this.context.Books.Remove(dbBook);
            }
            else
            {
                var allBooks = await this.context.Books.ToListAsync();
                this.context.Books.RemoveRange(allBooks);
            }

            await this.context.SaveChangesAsync();

            return Ok(await this.context.Books.ToListAsync());
        }

    }
}