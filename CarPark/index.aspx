<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CarPark.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="bootstrap.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
    
            <br />
    
            <br />
            <div class ="row col-lg-4"></div>   
             
            <div class ="row col-lg-4">  
                <asp:TextBox ID="TextBox1" runat="server" class="form-control"  OnTextChanged="TextBox1_TextChanged" placeholder ="Логин"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox2" runat="server" class="form-control" type ="password" placeholder ="Пароль"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Войти" CssClass ="btn btn-success form-control" OnClick="Button1_Click" />
            </div>

            <div class ="row col-lg-4"></div>  
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
