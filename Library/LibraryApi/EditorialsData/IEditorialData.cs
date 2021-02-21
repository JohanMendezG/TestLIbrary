using LibraryApi.Entities;
using System.Collections.Generic;

namespace LibraryApi.EditorialsData
{
    public interface IEditorialData
    {
        List<Editorials> GetEditorials();
        Editorials GetEditorial(int id);
        Editorials AddEditorial(Editorials editorial);
        void DeleteEditorial(Editorials editorial);
        Editorials EditEditorial(Editorials editorial);
    }
}
