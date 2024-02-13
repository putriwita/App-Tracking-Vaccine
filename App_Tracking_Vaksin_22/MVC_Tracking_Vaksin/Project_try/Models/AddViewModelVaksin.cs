using System.ComponentModel.DataAnnotations;

namespace Project_try.Models
{
    public class AddViewModelVaksin
    {

        [Required(ErrorMessage = "Name is required")]
        public string NameVaksin { get; set; }

        [Required(ErrorMessage = "Dosis is required")]
        public string Dosis { get; set; }
        [Required(ErrorMessage = "Min Age To Used is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum age used must be greater than or equal to 0")]
        public int min_age_used { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "Description must be no more than 100 characters")]
        public string description_vaksin { get; set; }
    }
}
