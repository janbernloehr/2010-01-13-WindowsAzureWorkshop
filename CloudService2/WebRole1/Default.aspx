<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1._Default" %>

<!doctype html public "-//w3c//dtd xhtml 1.0 transitional//en" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HyperLink runat=server Text="Neuer Post" NavigateUrl="~/NewPost.aspx" />
    <asp:Repeater runat=server DataSourceID=PostSource >
    <ItemTemplate>
    <h2><%#Eval("Title") %></h2>
    <div>
    created by <%#Eval("Author") %> on <%#Eval("DateCreated") %>
    </div>
   <div>
   <%#Eval("Text") %>
   </div>
    </ItemTemplate>
    <SeparatorTemplate>
    <hr />
    </SeparatorTemplate>
    </asp:Repeater>
    
    <asp:LinqDataSource runat=server ID=PostSource onselecting="PostSource_Selecting" />
    
    </div>
    </form>
</body>
</html>
