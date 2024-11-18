using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Models
{
    public class FamilyContacts
    {
        [Key]
        public int Id { get; set; } 

        public int PersonalRecordId { get; set; } 

        [ForeignKey("PersonalRecordId")]
        public virtual PersonalRecord PersonalRecord { get; set; }

        public string Relationship { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
