using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.simplecalculator.model
{
    public class SimpleCalculator
    {

    [Display(Name = "Content")]
        public String content
        {
            get; set;
        }

        public String one
        {get; set;}

        public String two
        { get; set; }

        public String three
        { get; set; }

        public String four
        { get; set; }

        public String five
        { get; set; }

        public String six
        { get; set; }

        public String seven
        { get; set; }

        public String eight
        { get; set; }
        public String nine
        { get; set; }

        public String zero
        { get; set; }

        public String plus
        { get; set; }

        public String minus
        { get; set; }

        public String multiplication
        { get; set; }
        public String division
        { get; set; }

        public String dot
        { get; set; }
    }
}
