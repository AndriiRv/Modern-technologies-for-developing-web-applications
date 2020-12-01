<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="lab2_WebForm_.Album" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            My albums<br />
            <asp:DropDownList ID="albums" runat="server" AutoPostBack="True" OnSelectedIndexChanged="onSelectedAlbum"></asp:DropDownList>
        </div>
        <div>
            Available pictures
            <asp:Label ID="countOfPicturesID" runat="server"></asp:Label><br />
            <asp:DropDownList ID="pictures" runat="server" SelectionMode="Single" AutoPostBack="True" OnSelectedIndexChanged="onSelectedPicture"></asp:DropDownList>

            <h3>Add new photo: 
                <asp:FileUpLoad id="PhotoUpload" runat="server"  />
                <asp:Button id="uploadButtonID" Text="Upload" OnClick="upload" runat="server"/>
            </h3>
            <asp:Label id="statusLabel" runat="server" text="Upload status: " />

                <asp:Panel ID="picturesPanel" runat="server">
                    <asp:Image ID="picture" runat="server" Width="500px"/>
                    <asp:Button ID="deleteButtonID" runat="server" OnClick="delete" Text="Delete" />
                    <h3>
                        <asp:Label ID="titleOfPictureID" runat="server"></asp:Label>
                    </h3>
                </asp:Panel>
        </div>
    </form>
</body>
</html>
