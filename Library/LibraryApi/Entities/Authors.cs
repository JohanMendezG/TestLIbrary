using LibraryApi.Entities.RequestModel;
using System.Collections.Generic;

namespace LibraryApi.Entities
{
    public class Authors:RequestAuthors
    {        
        public ICollection<Books> Books { get; set; }
    }
}
