using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalRecords.Models
{
    public class InformationAboutVacation
    {

        [Key]
        public int InformationAboutVacationId { get; set; }
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
        public DateOnly StartedVacation { get; set; }
        [Required]
        public DateOnly FinishedVacation { get; set; }
        [Required]
        public int VacationDurationDays { get; set; }
        [Required]
        public bool IsPaidVacation { get; set; }
    }
}
