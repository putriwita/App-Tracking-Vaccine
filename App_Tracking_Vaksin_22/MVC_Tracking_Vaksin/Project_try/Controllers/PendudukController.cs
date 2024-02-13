using Microsoft.AspNetCore.Mvc;
using Project_try.Data;
using Project_try.Models;

namespace Project_try.Controllers
{
    public class PendudukController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public PendudukController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Validate = "V";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Adds(AddViewModelPenduduk addpenduduk)
        {
            var penduduk = new Penduduk()
            {
                name_penduduk = addpenduduk.name_penduduk,
                nik = addpenduduk.nik,
                tanggal_lahir    = addpenduduk.tanggal_lahir,
                Kabupaten =   addpenduduk.Kabupaten,
                Provinsi = addpenduduk.Provinsi,  
                Kecamatan= addpenduduk.Kecamatan
            };
            if (!ModelState.IsValid)
            {
                ViewBag.Validate = "Validate";
            }

            if (ModelState.IsValid)
            {
                await mVCDemoDbContext.Penduduk.AddAsync(penduduk);
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Penduduk","Admin");
            }
            else
                return View("Add");
        }
    }
}
