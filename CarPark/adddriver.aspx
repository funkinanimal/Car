﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adddriver.aspx.cs" Inherits="CarPark.adddriver" %>

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
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <fieldset>
                        <legend>Добавить водителя</legend>

                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" placeholder="Фамилия"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Имя"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Отчество"></asp:TextBox>
                        <br />
                        <br />
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="MODEL" DataValueField="V_ID">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button CssClass="form-control btn btn-success" ID="Button1" runat="server" Text="Добавить" OnClick="Button1_Click" />
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;VEHICLES&quot;"></asp:SqlDataSource>

                    </fieldset>
                </div>
                <div class="col-lg-4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                            <asp:BoundField DataField="PATRON" HeaderText="PATRON" SortExpression="PATRON" />
                            <asp:BoundField DataField="VEHICLE_ID" HeaderText="VEHICLE_ID" SortExpression="VEHICLE_ID" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;DRIVERS&quot;"></asp:SqlDataSource>
                </div>
            </div>   
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
