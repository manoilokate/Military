using System.ComponentModel.DataAnnotations;

namespace PersonalRecords.Models
{
    public class Search
    {
        [Required(ErrorMessage = "Прізвище є обов'язковим.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ім'я є обов'язковим.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "По-батькові є обов'язковим.")]
        public string Soname { get; set; }
    }
}
