using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1.Models;

namespace F1.ViewModels
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public IEnumerable<RacingDriver> RacingDrivers { get; set; }
    }
}
