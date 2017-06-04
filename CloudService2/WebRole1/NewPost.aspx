<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="WebRole1.NewPost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Title: <asp:TextBox runat=server ID=Title />
    <br />
   Author: <asp:TextBox runat=server ID=Author/>
    <br />
    <asp:TextBox TextMode=MultiLine runat="server" ID=Text Rows=8 Columns=100 />

    <div>
    <asp:Button runat=server ID=Publish Text="Publish" onclick="Publish_Click" />
    <asp:Button runat=server ID=Cancel Text="Cancel" onclick="Cancel_Click" />    
    </div>
    </div>
    </form>
</body>
</html>
