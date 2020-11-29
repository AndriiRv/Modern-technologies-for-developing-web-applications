using System;

namespace lab1.imagereviewer.service
{
    public class ImageReviewerService
    {

        public String getImageAsStringByPath(String pathToImage)
        {
            try
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(pathToImage);
                return Convert.ToBase64String(imageArray);
            } catch(Exception e)
            {
                return "Exception was happened";
            }
        }
    }
}
