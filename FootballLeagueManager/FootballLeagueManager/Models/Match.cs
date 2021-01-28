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
    public class Match
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Team")]
        public int? TeamOneId { get; set; }
        public Team TeamOne { get; set; }
        [ForeignKey("Team")]
        public int? TeamTwoId { get; set; }
        public Team TeamTwo { get; set; }
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
