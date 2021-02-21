using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Entities.RequestModel
{
    public class RequestEditorial
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
        [MinLength(7, ErrorMessage = "Phone must have a minimum of 7 characters")]
        [MaxLength(12, ErrorMessage = "Phone can only be 12 characters long")]
        [RegularExpression("^[0-9]{7,12}$", ErrorMessage = "Phone can only numerics characters")]
        public string Phone { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Email can only be 30 characters long")]
        [EmailAddress]
        public string Email { get; set; }
        public int MaxBook { get; set; } = -1;
    }
}
