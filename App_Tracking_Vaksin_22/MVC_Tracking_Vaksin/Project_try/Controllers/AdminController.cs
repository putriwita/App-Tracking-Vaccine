using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_try.Data;
using Project_try.Models;

namespace Project_try.Controllers
{
    public class AdminController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public AdminController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }
        public async Task<IActionResult> Index(string user_id)
        {
            var countvaksin = await mVCDemoDbContext.Vaksins.CountAsync();
            var countpenduduk = await mVCDemoDbContext.Penduduk.CountAsync();
            var countRumahSakit = await mVCDemoDbContext.Users.CountAsync(u => u.roles == "Rumah Sakit");
            ViewData["count_penduduk"] = countpenduduk;
            ViewData["count_RumahSakit"] = countRumahSakit;
            ViewData["count_vaksin"] = countvaksin;
            ViewData["id"] = user_id; 
            return View();
        }
        public async Task<IActionResult> Vacine()
        {
            var vaksin = await mVCDemoDbContext.Vaksins.ToListAsync();
            return View(vaksin);
        }
        public async Task<IActionResult> RumahSakit()
        {
            var rumahsakit = await mVCDemoDbContext.Users.Where(stu => stu.roles == "Rumah Sakit").ToListAsync();
            return View(rumahsakit);
        }
        public async Task<IActionResult> Penduduk()
        {
            var penduduk = await mVCDemoDbContext.Penduduk.ToListAsync();
            return View(penduduk);
        }

    }
}
