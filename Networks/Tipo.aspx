<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tipo.aspx.cs" Inherits="Networks.Tipo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REDES</title>
    <link href="Css/General.css" rel="stylesheet" />
    <link href="Css/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="FormType" runat="server">
        <header>
            <a href="Default.aspx"><h5>&lt;&lt;INICIO</h5></a>
        </header>        
        <div class="flexcontainer" runat="server" id="Step1">               
            <div>
                <asp:Button class="green" runat="server" ID="BtnIntegrants" OnClick="BtnIntegrants_Click" Text="Integrantes"/>
            </div>
            <div>                
                <asp:Button class="green" runat="server" ID="BtnDistricts" OnClick="BtnDistricts_Click" Text="Distritos"/>
            </div>        
        </div>
     </form>
</body>
</html>
