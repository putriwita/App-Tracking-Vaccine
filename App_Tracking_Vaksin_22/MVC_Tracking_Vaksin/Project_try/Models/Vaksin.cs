namespace Project_try.Models
{
    public class Vaksin
    {
        public Guid Id { get; set; }
        public string NameVaksin { get; set; }

        public string Dosis { get; set; }
        public int min_age_used { get; set; }
        public string description_vaksin { get; set; }

    }
}
