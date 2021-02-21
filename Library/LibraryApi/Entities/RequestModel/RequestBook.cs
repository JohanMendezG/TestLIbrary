using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Entities.RequestModel
{
    public class RequestBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title can only be 50 characters long")]
        public string Title { get; set; }
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Year can only 4 numerics characters")]
        public int Year { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Genre can only be 20 characters long")]
        public string Genre { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "NumberPage can only numerics characters")]
        public int NumberPage { get; set; }
        [Required(ErrorMessage = "La editorial no está registrada")]
        public int EditorialId { get; set; }

        [Required(ErrorMessage = "El autor no está registrado")]
        public int AuthorId { get; set; }
    }
}
