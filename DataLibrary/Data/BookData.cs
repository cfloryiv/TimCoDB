using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;


namespace DataLibrary.Data
{
    public class BookData : IBookData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public BookData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
        public Task<List<BookModel>> GetBooks()
        {
            return _dataAccess.LoadData<BookModel, dynamic>("dbo.spBooks_All",
                new { },
                _connectionString.SqlConnectionName);
        }
        public async Task<int> CreateBook(BookModel book)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Title", book.title);
            p.Add("Author", book.author);
            p.Add("Binding", book.binding);
            p.Add("NumberPages", book.numberPages);
            p.Add("PersonID", book.personID);
            p.Add("PubDate", book.pubDate);
            p.Add("Date", book.date);

            p.Add("ID", System.Data.DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spBooks_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("ID");
        }
        public async Task<int> UpdateBook(BookModel book)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("Title", book.title);
            p.Add("Author", book.author);
            p.Add("Binding", book.binding);
            p.Add("NumberPages", book.numberPages);
            p.Add("PersonID", book.personID);
            p.Add("PubDate", book.pubDate);
            p.Add("Date", book.date);
            p.Add("ID", book.ID);

            await _dataAccess.SaveData("dbo.spBooks_Update", p, _connectionString.SqlConnectionName);
            return book.ID;
        }
        public async Task<BookModel> GetBookById(int bookId)
        {
            var recs = await _dataAccess.LoadData<BookModel, dynamic>("dbo.spBooks_GetById",
                new
                {
                    ID = bookId
                },
                _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }
        public Task<int> DeleteBook(int Id)
        {
            return _dataAccess.SaveData("dbo.spBooks_Delete",
                new
                {
                    ID = Id
                },
                _connectionString.SqlConnectionName);
        }
    }
}
