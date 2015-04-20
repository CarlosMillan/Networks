<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Networks.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REDES</title>
    <link href="Css/General.css" rel="stylesheet" />   
</head>
<body>
    <form id="FormHome" runat="server">
        <div class="centered title">REDES DE ....... </div>
        <br />
        <div class="flexcontainer" runat="server" id="Step1">               
            <div>
                <asp:Button class="green" runat="server" ID="BtnRegestry" OnClick="BtnRegestry_Click" Text="Registrar"/>
            </div>
            <div>                
                <asp:Button class="green" runat="server" ID="BtnQuery" OnClick="BtnQuery_Click" Text="Consultar"/>
            </div>        
        </div>
     </form>
</body>
</html>
