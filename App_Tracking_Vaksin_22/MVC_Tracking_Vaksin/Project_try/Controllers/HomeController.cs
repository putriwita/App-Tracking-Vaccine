using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_try.Data;
using Project_try.Models;
using System.Diagnostics;

namespace Project_try.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public HomeController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var vaksin = await mVCDemoDbContext.Vaksins.ToListAsync();
            ViewBag.Roles = "Masyrakat";
            return View(vaksin);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Logins()
        {
            return View("login");
        }


        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            var loginUser = await mVCDemoDbContext.Users.SingleOrDefaultAsync(u => u.username ==user.username  && u.password == user.password && u.roles == "BPOM");
            if (loginUser != null)
            {
                var user_id = loginUser.Id;
                return RedirectToAction("index", "Admin",new { user_id = user_id});
            }
            var loginUser2 = await mVCDemoDbContext.Users.SingleOrDefaultAsync(u => u.username == user.username && u.password == u.password && u.roles == "Rumah Sakit");
            if(loginUser2 != null)
            {
                var user_id = loginUser2.Id;
                var users = loginUser2.Nama_Badan;
                return RedirectToAction("Index", "RumahSakitHome", new {user_id = user_id , users = users});
            }
            ModelState.AddModelError(string.Empty, "Gagal Login, Ada Kesalahan Password atau username");
            return View(user);
        }
    }
}