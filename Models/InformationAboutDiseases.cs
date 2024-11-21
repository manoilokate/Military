using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Models
{
    public class InformationAboutDiseases
    {
        [Key]
        public int InformationAboutDiseasesId { get; set; }
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
        public DateOnly StartedToIll {  get; set; }
        [Required]
        public DateOnly FinishedToIll { get; set; }
        [Required]
        public int IllnessDurationDays { get; set; }
        [Required]
        public bool StayInHospital {  get; set; }
    }
}
