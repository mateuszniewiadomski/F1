using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1.Models;

namespace F1.ViewModels
{
    public class NationalityViewModel
    {
        public Nationality Nationality { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<RacingDriver> RacingDrivers { get; set; }
    }
}
