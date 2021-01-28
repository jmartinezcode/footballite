using FootballLeagueManager.Data;
using FootballLeagueManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FootballLeagueManager.Controllers
{
    public class LeagueController : Controller
    {
        // GET: LeagueController
        private readonly ApplicationDbContext _context;

        public LeagueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            //default view when signed in
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<League> _leagues = _context.Leagues.ToList();
                

            return View(_leagues);
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
        public ActionResult Create(League league)
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
