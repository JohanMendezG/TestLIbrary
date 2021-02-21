using LibraryApi.Entities.RequestModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class Books : RequestBook
    {
        public Editorials Editorial { get; set; }
        public Authors Author { get; set; }
    }
}
