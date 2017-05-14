<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="Lab11.Lab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Задание 1<br />
    
        <asp:TextBox ID="TextBox1" runat="server" Width="16px"></asp:TextBox>
        x^2 +
        <asp:TextBox ID="TextBox2" runat="server" Width="22px"></asp:TextBox>
        x +
        <asp:TextBox ID="TextBox3" runat="server" Width="16px"></asp:TextBox>
&nbsp;= 0&nbsp;&nbsp;
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Решить" />
        <br />
        <br />
        Ответ: <asp:Label ID="Label1" runat="server" Text="?"></asp:Label>
        <br />
        <br />
        Задание 2<br />
        <br />
        от
        <asp:TextBox ID="TextBox4" runat="server" Width="20px"></asp:TextBox>
&nbsp; до
        <asp:TextBox ID="TextBox5" runat="server" Width="22px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Четные" />
        <br />
        <br />
        Ответ:
        <asp:Label ID="Label2" runat="server" Text="?"></asp:Label>
        <br />
        <br />
&nbsp;Задание 3<br />
        <br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Содержит" OnCheckedChanged="RadioButton1_CheckedChanged" GroupName ="search" />
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Равен" OnCheckedChanged="RadioButton2_CheckedChanged" GroupName ="search" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Искать" OnClick="Button3_Click" />
        <br />
        <br />
&nbsp;Ответ:
        <asp:Label ID="Label3" runat="server" Text="?"></asp:Label>
        <br />
        <br />
        Задание 4<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:TextBox ID="TextBox7" runat="server" Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Поиск" />
        <br />
    
    </div>
    </form>
</body>
</html>
