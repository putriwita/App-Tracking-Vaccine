using Microsoft.AspNetCore.Mvc;
using Project_try.Data;
using Project_try.Models;

namespace Project_try.Controllers
{
    public class VaksinController : Controller
    {
        private readonly MVCDemoDbContext mVCDemoDbContext;
        public VaksinController(MVCDemoDbContext mVCDemoDbContext)
        {
            this.mVCDemoDbContext= mVCDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Validate = "val";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Adds(AddViewModelVaksin addvaksin) {
            var vaksin = new Vaksin()
            {
                Id = Guid.NewGuid(),
                NameVaksin = addvaksin.NameVaksin,
                Dosis = addvaksin.Dosis,
                description_vaksin = addvaksin.description_vaksin,
                min_age_used = addvaksin.min_age_used

            };
            if (!ModelState.IsValid)
            {
                ViewBag.Validate = "Validate";
            }
         
            if (ModelState.IsValid)
            {
                await mVCDemoDbContext.Vaksins.AddAsync(vaksin);
                await mVCDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Vacine","Admin");
            }
            else
                return View("Add");
            }
    }
}
