using Domain.Abstractions;
using Domain.Models;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _booksRepository;
        public BookService(IBookRepository bookRepository)
        {
            _booksRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, double price)
        {
            return await _booksRepository.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepository.Delete(id);
        }
    }
}
