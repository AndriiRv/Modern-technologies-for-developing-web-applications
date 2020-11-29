using System;
using System.ComponentModel.DataAnnotations;

namespace lab1.imagereviewer.model
{
    public class ImageReviewer
    {
        [Display(Name = "Name")]
        public String pathToImage
        {
            get; set;
        }
    }
}
