using Microsoft.AspNetCore.Mvc;
using Project_try.Data;
using Project_try.Models;

namespace Project_try.Controllers
{
    public class RumahSakitController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public RumahSakitController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext = mVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Adds(AddViewModelRumahSakit addrumahsakit)
        {
            var rumahsakit = new Users()
            {
                Id = Guid.NewGuid(),
                username = addrumahsakit.username,
                Nama_Badan = addrumahsakit.Nama_Badan,
                email = addrumahsakit.email,
                password = addrumahsakit.password,
                Location = addrumahsakit.Location,
                phone = addrumahsakit.phone,
                roles = addrumahsakit.roles
            };
                
            if (!ModelState.IsValid)
            {
                ViewBag.Validate = "Validate";
            }

            if (ModelState.IsValid)
            {
                await mVCDemoDbContext.Users.AddAsync(rumahsakit);
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("RumahSakit","Admin");
            }
            else
                return View("Add");
        }
    }
}
