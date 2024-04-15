﻿using BooksStoreApi.Contacts;
using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookResponce>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            var response = books.Select(b => new BookResponce(b.Id, b.Title, b.Description, b.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _bookService.CreateBook(book);

            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBooks(Guid id, [FromBody] BookRequest request)
        {
            var bookId = await _bookService.UpdateBook(id, request.Title, request.Description, request.Price);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    }
}
