using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Models
{
    public class FamilyContacts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonalRecordId { get; set; }
        [ForeignKey("PersonalRecordId")]
        public virtual PersonalRecord PersonalRecord { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Soname { get; set; }

        [Required]
        public string Relationship { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City {  get; set; }
        [Required]
        public string Address { get; set; }

    }
}
