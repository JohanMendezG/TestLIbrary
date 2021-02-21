using LibraryApi.Context;
using LibraryApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.EditorialsData
{
    public class MockEditorialData : IEditorialData
    {
        private readonly AppDbContext context;
        public MockEditorialData(AppDbContext context)
        {
            this.context = context;
        }
        public Editorials AddEditorial(Editorials editorial)
        {
            context.Editorials.Add(editorial);
            context.SaveChanges();
            return editorial;
        }
        public void DeleteEditorial(Editorials editorial)
        {
            context.Editorials.Remove(editorial);
            context.SaveChanges();
        }
        public Editorials EditEditorial(Editorials editorial)
        {
            var existingEditorial = GetEditorial(editorial.Id);
            existingEditorial.Address = editorial.Address;
            existingEditorial.Email = editorial.Email;
            existingEditorial.MaxBook = editorial.MaxBook;
            existingEditorial.Name = editorial.Name;
            existingEditorial.Phone = editorial.Phone;
            context.Entry(existingEditorial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return existingEditorial;
        }
        public List<Editorials> GetEditorials()
        {
            return context.Editorials.ToList();
        }

        public Editorials GetEditorial(int id)
        {
            return context.Editorials.SingleOrDefault(editorial => editorial.Id == id);
        }
    }
}
