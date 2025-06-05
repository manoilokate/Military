using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonalRecords.Models
{
    public class AdditionalTraining
    {
        [Key]
        public int TrainingId { get; set; }
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
        public string TrainingName { get; set; }
        [Required]
        public string TrainingCountry { get; set; }
        [Required]
        public string TrainingCity { get; set; }
        [Required]
        public DateOnly StartedTraining { get; set; }
        [Required]
        public DateOnly FinishedTraining { get; set; }
    }
}
