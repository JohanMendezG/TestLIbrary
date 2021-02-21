using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Entities.RequestModel
{
    public class RequestAuthors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string FullName { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "City can only be 20 characters long")]
        public string CityBirth { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Email can only be 30 characters long")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
