using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Models
{
    public class MatchModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Home Team")]
        public int TeamOneId { get; set; }
        public TeamModel TeamOne { get; set; }
        [ForeignKey("Away Team")]
        public int TeamTwoId { get; set; }
        public TeamModel TeamTwo { get; set; }
        [DisplayName("Score for Home Team")]
        public int ScoreForTeamOne { get; set; }
        [DisplayName("Score for Away Team")]
        public int ScoreForTeamTwo { get; set; }
        [Required]
        public bool IsFinished { get; set; }
        [Required]
        public DateTime DateOfMatch { get; set; }
    }
}
