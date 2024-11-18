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
        public int IllnessDurationDays { get; set; }

        public void CalculateVacationDuration()
        {
            DateTime startDate = StartedToIll.ToDateTime(new TimeOnly(0, 0));
            DateTime endDate = FinishedToIll.ToDateTime(new TimeOnly(0, 0));

            IllnessDurationDays = (endDate - startDate).Days;
        }

        [Required]
        public bool StayInHospital {  get; set; }
    }
}
