using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
    public class DenemeController : Controller
    {
        // GET: DenemeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DenemeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DenemeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DenemeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenemeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DenemeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DenemeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DenemeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
