using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticeModul.Data.Interfaces;
using PracticeModul.Models;

namespace PracticeModul.Controllers
{
    public class HeroController : Controller
    {
        IRepository<Hero> heroRepository;

        public HeroController(IRepository<Hero> heroRepository)
        {
            this.heroRepository = heroRepository;
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public IActionResult Index()
        {
            return View(this.heroRepository.Read());
        }

        [OutputCache(Duration = 10, VaryByParam = "none")]
        public IActionResult List()
        {
            return View(this.heroRepository.Read());
        }

        [HttpGet]
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            heroRepository.Create(hero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            heroRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var hero = heroRepository.Read(id);
            return View(hero);
        }

        [HttpPost]
        public IActionResult Update(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            heroRepository.Update(hero);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(string id)
        {
            var hero = heroRepository.Read(id);
            if (hero.ContentType?.Length > 3)
            {
                return new FileContentResult(hero.Data, hero.ContentType);
            }
            else
            {
                return BadRequest();
            }

        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var msg = exceptionHandlerPathFeature.Error.Message;
            return View("Error", msg);
        }
    }
}
