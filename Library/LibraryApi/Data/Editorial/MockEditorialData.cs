using LibraryApi.Context;
using LibraryApi.Entities;
using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Data.Editorial
{
    public class MockEditorialData : IEditorialData
    {
        private readonly AppDbContext context;
        public MockEditorialData(AppDbContext context)
        {
            this.context = context;
        }
        public RequestEditorial AddEditorial(RequestEditorial editorial)
        {
            context.Editorials.Add(new Editorials
            {
                Id = 0,
                Phone = editorial.Phone,
                Name = editorial.Name,
                MaxBook = editorial.MaxBook,
                Address = editorial.Address,
                Email = editorial.Email
            });
            context.SaveChanges();
            return editorial;
        }
        public void DeleteEditorial(RequestEditorial editorial)
        {
            var existingEditorial = context.Editorials.Find(editorial.Id);
            context.Editorials.Remove(existingEditorial);
            context.SaveChanges();
        }
        public RequestEditorial EditEditorial(RequestEditorial editorial)
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
        public List<RequestEditorial> GetEditorials()
        {
            return context.Editorials
                .Select(editorial => new RequestEditorial
                {
                    Id = editorial.Id,
                    Address = editorial.Address,
                    Email = editorial.Email,
                    MaxBook = editorial.MaxBook,
                    Name = editorial.Name,
                    Phone = editorial.Phone
                }).ToList();
        }

        public RequestEditorial GetEditorial(int id)
        {
            return context.Editorials.SingleOrDefault(editorial => editorial.Id == id);
        }
    }
}
