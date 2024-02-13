using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_try.Data;
using Project_try.Models;

namespace Project_try.Controllers
{
    public class RumahSakitHomeController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public RumahSakitHomeController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }
        public IActionResult Index(string user_id, string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;
            return View();
        }
        public async Task<IActionResult> RecordPatient(string user_id, string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;
            var record = await mVCDemoDbContext.ReportUseVaksin.Where(u=> u.id_rumah_sakit == user_id).ToListAsync();
            return View(record);
        }

        public async Task<IActionResult> Vaksin(string user_id, string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;

            var vaksin = await mVCDemoDbContext.Vaksins.ToListAsync();
            return View(vaksin);
        }
        public async Task<IActionResult> ReportVaksin(string user_id,string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;
            var report_vakssin = await mVCDemoDbContext.ReportInnVaksin.ToListAsync();
            return View(report_vakssin);
        }
        [HttpGet]
        public IActionResult AddReportVaksin(string user_id, string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;
            ViewBag.Validate = "V";


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adds(AddViewModelReportInnVaksin addreport)
        {


          
         
                var report = new ReportInnVaksin()
                {
                    id = new Guid(),
                    id_rumah_sakit = addreport.id_rumah_sakit,
                    Date_In_Vaksin = addreport.Date_In_Vaksin,
                    id_vaksin = addreport.id_vaksin,
                    jumlah_vaksin = addreport.jumlah_vaksin,
                    name_rumah_sakit = addreport.name_rumah_sakit,
                    nama_vaksin = addreport.nama_vaksin

                };
            
            if (!ModelState.IsValid )
            {
                ViewBag.Validate = "Validate";

            }
            var getname = await mVCDemoDbContext.Vaksins.SingleOrDefaultAsync(u => u.NameVaksin == addreport.nama_vaksin && u.Id.ToString() == addreport.id_vaksin);
            if (getname == null)
            {
                ViewBag.Validate = "Validate";
                ViewBag.ErrorName = "Nama Vaksin dan Nomor Register vaksin belum terdaftar BPOM, Silahkan Cek Lagi Di Daftar Vaksin untuk Vaksin yang terdaftar";
            }


            if (ModelState.IsValid && getname != null)
            {
                await mVCDemoDbContext.ReportInnVaksin.AddAsync(report);
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("ReportVaksin", "RumahSakitHome",new{ user_id = addreport.id_rumah_sakit,users = addreport.name_rumah_sakit});
            }
            else
                ViewData["ID"] = addreport.id_rumah_sakit;
                ViewData["Users"] = addreport.name_rumah_sakit;
                return View("AddReportVaksin");
        }
        [HttpGet]
        public IActionResult AddRecord(string user_id, string users)
        {
            ViewData["ID"] = user_id;
            ViewData["Users"] = users;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Addsz(AddViewModelReportUseVaksin addrecord)
        {




            var report = new ReportUseVaksin()
            {
                id = new Guid(),
                id_rumah_sakit = addrecord.id_rumah_sakit,
                time_vaksin = addrecord.time_vaksin,
                id_vaksin = addrecord.id_vaksin,
                name_patient= addrecord.name_patient,
                nik_patient= addrecord.nik_patient,
                name_vaksin= addrecord.name_vaksin
            };

            if (!ModelState.IsValid)
            {
                ViewBag.Validate = "Validate";

            }
            var getnamevaksin = await mVCDemoDbContext.Vaksins.SingleOrDefaultAsync(u => u.NameVaksin == addrecord.name_vaksin && u.Id.ToString() == addrecord.id_vaksin);
            if (getnamevaksin == null)
            {
                ViewBag.Validate = "Validate";
                ViewBag.ErrorName = "Nama Vaksin dan Nomor Register vaksin belum terdaftar BPOM, Silahkan Cek Lagi Di Daftar Vaksin untuk Vaksin yang terdaftar";
            }
            var getnamependuduk = await mVCDemoDbContext.Penduduk.SingleOrDefaultAsync(u=> u.nik == addrecord.nik_patient && u.name_penduduk == addrecord.name_patient);
            var getnamerumahsakit = await mVCDemoDbContext.Users.SingleOrDefaultAsync(u => u.Id.ToString().ToLower() == addrecord.id_rumah_sakit);


            if (ModelState.IsValid && getnamevaksin != null)
            {
                await mVCDemoDbContext.ReportUseVaksin.AddAsync(report);
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("ReportVaksin", "RumahSakitHome", new { user_id = addrecord.id_rumah_sakit, users = getnamerumahsakit.Nama_Badan });
            }
            else
                ViewData["ID"] = addrecord.id_rumah_sakit;
            ViewData["Users"] = getnamerumahsakit.Nama_Badan;
            return View("AddReportVaksin");
        }

    }
}
