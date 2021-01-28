using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Models
{
    public class LeagueTeamMatchViewModel
    {
        public League League { get; set; }
        public List<Team> Teams { get; set; }
        public Match Match { get; set; }
        public List<Match> Matches { get; set; }
        public DayOfWeek? Day { get; set; }
    }
}