using System;

namespace lab1_task2_WebForm_
{
    public partial class countriesAndNationalities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imageButton.ImageUrl = @"~\findIcon.png";
                image.Visible = false;
                titleOfImageLabel.Visible = false;
            }
        }

        protected void getImage(object sender, EventArgs e)
        {
            string titleOfImage = Page.Request.Form["titleOfImage"].ToString();

            image.ImageUrl = @"~\images\" + titleOfImage;
            image.Visible = true;

            titleOfImageLabel.Text = titleOfImage;
            titleOfImageLabel.Visible = true;
        }
    }
}