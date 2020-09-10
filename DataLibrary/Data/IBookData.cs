using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IBookData
    {
        Task<List<BookModel>> GetBooks();
        Task<int> CreateBook(BookModel book);
        Task<BookModel> GetBookById(int bookId);
        Task<int> DeleteBook(int Id);
        Task<int> UpdateBook(BookModel book);
    }
}