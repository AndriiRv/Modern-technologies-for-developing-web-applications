using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.album.model
{
    public class Album
    {
        [Display(Name = "Title")]
        public String title
        {
            get; set;
        }

        public String pathToAlbums
        {
            get; set;
        }

        public Album(String title)
        {
            this.title = title;
        }

        public Album()
        {
        }
    }
}