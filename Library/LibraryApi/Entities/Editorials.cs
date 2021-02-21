using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;

namespace LibraryApi.Entities
{
    public class Editorials:RequestEditorial
    {
        public ICollection<Books> Books { get; set; }
    }
}
