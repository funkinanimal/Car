﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="CarPark.schedule" %>

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
          <a class="navbar-brand" href="user.aspx">Автопарк</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li><a href ="cash.aspx">Касса</a></li>
            <li><a href ="cost.aspx">Общая стоимость</a></li>
            <li><a href ="routswithouttrips.aspx">Маршруты без рейсов</a></li>
            <li><a href ="output.aspx">Выходной документ</a></li>
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Добавить<span class="caret"></span></a>
                <ul class="dropdown-menu" role="menu">
                    <li><a href="addvehicle.aspx">Автомобиль</a></li>
                    <li><a href="adddriver.aspx">Водителя</a></li>
                    <li><a href="addrout.aspx">Маршрут</a></li>
                    <li><a href="addtrip.aspx">Рейс</a></li>
                </ul>
            </li>

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

            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Функции<span class="caret"></span></a>
              <ul class="dropdown-menu" role="menu">
                <li><a href="timearr.aspx">Время прибытия</a></li>
                <li><a href="triptoday.aspx">Сегодняшний рейс</a></li>
                <li><a href="schedule.aspx">Расписание водителей</a></li>
                <li><a href="unaccaptable.aspx">Недоустимые рейсы</a></li>
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
                <div class="col-lg-4">
                    <h2>Расписание водителя</h2>
                    <p>Здесь вы можете узнать расписание водителя. Для этого выберите водителя и нажмите кнопку<strong> выполнить.</strong>.</p>
                </div>
                <div class="col-lg-4">
                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="LASTNAME" DataValueField="ID">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button class="form-control btn btn-success" ID="Button1" runat="server" Text="Выполнить" OnClick="Button1_Click" />
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;DRIVERS&quot;"></asp:SqlDataSource>
                </div>
                <div class="col-lg-4">

                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="True" Rows="5" TextMode="MultiLine"></asp:TextBox>

                </div>
            </div>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
