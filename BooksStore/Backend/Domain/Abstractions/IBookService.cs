using Domain.Models;


namespace Domain.Abstractions
{
    public interface IBookService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> UpdateBook(Guid id, string title, string description, double price);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
    }
}
