using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace lab3_WebForm_
{
    public partial class CountriesAndNationalities : System.Web.UI.Page
    {
        private static string TITLE_OF_XML_FILE = "Nationalities.xml";

        protected DropDownList titlesOfCountries;
        protected XmlDataSource xmlDataSource;
        protected LinkButton addToCountry, addToXML, addImageToXML;
        protected Panel newNationalityPanel;
        protected Literal titleOfActionLabel;
        protected TextBox titleOfNationality, descriptionOfNationality, descriptionToImage;
        protected FileUpload fileUpload;

        string path = HttpContext.Current.Server.MapPath(@"~\albums");
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ListItem> countries = new List<ListItem>();
                countries.Add(new ListItem("None", ""));

                string[] directories = Directory.GetDirectories(path);

                foreach (string subDirectory in directories)
                {
                    countries.Add(new ListItem(subDirectory.Split('\\')[8], subDirectory.Split('\\')[8]));
                }
                titlesOfCountries.DataSource = countries;
                titlesOfCountries.DataBind();

                string nationality = Request.QueryString["nationality"] ?? "None";
                titlesOfCountries.SelectedValue = nationality;
                addToCountry.Visible = false;
                newNationalityPanel.Visible = false;
            }
            xmlDataSource.XPath = string.Format("root/country[@id='{0}']", titlesOfCountries.SelectedValue);
        }

        protected void getCountry(Object sender, EventArgs e)
        {
            DropDownList dropdownList = (DropDownList)sender;
            xmlDataSource.XPath = string.Format("//country[@id='{0}']", dropdownList.SelectedValue);
            addToCountry.Visible = true;
        }

        protected void showAddNewNationality(Object sender, EventArgs e)
        {
            addToCountry.Visible = false;
            newNationalityPanel.Visible = true;
            titleOfActionLabel.Text = "Adding nationality to country: " + titlesOfCountries.SelectedValue;

            titleOfNationality.Enabled = descriptionOfNationality.Enabled = true;
            titleOfNationality.Text = "";

            descriptionOfNationality.Text = "";
            descriptionToImage.Text = "";
            addToXML.Visible = true;
            addImageToXML.Visible = false;
        }

        protected void savePicture(Object sender, CommandEventArgs e)
        {
            newNationalityPanel.Visible = true;

            titleOfActionLabel.Text = "Adding country image " + e.CommandArgument;
            titleOfNationality.Enabled = descriptionOfNationality.Enabled = false;

            XmlDocument xmlDoc = new XmlDocument();
            string xmlFile = MapPath(TITLE_OF_XML_FILE);
            xmlDoc.Load(xmlFile);

            string xpath = string.Format("//country[@id='{0}']/nationality[@id='{1}']", e.CommandName, e.CommandArgument);
            XmlNode ndCountry = xmlDoc.DocumentElement.SelectSingleNode(xpath);
            if (ndCountry != null)
            {
                titleOfNationality.Text = ndCountry.Attributes["id"].Value;
                XmlNode ndAbout = ndCountry.SelectSingleNode("about");
                descriptionOfNationality.Text = ndAbout.InnerText;
                descriptionToImage.Text = "";
                addToXML.Visible = false;
                addImageToXML.Visible = true;
            }
        }

        protected void putNationalityToXML(Object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string xmlFile = MapPath(TITLE_OF_XML_FILE);
            xmlDoc.Load(xmlFile);

            titleOfNationality.Text = titleOfNationality.Text.Trim();
            descriptionOfNationality.Text = descriptionOfNationality.Text.Trim();
            descriptionToImage.Text = descriptionToImage.Text.Trim();
            string xpath = string.Format("//country[@id='{0}']", titlesOfCountries.SelectedValue);
            XmlNode countryNode = xmlDoc.DocumentElement.SelectSingleNode(xpath);
            if (countryNode != null)
            {
                XmlNode xmlNode = xmlDoc.CreateElement("nationality");
                XmlAttribute aID = xmlDoc.CreateAttribute("id");
                aID.Value = titleOfNationality.Text;
                XmlElement eAbout = xmlDoc.CreateElement("about");
                eAbout.InnerText = descriptionOfNationality.Text;
                xmlNode.Attributes.Append(aID);
                xmlNode.AppendChild(eAbout);
                if (fileUpload.HasFile)
                {
                    string fileName = fileUpload.FileName;
                    string savePath = MapPath(string.Format("albums/{0}/{1}", titlesOfCountries.SelectedValue, fileName));
                    fileUpload.SaveAs(savePath);
                    XmlElement fileOfImage = xmlDoc.CreateElement("file");
                    fileOfImage.InnerText = descriptionToImage.Text;

                    XmlAttribute nameOfImage = xmlDoc.CreateAttribute("name");
                    nameOfImage.Value = fileName;

                    fileOfImage.Attributes.Append(nameOfImage);
                    xmlNode.AppendChild(fileOfImage);
                }
                countryNode.AppendChild(xmlNode);
                xmlDoc.Save(xmlFile);
            }
            disableNewNationalityBlock(this, EventArgs.Empty);
        }

        protected void removeNationality(Object sender, CommandEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string xmlFile = MapPath(TITLE_OF_XML_FILE);
            xmlDoc.Load(xmlFile);
            string xpath = string.Format("//country[@id='{0}']/nationality[@id='{1}']", e.CommandName, e.CommandArgument);

            XmlNode nationalityNode = xmlDoc.SelectSingleNode(xpath);
            nationalityNode.ParentNode.RemoveChild(nationalityNode);
            xmlDoc.Save(xmlFile);
            Response.Redirect("CountriesAndNationalities.aspx" + string.Format("?nationality={0}", titlesOfCountries.SelectedValue), true);
        }

        protected void putNationalityImageToXML(Object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string xmlFile = MapPath(TITLE_OF_XML_FILE);
            xmlDoc.Load(xmlFile);

            string xpath = string.Format("//country[@id='{0}']/nationality[@id='{1}']", titlesOfCountries.SelectedValue, titleOfNationality.Text);
            XmlNode countryNode = xmlDoc.DocumentElement.SelectSingleNode(xpath);
            if (countryNode != null)
            {
                if (fileUpload.HasFile)
                {
                    string fileName = fileUpload.FileName;
                    string savePath = MapPath(string.Format("albums/{0}/{1}", titlesOfCountries.SelectedValue, fileName));
                    fileUpload.SaveAs(savePath);
                    XmlElement file = xmlDoc.CreateElement("file");
                    file.InnerText = descriptionToImage.Text;
                    XmlAttribute nameOfImage = xmlDoc.CreateAttribute("name");
                    nameOfImage.Value = fileName;
                    file.Attributes.Append(nameOfImage);
                    countryNode.AppendChild(file);
                }
                xmlDoc.Save(xmlFile);
            }
            disableNewNationalityBlock(this, EventArgs.Empty);
        }

        protected void disableNewNationalityBlock(Object sender, EventArgs e)
        {
            newNationalityPanel.Visible = false;
            Response.Redirect("CountriesAndNationalities.aspx" + string.Format("?nationality={0}", titlesOfCountries.SelectedValue), true);
            addToCountry.Visible = true;
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(Page_Load);
        }
    }
}