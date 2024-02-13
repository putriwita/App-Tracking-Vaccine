namespace Project_try.Models
{
    public class ReportInnVaksin
    {
        public Guid id { get; set; }
        public string id_vaksin { get; set; } 
        public string nama_vaksin { get; set; }
        public string name_rumah_sakit { get; set; }
        public int jumlah_vaksin { get; set; }
        public string id_rumah_sakit { get; set; }
        public DateTime Date_In_Vaksin { get; set; }

    }
}
