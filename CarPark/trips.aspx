<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trips.aspx.cs" Inherits="CarPark.trips" %>

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
            <a class="navbar-brand">Рейсы</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
            <li><a href="javascript:history.go(-1);">Назад</a></li>
            </ul>
        </div>
        </div>
    </nav>

    <br />

    <form id="form1" runat="server">
        <div class="container">
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="DRIVER_ID" HeaderText="DRIVER_ID" SortExpression="DRIVER_ID" />
                    <asp:BoundField DataField="ROUTE_ID" HeaderText="ROUTE_ID" SortExpression="ROUTE_ID" />
                    <asp:BoundField DataField="TRIP_DATE" HeaderText="TRIP_DATE" SortExpression="TRIP_DATE" />
                    <asp:BoundField DataField="AV_SEATS" HeaderText="AV_SEATS" SortExpression="AV_SEATS" />
                    <asp:BoundField DataField="ADULT_TICKET" HeaderText="ADULT_TICKET" SortExpression="ADULT_TICKET" />
                    <asp:BoundField DataField="CHILD_TICKET" HeaderText="CHILD_TICKET" SortExpression="CHILD_TICKET" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;TRIPS&quot;"></asp:SqlDataSource>
            <br />
            
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
