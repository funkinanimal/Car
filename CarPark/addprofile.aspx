<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addprofile.aspx.cs" Inherits="CarPark.addprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="bootstrap.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <nav class="navbar navbar-default">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="admin.aspx">Автопарк</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li><a href="addprofile.aspx">Добавить пользователя</a></li>
              <li><a href="profiles.aspx">Профили</a></li>
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Таблицы<span class="caret"></span></a>
              <ul class="dropdown-menu" role="menu">
                <li><a href="drivers.aspx">Водители</a></li>
                <li><a href="period.aspx">Периодичность</a></li>
                <li><a href="routes.aspx">Маршруты</a></li>
                <li><a href="trips.aspx">Рейсы</a></li>
                <li><a href="vehicles.aspx">Автомобили</a></li>
              </ul>
            </li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            <li><a href="index.aspx">На страницу авторизации</a></li>
          </ul>
        </div>
      </div>
    </nav>
    <br />

    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4">

                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Логин"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Пароль" type="password"></asp:TextBox>
                    <br />
                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Повторите пароль" type="password" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text=" Администратор" />
                    <br />
&nbsp;<br />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <asp:Button CssClass="form-control btn btn-default" ID="Button1" runat="server" Text="Создать" OnClick="Button1_Click" />

                </div>
                <div class="col-lg-4"></div>
            </div>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
