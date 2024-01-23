using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nstrWeatherBot_gen2.Models;
using nstrWeatherBot_gen2.Repositories;

namespace nstrWeatherBot_gen2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApiKeysRepository _repository;

        public HomeController(ApiKeysRepository repository) 
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ApiKeys apiInstance = _repository.Get(1);
            return View(apiInstance);
        }

        [HttpPost]
        public ActionResult Index(ApiKeys newApi)
        {
            ApiKeys apiInstance = _repository.Get(1);
            if (ModelState.IsValid)
            {
                apiInstance.KeyString = newApi.KeyString;
                _repository.Update(apiInstance);
                return RedirectToAction("Index");
            }

            return View(newApi);
        }
    }
}
