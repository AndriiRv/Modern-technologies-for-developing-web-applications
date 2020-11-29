using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.calculatoroflifetime.model
{
    public class Calculator
    {

        public Calculator(String nameOfPerson, String dateOfBirth)
        {
            this.nameOfPerson = nameOfPerson;
            this.dateOfBirth = dateOfBirth;
        }

        public Calculator()
        {
        }

        [Display(Name = "Name")]
        public String nameOfPerson
        {
            get; set;
        }

    [Display(Name = "Date of birth")]
        public String dateOfBirth
        {
            get; set;
        }
    }
}
