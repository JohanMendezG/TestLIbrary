using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;

namespace LibraryApi.Data.Author
{
    public interface IAuthorData
    {
        List<RequestAuthors> GetAuthors();
        RequestAuthors GetAuthor(int id);
        RequestAuthors AddAuthor(RequestAuthors author);
        void DeleteAuthor(RequestAuthors author);
        RequestAuthors EditAuthor(RequestAuthors author);
    }
}
