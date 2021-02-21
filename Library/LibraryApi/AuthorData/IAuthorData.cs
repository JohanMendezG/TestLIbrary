using LibraryApi.Entities;
using System.Collections.Generic;

namespace LibraryApi.AuthorData
{
    public interface IAuthorData
    {
        List<Authors> GetAuthors();
        Authors GetAuthor(int id);
        Authors AddAuthor(Authors author);
        void DeleteAuthor(Authors author);
        Authors EditAuthor(Authors author);
    }
}
