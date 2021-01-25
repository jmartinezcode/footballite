using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Models
{
    public class TeamModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        [Required]
        [DisplayName("Team Name")]
        public string Name { get; set; }
    }
}
