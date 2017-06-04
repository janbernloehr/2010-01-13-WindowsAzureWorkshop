<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1._Default" %>

<!doctype html public "-//w3c//dtd xhtml 1.0 transitional//en" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Azure Blog</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:HyperLink runat=server  NavigateUrl="~/NewPost.aspx" Text="Neuer Post" />
    
    <asp:Repeater runat=server ID=PostRepeater DataSourceId=PostSource>
    <ItemTemplate>
    <div class="posting">
    <div class="title">
    <%#Eval("Title") %>
    </div>
    <div class="author">
    created by <%#Eval("Author") %> at <%#Eval("DateCreated") %>
    </div>
    <div>
    <%#Eval("Text") %>
    </div>
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
