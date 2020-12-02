<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countriesAndNationalities.aspx.cs"
    Inherits="lab1_task2_WebForm_.countriesAndNationalities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"></head>
<body>
    <form id="form1" runat="server">
        <div id="mainBlockId">
            <div id="findBlockId" style="display: flex">
                <label for="titleOfImage">Input title of image</label>
                <textarea id="titleOfImage" name="titleOfImage" cols="20" name="S1" rows="1"></textarea>
                <asp:ImageButton ID="imageButton" OnClick="getImage" runat="server" style="width: 15px; height: 15px;" />
            </div>
            <asp:Label ID="titleOfImageLabel" runat="server"></asp:Label>
            <div id="imageBlockId" style="display: block">
                <asp:Image ID="image" runat="server"/>
            </div>
        </div>
    </form>
</body>
</html>