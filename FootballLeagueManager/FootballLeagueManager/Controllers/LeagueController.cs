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
        public IActionResult Create(LeagueTeamMatchViewModel viewModel)
        {
            if (ModelState.IsValid) 
            {
                var league = viewModel.League;
                var teams = viewModel.Teams;
                var matches = viewModel.Matches;

                _context.Leagues.Add(league);
                // # of teams need to be established
                foreach (var team in teams)
                {
                    _context.Teams.Add(team);
                }
                // matches need to be created round robin for n-1 weeks (8 Team Example):
                // Week #1: 1v2; 3v4; 5v6; 7v8;
                // Week #2: 4v5; 7v1; 3v2; 6v8; 
                // Week #3: 2v4; 1v3; 5v8; 6v7;
                // Week #4: 1v4; 7v5; 6v2; 8v3;
                // Week #5: 5v1; 4v7; 8v2; 3v6;
                // Week #6: 8v1; 2v5; 4v6; 3v7;
                // Week #7: 8v4; 6v1; 2v7; 5v3;
                // 1: 3A,4H; 2: 3A,4H; 3: 4A,3H; 4: 3A,4H; 5: 4A,3H; 6: 4A,3H; 7: 3A,4H; 8: 4A,3H 
                // Teams should have (as close as possible) even number of home and away games
                // For odd number of Team leagues (7 Team Example):
                // W1: 1v2; 3v4; 5v6; 7Bye
                // W2: 4v5; 7v1; 3v2; 6Bye
                // W3: 2v4; 3v7; 6v1; 5Bye
                // W4: 2v7; 1v5; 3v6; 4Bye
                // W5: 

                foreach (var match in matches)
                {
                    _context.Matches.Add(match);
                }
                
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
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
