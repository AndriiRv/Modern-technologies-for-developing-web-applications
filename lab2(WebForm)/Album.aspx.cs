using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace lab2_WebForm_
{
    public partial class Album : System.Web.UI.Page
    {
        private static string PATH_TO_RELATIVE_ALBUMS_FOLDER = "albums";

        string path = HttpContext.Current.Server.MapPath(@"~\" + PATH_TO_RELATIVE_ALBUMS_FOLDER);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                picturesPanel.Visible = false;
                statusLabel.Visible = false;

                List<ListItem> albumList = new List<ListItem>();
                string[] directoriesOfAlbums = Directory.GetDirectories(path);

                foreach (string subDirectory in directoriesOfAlbums)
                {
                    albumList.Add(new ListItem(subDirectory.Split('\\')[8], subDirectory));
                }
                albums.DataSource = albumList;
                albums.DataBind();

                updatePicturesList();
            }
        }

        protected void onSelectedAlbum(object sender, EventArgs e)
        {
            picturesPanel.Visible = false;
            statusLabel.Visible = false;

            updatePicturesList();
        }

        protected void onSelectedPicture(object sender, EventArgs e)
        {
            picturesPanel.Visible = true;
            statusLabel.Visible = false;

            picture.ImageUrl = @"~\" + PATH_TO_RELATIVE_ALBUMS_FOLDER + "\\" + albums.SelectedItem.Text + @"\" + pictures.SelectedValue;
            titleOfPictureID.Text = pictures.SelectedValue;
        }

        private void updatePicturesList()
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(path + @"\" + albums.SelectedItem.Text);
            FileSystemInfo[] files = directoryinfo.GetFileSystemInfos("*");

            countOfPicturesID.Text = files.Length.ToString();

            List<ListItem> titleOfFiles = new List<ListItem>();
            foreach (FileSystemInfo file in files)
            {
                titleOfFiles.Add(new ListItem(file.Name));
            }
            pictures.DataSource = titleOfFiles;
            pictures.DataBind();
        }

        protected void upload(object sender, EventArgs e)
        {
            if (PhotoUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(PhotoUpload.FileName);
                    PhotoUpload.SaveAs(path + @"\" + albums.SelectedItem.Text + @"\" + filename);

                    statusLabel.Visible = true;
                    statusLabel.Text = "Picture was uploaded";

                    updatePicturesList();
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "error" + ex.Message;
                }
            }
        }

        protected void delete(object sender, EventArgs e)
        {
            string currentPath = path + @"\" + albums.SelectedItem.Text + @"\" + pictures.SelectedValue;
            if (File.Exists(currentPath))
            {
                File.Delete(currentPath);

                statusLabel.Visible = true;
                statusLabel.Text = "Picture was deleted";

                picturesPanel.Visible = false;
                updatePicturesList();
            }
        }
    }
}