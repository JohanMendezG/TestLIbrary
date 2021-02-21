using LibraryApi.Context;
using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Data.Author
{
    public class MockAuthorData : IAuthorData
    {
        private readonly AppDbContext context;
        public MockAuthorData(AppDbContext context)
        {
            this.context = context;
        }
        public RequestAuthors AddAuthor(RequestAuthors author)
        {
            context.Authors.Add(new Entities.Authors
            {
                Id= 0,
                FullName = author.FullName,
                Email = author.Email,
                DateBirth = author.DateBirth,
                CityBirth = author.CityBirth
            });
            context.SaveChanges();
            return author;
        }
        public void DeleteAuthor(RequestAuthors author)
        {
            var existingAuthor = context.Authors.Find(author.Id);
            context.Authors.Remove(existingAuthor);
            context.SaveChanges();
        }
        public RequestAuthors EditAuthor(RequestAuthors author)
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
        public RequestAuthors GetAuthor(int id)
        {
            return context.Authors.SingleOrDefault(autor => autor.Id == id);
        }
        public List<RequestAuthors> GetAuthors()
        {
            return context.Authors
                .Select(author => new RequestAuthors
                {
                    CityBirth = author.CityBirth,
                    DateBirth = author.DateBirth,
                    Email = author.Email,
                    FullName = author.FullName,
                    Id = author.Id
                }).ToList();
        }
    }
}
