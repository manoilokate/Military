using System.ComponentModel.DataAnnotations;

namespace PersonalRecords.Models
{
    public class PersonalRecord
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Soname {  get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfStartWork { get; set; }
        public string Rank { get; set; }
        public string NumberOrganization { get; set; }
        public string Education { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<FamilyContacts> FamilyContacts { get; set; }
    }
}
