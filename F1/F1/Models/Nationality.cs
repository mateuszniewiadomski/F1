using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using F1.Validators;

namespace F1.Models
{
    public class Nationality
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the nation")]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String NationName { get; set; }

        [Required]
        [Display(Name = "Capital of the country")]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String CapitalCity { get; set; }

        [Url]
        [Display(Name = "Photo link")]
        public String PhotoLink { get; set; }

        public IEnumerable<RacingDriver> RacingDrivers { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}
