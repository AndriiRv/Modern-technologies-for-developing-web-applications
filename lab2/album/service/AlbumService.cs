using lab2.album.model;
using System;
using System.Collections.Generic;
using System.IO;

namespace lab2.album.service
{
    public class AlbumService
    {
        public List<Album> getAlbums(String pathToAlbums)
        {
            List<Album> albums = new List<Album>();

            String[] titleOfAlbums = Directory.GetDirectories(pathToAlbums);
            for(int i = 0; i < titleOfAlbums.Length; i++)
            {
                albums.Add(new Album(titleOfAlbums[i]));
            }

            return albums;
        }

        public List<Picture> getPictures(String pathToAlbum)
        {
            List<Picture> albums = new List<Picture>();

            String[] titleOfPictures = Directory.GetFiles(pathToAlbum);
            for (int i = 0; i < titleOfPictures.Length; i++)
            {
                albums.Add(new Picture(titleOfPictures[i]));
            }

            return albums;
        }

        public String getImageAsStringByPath(String pathToImage)
        {
            try
            {
                byte[] imageArray = File.ReadAllBytes(pathToImage);
                return Convert.ToBase64String(imageArray);
            }
            catch (Exception e)
            {
                return "Exception was happened";
            }
        }
    }
}