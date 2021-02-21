using LibraryApi.Context;
using LibraryApi.Entities.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Data.Book
{
    public class MockBookData : IBookData
    {
        private readonly AppDbContext context;
        public MockBookData(AppDbContext context)
        {
            this.context = context;
        }
        public RequestBook AddBook(RequestBook book)
        {
            if (!ValidationEditorialOrAuthor(value: book.AuthorId))
                throw new Exception("El autor no está registrado");
            if (!ValidationEditorialOrAuthor(value: book.EditorialId))
                throw new Exception("La editorial no está registrada");
            if (!ValidationNewBook(model: book))
                throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");
            context.Books.Add(new Entities.Books
            {
                Id= 0,
                AuthorId = book.AuthorId,
                EditorialId = book.EditorialId,
                Genre = book.Genre,
                Title = book.Title,
                NumberPage = book.NumberPage,
                Year = book.Year
            });
            context.SaveChanges();
            return book;
        }
        public void DeleteBook(RequestBook book)
        {
            var existingBook = context.Books.Find(book.Id);
            context.Books.Remove(existingBook);
            context.SaveChanges();
        }
        public RequestBook EditBook(RequestBook book)
        {
            var existingBook = GetBook(book.Id);
            existingBook.Year = book.Year;
            existingBook.Title = book.Title;
            existingBook.NumberPage = book.NumberPage;
            existingBook.EditorialId = book.EditorialId;
            existingBook.AuthorId = book.AuthorId;
            existingBook.Genre = book.Genre;
            context.Entry(existingBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return existingBook;
        }
        public RequestBook GetBook(int id)
        {
            return context.Books.SingleOrDefault(book => book.Id == id);
        }
        public List<RequestBook> GetBooks()
        {
            return context.Books
                .Select(book => new RequestBook
                {
                    Genre = book.Genre,
                    Id = book.Id,
                    AuthorId = book.AuthorId,
                    EditorialId = book.EditorialId,
                    NumberPage = book.NumberPage,
                    Title = book.Title,
                    Year = book.Year
                }).ToList();
        }
        private bool ValidationEditorialOrAuthor(int? value)
        {
            if (value > 0)
                return true;
            return false;
        }
        private bool ValidationNewBook(RequestBook model)
        {
            var maxBooksByEditorial = context.Editorials.Where(editorial => editorial.Id == model.EditorialId).FirstOrDefault().MaxBook;
            if (maxBooksByEditorial < 0)
                return true;
            var numberBooksByAuthor = (context.Books.Where(book => book.EditorialId == model.EditorialId)).Count();
            if (maxBooksByEditorial > numberBooksByAuthor)
                return true;
            return false;
        }
    }
}
