using SampleWebAPI.DBModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleWebAPI.Repository
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetLatestBooks();
        BookModel GetBook(int BookId);
        IEnumerable<BookModel> GetBook(string keyword);
        Task<BookModel> AddNewBook(BookModel bookModel);
        Task<BookModel> UpdateBook(BookModel bookModel);
        Task<bool> DeleteBook(int bookId);
    }
}
