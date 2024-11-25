using System.ComponentModel.DataAnnotations;

namespace PersonalRecords.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        [Required]
        public string Role {  get; set; }
    }
}
