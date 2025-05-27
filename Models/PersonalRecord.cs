using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PersonalRecords.Models
{
    public class PersonalRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Soname {  get; set; }
        [Required]
        public DateTime _dateOfBirth;
        public string DateOfBirth
        {
            get => _dateOfBirth.ToString("dd-MM-yyyy");
            set => _dateOfBirth = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
        [Required]
        private DateTime _dateOfStartWork;
        public string DateOfStartWork
        {
            get => _dateOfStartWork.ToString("dd-MM-yyyy");
            set => _dateOfStartWork = DateTime.ParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        }
        [Required]
        public string Rank { get; set; }
        [Required]
        public string NumberOrganization { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<FamilyContacts> FamilyContacts { get; set; } = new List<FamilyContacts>();
        public virtual ICollection<InformationAboutDiseases> InformationAboutDiseases { get; set; } = new List<InformationAboutDiseases>();
        public virtual ICollection<InformationAboutVacation> InformationAboutVacation { get; set; } = new List<InformationAboutVacation>();
        public virtual ICollection<AdditionalTraining> AdditionalTraining { get; set; } = new List<AdditionalTraining>();
    }
}
