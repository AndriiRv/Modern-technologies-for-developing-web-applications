<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountriesAndNationalities.aspx.cs" Inherits="lab3_WebForm_.CountriesAndNationalities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"></head>
<body>
    <form id="form1" runat="server">
        <h2>List of Countries</h2>
        <asp:DropDownList ID="titlesOfCountries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="getCountry"></asp:DropDownList>
        <p><asp:LinkButton ID="addToCountry" runat="server" OnClick="showAddNewNationality"
            Text="Add nationality to country"></asp:LinkButton></p>
        <asp:Panel ID="newNationalityPanel" runat="server">
            <table class="add-country-container">
                <tr><td colspan="2"><asp:Literal ID="titleOfActionLabel" runat="server"></asp:Literal></td></tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <th>Title of nationality:</th>
                    <td><asp:TextBox ID="titleOfNationality" runat="server" Width="400" TextMode="SingleLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Description of nationality:</th>
                    <td><asp:TextBox ID="descriptionOfNationality" runat="server" Width="400" TextMode="MultiLine" Rows="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Image:</th>
                    <td><asp:FileUpload ID="fileUpload" runat="server" Width="400" BorderColor="Black" BorderStyle="Solid" BorderWidth="1"></asp:FileUpload></td>
                </tr>
                <tr>
                    <th>Description to image:</th>
                    <td><asp:TextBox ID="descriptionToImage" runat="server" Width="400" TextMode="SingleLine"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:LinkButton ID="addToXML" runat="server" Text="Save" OnClick="putNationalityToXML"></asp:LinkButton>
                        <asp:LinkButton ID="addImageToXML" runat="server" Text="Save" OnClick="putNationalityImageToXML"></asp:LinkButton>
                        <asp:LinkButton ID="cmdCancel" runat="server" Text="Hide block" OnClick="disableNewNationalityBlock"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>

        <asp:XmlDataSource ID="xmlDataSource" runat="server" DataFile="Nationalities.xml" EnableCaching="false"></asp:XmlDataSource>

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="xmlDataSource">
            <ItemTemplate>
                <h3><%#XPath("@id") %></h3>
                <asp:Repeater ID="Repeater2" runat="server" DataSource='<%#XPathSelect("nationality") %>'>
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><b><%#XPath("@id") %></b>
                            <asp:LinkButton ID="LinkButton1" Text=" Remove nationality" 
                                OnCommand="removeNationality" CommandName='<%#XPath("../@id") %>' 
                                CommandArgument='<%#XPath("@id") %>' 
                                runat="server"></asp:LinkButton>
                        </li>
                        <div id="aboutDiv" style="width: 500px">
                            <i><%#XPath("about") %></i>
                        </div>
                        <asp:Repeater ID="Repeater3" runat="server" DataSource='<%#XPathSelect("file") %>'>
                            <ItemTemplate>
                                <div class="imageDiv">
                                    <img src='albums/<%#XPath("../../@id") %>/<%#XPath("@name") %>' width="200"></img>
                                    <br />
                                    <%#XPath("@name") %> | <i><%#XPath(".") %></i>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <br/>
                        <asp:LinkButton Text="Add image" 
                            OnCommand="savePicture" CommandName='<%#XPath("../@id") %>' 
                            CommandArgument='<%#XPath("@id") %>' runat="server"></asp:LinkButton>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>