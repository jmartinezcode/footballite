using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        [ForeignKey("Team")]
        public int TeamOneId { get; set; }
        [ForeignKey("Team")]
        public int TeamTwoId { get; set; }
        public int ScoreForTeamOne { get; set; }
        public int ScoreForTeamTwo { get; set; }
        [Required]
        public bool IsFinished { get; set; }
        [Required]
        public DateTime DateOfMatch { get; set; }
    }
}
