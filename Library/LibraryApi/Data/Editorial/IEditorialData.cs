using LibraryApi.Entities;
using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;

namespace LibraryApi.Data.Editorial
{
    public interface IEditorialData
    {
        List<RequestEditorial> GetEditorials();
        RequestEditorial GetEditorial(int id);
        RequestEditorial AddEditorial(RequestEditorial editorial);
        void DeleteEditorial(RequestEditorial editorial);
        RequestEditorial EditEditorial(RequestEditorial editorial);
    }
}
