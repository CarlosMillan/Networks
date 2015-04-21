<%@ Page Title="" Language="C#" MasterPageFile="~/DistrictsMaster.Master" AutoEventWireup="true" CodeBehind="Secciones.aspx.cs" Inherits="Networks.Secciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/General.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table>
       <tr>
           <td colspan="2" class="title space">Agregar Sección</td>           
       </tr>
       <tr>
           <td colspan="2">
               <asp:DataGrid CssClass="space" AutoGenerateColumns="true" runat="server" ID="DgridSecciones"  AlternatingItemStyle-BackColor="#FAEBD7">
                   <HeaderStyle BackColor="#B40431" Font-Bold="true" ForeColor="White" />                   
               </asp:DataGrid>
           </td>
       </tr>
       <tr>
           <td class="space">Distrito</td>
           <td>
               <asp:DropDownList runat="server" ID="DpDistritos"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td style="width:100px;" class="space">Nombre:</td>
           <td><asp:TextBox runat="server" ID="TxtName" Width="400"></asp:TextBox></td>
       </tr>
       <tr>
           <td colspan="2" style="text-align:right;" class="space"><asp:Button class="green" runat="server" ID="BtnSave" Text="Guardar" OnClick="BtnSave_Click" /></td>
       </tr>
       <%if(C.FailSave) 
         {%>
       <tr>
           <td colspan="2" style="color:red;">
               Parece que ya existe el registro
           </td>
       </tr>
       <%} %>
   </table>
</asp:Content>
