using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.eventcalculator.model
{
    public class EventCalculator
    {
        [Display(Name = "Absolute path to text file")]
        public String pathToFile
        {
            get; set;
        }
    }
}
