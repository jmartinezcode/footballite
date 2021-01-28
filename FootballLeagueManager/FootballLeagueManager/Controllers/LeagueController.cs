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

        public IActionResult Index()
        {
            //default view when signed in
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<League> _leagues = _context.Leagues.ToList();
                

            return View(_leagues);
        }

        // GET: LeagueTeamMatchViewModel
        public IActionResult GetLeagueTeamMatchDetails(int leagueId)
        {
            var viewModel = new LeagueTeamMatchViewModel();
            var league = _context.Leagues.FirstOrDefault(l => l.Id == leagueId);
            var teams = _context.Teams.Include(t => t.LeagueId == leagueId).ToList();
            // need matches

            viewModel.Day = DateTime.Today.DayOfWeek;
            viewModel.Teams = teams;

            return View(viewModel);
        }

        // GET: LeagueController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeagueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(League league)
        {
            if (ModelState.IsValid) 
            {
                _context.Leagues.Add(league);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }

        // GET: LeagueController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var league =  _context.Leagues.Find(id);
            if(league == null)
            {
                return NotFound();
            }
            return View(league);
        }

        // POST: LeagueController/Edit/5
        [HttpPost]
        public IActionResult Edit(League league)
        {
            if (ModelState.IsValid)
            {
                _context.Leagues.Update(league);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }

        // GET: LeagueController/Delete/5
        public IActionResult Delete(int leagueId, bool? saveChangesError = false)
        {
            var _league = _context.Leagues.Where(m => m.Id == leagueId).FirstOrDefault();
            if(_league == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete Error for " + _league.Name + "... Please contact admin";
            }


            return View(_league);
        }

        // POST: LeagueController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int leagueId)
        {
            var _league = _context.Leagues.Where(m => m.Id == leagueId).FirstOrDefault();
            try
            {
                _context.Leagues.Remove(_league);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException error)
            {
                Console.WriteLine(error);
                return RedirectToAction(nameof(Delete), new { leagueId, saveChangesError = true });
            }
        }
    }
}
