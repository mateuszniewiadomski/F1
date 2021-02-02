using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1.Models
{
    public class RacingDriver
    {
        public int ID { get; set; }

        [Required]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String Firstname { get; set; }

        [Required]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String Lastname { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Out of range")]
        [Display(Name = "Start Number")]
        public int StartNumber { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Out of range")]
        [Display(Name = "Wins in career")]
        public int CareerWins { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Url]
        [Display(Name = "Photo link")]
        public String PhotoLink { get; set; }

        public int NationalityID { get; set; }
        [ForeignKey("NationalityID")]
        public Nationality Nationality { get; set; }

        public int TeamID { get; set; }
        [ForeignKey("TeamID")]
        public Team Team { get; set; }
    }
}
