<%@ Page Title="" Language="C#" MasterPageFile="~/DistrictsMaster.Master" AutoEventWireup="true" CodeBehind="Distritos.aspx.cs" Inherits="Networks.Distritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/General.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">       
   <table>
       <tr>
           <td colspan="2" class="title space">Agregar Distrito</td>
       </tr>
       <tr>
           <td colspan="2">
                <asp:DataGrid CssClass="space" AutoGenerateColumns="true" runat="server" ID="DgridDistritos"></asp:DataGrid>
           </td>
       </tr>
       <tr>
           <td style="width:100px;" class="space">Nombre:</td>
           <td><asp:TextBox runat="server" ID="TxtName" Width="400"></asp:TextBox></td>
       </tr>
       <tr>
           <td colspan="2" style="text-align:right;" class="space"><asp:Button class="green" runat="server" ID="BtnSave" Text="Guardar" OnClick="BtnSave_Click" /></td>
       </tr>
   </table>
</asp:Content>