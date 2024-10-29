using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Models
{
    public class PersonalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Soname {  get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public DateOnly DateOfStartWork { get; set; }
        [Required]
        public string Rank { get; set; }
        [Required]
        public string NumberOrganization { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<FamilyContacts> FamilyContacts { get; set; }
    }
}
