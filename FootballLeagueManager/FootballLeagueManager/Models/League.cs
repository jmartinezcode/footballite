using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueManager.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("League Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Number of Teams")]        
        [Range(1, int.MaxValue, ErrorMessage = "Number of Teams must be greater than 0.")]        
        public int NumberOfTeams { get; set; }
    }
}
