using Microsoft.AspNetCore.Mvc;
using lab2.album.model;
using lab2.album.service;
using System;

namespace lab2.album.controller
{
    public class AlbumController : Controller
    {
        private AlbumService albumService;

        public AlbumController(AlbumService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        public IActionResult Album()
        {
            return View("../Album/Album");
        }

        [HttpPost]
        public IActionResult Album(Album album)
        {
            ViewData["Albums"] = albumService.getAlbums(album.pathToAlbums);

            return View(album);
        }

        //[HttpPost]
        //public IActionResult Album(Picture picture)
        //{
            //ViewData["Pictures"] = albumService.getPictures(picture.title);

            //return View(picture);
        //}

        //[HttpPost]
        //public IActionResult Album(String title)
        //{
            //ViewData["Picture"] = albumService.getImageAsStringByPath(title);

            //return View("../Album/Album");
        //}
    }
}