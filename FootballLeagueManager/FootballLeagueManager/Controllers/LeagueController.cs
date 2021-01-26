using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Controllers
{
    public class LeagueController : Controller
    {
        // GET: LeagueController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeagueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeagueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeagueController/Create
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

        // GET: LeagueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeagueController/Edit/5
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

        // GET: LeagueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeagueController/Delete/5
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
