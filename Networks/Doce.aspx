<%@ Page Title="" Language="C#" MasterPageFile="~/IntegrantesMaster.Master" AutoEventWireup="true" CodeBehind="Doce.aspx.cs" Inherits="Networks.Doce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table class="Data">
       <tr>
           <td colspan="4" class="title space">Agregar a "Los 12"</td>
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
           <td colspan="4" style="text-align:center;" class="space"><asp:Button class="green" runat="server" ID="BtnSave" Text="Guardar" OnClick="BtnSave_Click" /></td>
       </tr>
       <%if(Saved == false)
         { %>
       <tr>
           <td colspan="4" class="warning">No se guardó el Integrante. Razones: Ya existe o no se introdujo nombre completo del mismo.</td>
       </tr>   
       <%} %>
        <asp:DataGrid CssClass="space" AutoGenerateColumns="true" runat="server" ID="Dgrid12"  AlternatingItemStyle-BackColor="#FAEBD7">
            <HeaderStyle BackColor="#B40431" Font-Bold="true" ForeColor="White" />                   
        </asp:DataGrid>
   </table>
</asp:Content>
