<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="drivers.aspx.cs" Inherits="CarPark.drivers" %>

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
            <a class="navbar-brand" >Водители</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
            <li><a href="javascript:history.go(-1);">Назад</a></li>
            </ul>
        </div>
        </div>
    </nav>

    <br />

    <form id="form2" runat="server">
        <div class="container">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="LASTNAME" HeaderText="LASTNAME" SortExpression="LASTNAME" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                            <asp:BoundField DataField="PATRON" HeaderText="PATRON" SortExpression="PATRON" />
                            <asp:BoundField DataField="VEHICLE_ID" HeaderText="VEHICLE_ID" SortExpression="VEHICLE_ID" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:autocon %>" DeleteCommand="DELETE FROM &quot;DRIVERS&quot; WHERE &quot;ID&quot; = :ID" InsertCommand="INSERT INTO &quot;DRIVERS&quot; (&quot;ID&quot;, &quot;LASTNAME&quot;, &quot;NAME&quot;, &quot;PATRON&quot;, &quot;VEHICLE_ID&quot;) VALUES (:ID, :LASTNAME, :NAME, :PATRON, :VEHICLE_ID)" ProviderName="<%$ ConnectionStrings:autocon.ProviderName %>" SelectCommand="SELECT * FROM &quot;DRIVERS&quot;" UpdateCommand="UPDATE &quot;DRIVERS&quot; SET &quot;LASTNAME&quot; = :LASTNAME, &quot;NAME&quot; = :NAME, &quot;PATRON&quot; = :PATRON, &quot;VEHICLE_ID&quot; = :VEHICLE_ID WHERE &quot;ID&quot; = :ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Decimal" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID" Type="Decimal" />
                    <asp:Parameter Name="LASTNAME" Type="String" />
                    <asp:Parameter Name="NAME" Type="String" />
                    <asp:Parameter Name="PATRON" Type="String" />
                    <asp:Parameter Name="VEHICLE_ID" Type="Decimal" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="LASTNAME" Type="String" />
                    <asp:Parameter Name="NAME" Type="String" />
                    <asp:Parameter Name="PATRON" Type="String" />
                    <asp:Parameter Name="VEHICLE_ID" Type="Decimal" />
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
