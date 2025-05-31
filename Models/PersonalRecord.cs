using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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
        public virtual ICollection<FamilyContacts> FamilyContacts { get; set; } = new List<FamilyContacts>();
        public virtual ICollection<InformationAboutDiseases> InformationAboutDiseases { get; set; } = new List<InformationAboutDiseases>();
        public virtual ICollection<InformationAboutVacation> InformationAboutVacation { get; set; } = new List<InformationAboutVacation>();
        public virtual ICollection<AdditionalTraining> AdditionalTraining { get; set; } = new List<AdditionalTraining>();
    }
}
