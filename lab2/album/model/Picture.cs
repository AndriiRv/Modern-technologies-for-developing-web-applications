using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.album.model
{
    public class Picture
    {
        [Display(Name = "Title")]
        public String title
        {
            get; set;
        }

        public String pathToAlbum
        {
            get; set;
        }

        [Display(Name = "Name")]
        public String pathToImage
        {
            get; set;
        }

        public Picture(String title)
        {
            this.title = title;
        }

        public Picture()
        {
        }
    }
}