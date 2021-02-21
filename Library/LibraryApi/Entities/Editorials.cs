using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Entities
{
    public class Editorials
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Address can only be 50 characters long")]
        public string Address { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "Phone can only be 20 characters long")]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Email can only be 30 characters long")]
        [EmailAddress]
        public string Email { get; set; }
        public int? MaxBook { get; set; }
    }
}
