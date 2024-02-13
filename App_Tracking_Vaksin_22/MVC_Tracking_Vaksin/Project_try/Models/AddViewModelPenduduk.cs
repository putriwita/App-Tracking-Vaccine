using System.ComponentModel.DataAnnotations;

namespace Project_try.Models
{
    public class AddViewModelPenduduk
    {
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "NIK must be a 16-digit number.")]
        public string nik { get; set; }
        public string Provinsi { get; set; }
        public string Kabupaten { get; set; }

        public string Kecamatan { get; set; }

        public string name_penduduk { get; set; }
        public DateTime tanggal_lahir { get; set; }
    }
}
