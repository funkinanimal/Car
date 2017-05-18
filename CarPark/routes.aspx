<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="routes.aspx.cs" Inherits="CarPark.routes" %>

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
            <a class="navbar-brand">Маршруты</a>
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
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="DEP_PLACE" HeaderText="DEP_PLACE" SortExpression="DEP_PLACE" />
                    <asp:BoundField DataField="ARR_PLACE" HeaderText="ARR_PLACE" SortExpression="ARR_PLACE" />
                    <asp:BoundField DataField="TRIP_TIME" HeaderText="TRIP_TIME" SortExpression="TRIP_TIME" />
                    <asp:BoundField DataField="PERIOD_ID" HeaderText="PERIOD_ID" SortExpression="PERIOD_ID" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" DeleteCommand="DELETE FROM &quot;ROUTES&quot; WHERE &quot;ID&quot; = :ID" InsertCommand="INSERT INTO &quot;ROUTES&quot; (&quot;ID&quot;, &quot;DEP_PLACE&quot;, &quot;ARR_PLACE&quot;, &quot;TRIP_TIME&quot;, &quot;PERIOD_ID&quot;) VALUES (:ID, :DEP_PLACE, :ARR_PLACE, :TRIP_TIME, :PERIOD_ID)" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;ROUTES&quot;" UpdateCommand="UPDATE &quot;ROUTES&quot; SET &quot;DEP_PLACE&quot; = :DEP_PLACE, &quot;ARR_PLACE&quot; = :ARR_PLACE, &quot;TRIP_TIME&quot; = :TRIP_TIME, &quot;PERIOD_ID&quot; = :PERIOD_ID WHERE &quot;ID&quot; = :ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Decimal" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID" Type="Decimal" />
                    <asp:Parameter Name="DEP_PLACE" Type="String" />
                    <asp:Parameter Name="ARR_PLACE" Type="String" />
                    <asp:Parameter Name="TRIP_TIME" Type="Decimal" />
                    <asp:Parameter Name="PERIOD_ID" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="DEP_PLACE" Type="String" />
                    <asp:Parameter Name="ARR_PLACE" Type="String" />
                    <asp:Parameter Name="TRIP_TIME" Type="Decimal" />
                    <asp:Parameter Name="PERIOD_ID" Type="Decimal" />
                    <asp:Parameter Name="ID" Type="Decimal" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
