<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vehicles.aspx.cs" Inherits="CarPark.vehicles" %>

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
            <a class="navbar-brand">Автомобили</a>
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
    
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="V_ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="V_ID" HeaderText="V_ID" ReadOnly="True" SortExpression="V_ID" />
                    <asp:BoundField DataField="PLATE" HeaderText="PLATE" SortExpression="PLATE" />
                    <asp:BoundField DataField="MODEL" HeaderText="MODEL" SortExpression="MODEL" />
                    <asp:BoundField DataField="SEATS" HeaderText="SEATS" SortExpression="SEATS" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" DeleteCommand="DELETE FROM &quot;VEHICLES&quot; WHERE &quot;V_ID&quot; = :V_ID" InsertCommand="INSERT INTO &quot;VEHICLES&quot; (&quot;V_ID&quot;, &quot;PLATE&quot;, &quot;MODEL&quot;, &quot;SEATS&quot;) VALUES (:V_ID, :PLATE, :MODEL, :SEATS)" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;VEHICLES&quot;" UpdateCommand="UPDATE &quot;VEHICLES&quot; SET &quot;PLATE&quot; = :PLATE, &quot;MODEL&quot; = :MODEL, &quot;SEATS&quot; = :SEATS WHERE &quot;V_ID&quot; = :V_ID">
                <DeleteParameters>
                    <asp:Parameter Name="V_ID" Type="Decimal" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="V_ID" Type="Decimal" />
                    <asp:Parameter Name="PLATE" Type="String" />
                    <asp:Parameter Name="MODEL" Type="String" />
                    <asp:Parameter Name="SEATS" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="PLATE" Type="String" />
                    <asp:Parameter Name="MODEL" Type="String" />
                    <asp:Parameter Name="SEATS" Type="Decimal" />
                    <asp:Parameter Name="V_ID" Type="Decimal" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
    
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="bootstrap.js"></script>
</body>
</html>
