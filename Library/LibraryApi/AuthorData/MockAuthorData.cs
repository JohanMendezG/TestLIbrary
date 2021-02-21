using LibraryApi.Context;
using LibraryApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.AuthorData
{
    public class MockAuthorData : IAuthorData
    {
        private readonly AppDbContext context;
        public MockAuthorData(AppDbContext context)
        {
            this.context = context;
        }
        public Authors AddAuthor(Authors author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return author;
        }
        public void DeleteAuthor(Authors author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }
        public Authors EditAuthor(Authors author)
        {
            var existingAuthor = GetAuthor(author.Id);
            existingAuthor.CityBirth = author.CityBirth;
            existingAuthor.Email = author.Email;
            existingAuthor.DateBirth = author.DateBirth;
            existingAuthor.FullName = author.FullName;
            context.Entry(existingAuthor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return existingAuthor;
        }
        public Authors GetAuthor(int id)
        {
            return context.Authors.SingleOrDefault(autor => autor.Id == id);
        }
        public List<Authors> GetAuthors()
        {
            return context.Authors.ToList();
        }
    }
}
