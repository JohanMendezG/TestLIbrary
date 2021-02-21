using LibraryApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
