using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Team Name")]
        public string Name { get; set; }
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        public League League { get; set; }
    }
}
