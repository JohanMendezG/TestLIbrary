using LibraryApi.Entities.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Data.Book
{
    public interface IBookData
    {
        List<RequestBook> GetBooks();
        RequestBook GetBook(int id);
        RequestBook AddBook(RequestBook book);
        void DeleteBook(RequestBook book);
        RequestBook EditBook(RequestBook book);
    }
}
