using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1.Models
{
    public class Team : IValidatableObject
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the team")]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String TeamName { get; set; }

        [Required]
        [Display(Name = "Name of the constructor")]
        [StartWithBigLetter]
        [HasMoreThanOneLetter]
        [StringLength(30, ErrorMessage = "Max lenght is 30")]
        public String ConstructorName { get; set; }

        [Url]
        [Display(Name = "Photo link")]
        public string PhotoLink { get; set; }

        public int NationalityID { get; set; }
        [ForeignKey("NationalityID")]
        public Nationality Nationality { get; set; }

        public IEnumerable<RacingDriver> RacingDrivers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!TeamName.Contains(ConstructorName))
            {
                yield return new ValidationResult("Name of the team must include name of the constructor", new List<string> { "TeamName" });
            }
        }
    }
}
