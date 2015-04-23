﻿<%@ Page Title="" Language="C#" MasterPageFile="~/IntegrantesMaster.Master" AutoEventWireup="true" CodeBehind="Territoriales.aspx.cs" Inherits="Networks.Territoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="Data">
       <tr>
           <td colspan="4" class="title space">Agregar Territorial</td>
       </tr>
       <tr>
           <td class="space">Sección:</td>
           <td>
               <asp:DropDownList runat="server" ID="DpSeccion"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td class="space">Coordinador:</td>
           <td>
               <asp:DropDownList runat="server" ID="DpCoor"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td class="space columnlabel">Apellido Paterno:</td>
           <td><asp:TextBox runat="server" ID="TxtLastName" CssClass="columndata"></asp:TextBox></td>
           <td class="space columnlabel right">Apellido Materno:</td>
           <td><asp:TextBox runat="server" ID="TxtMiddleName" CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="space columnlabel">Nombre(s):</td>
           <td><asp:TextBox runat="server" ID="TxtNames" CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="space columnlabel">Calle y No.:</td>
           <td><asp:TextBox runat="server" ID="TxtStret" CssClass="columndata"></asp:TextBox></td>
           <td class="space columnlabel right">Colonia:</td>
           <td><asp:TextBox runat="server" ID="TxtColony" CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="space columnlabel">Email:</td>
           <td><asp:TextBox runat="server" ID="TxtEmail"  CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="space columnlabel">Telefono-Domicilio:</td>
           <td><asp:TextBox runat="server" ID="TxtPhoneHome"  CssClass="columndata"></asp:TextBox></td>
           <td class="space columnlabel right">Telefono-Oficina:</td>
           <td><asp:TextBox runat="server" ID="TxtPhoneOffice"  CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td class="space columnlabel">Nextel:</td>
           <td><asp:TextBox runat="server" ID="TxtPhoneNextel" W CssClass="columndata"></asp:TextBox></td>
       </tr>
       <tr>
           <td colspan="2" style="text-align:center;" class="space"><asp:Button class="green" runat="server" ID="BtnSearch" Text="Buscar" OnClick="BtnSearch_Click" /></td>       
           <td colspan="2" style="text-align:center;" class="space"><asp:Button class="green" runat="server" ID="BtnSave" Text="Guardar" OnClick="BtnSave_Click" /></td>
       </tr>
     <%if(Saved == false)
         { %>
       <tr>
           <td colspan="4" style="color:red">No se guardo el territorial seguramente ya existe.</td>
       </tr>   
       <%} %>
   </table>
    
    <asp:DataGrid CssClass="space" AutoGenerateColumns="true" runat="server" ID="DgridTerr" AlternatingItemStyle-BackColor="#FAEBD7">
        <HeaderStyle BackColor="#B40431" Font-Bold="true" ForeColor="White" />                   
    </asp:DataGrid>        
</asp:Content>
