<%@ Page Title="" Language="C#" MasterPageFile="~/IntegrantesMaster.Master" AutoEventWireup="true" CodeBehind="Territoriales.aspx.cs" Inherits="Networks.Territoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table>
       <tr>
           <td colspan="2" class="title space">Agregar Territorial</td>
       </tr>
       <tr>
           <td colspan="2">
                <asp:DataGrid CssClass="space" AutoGenerateColumns="true" runat="server" ID="DgridTerr" AlternatingItemStyle-BackColor="#FAEBD7">
                    <HeaderStyle BackColor="#B40431" Font-Bold="true" ForeColor="White" />                   
                </asp:DataGrid>
           </td>
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
           <td style="width:200px;" class="space">Apellido Paterno:</td>
           <td><asp:TextBox runat="server" ID="TxtLastName" Width="400"></asp:TextBox></td>
       </tr>
       <tr>
           <td style="width:200px;" class="space">Apellido Materno:</td>
           <td><asp:TextBox runat="server" ID="TxtMiddleName" Width="400"></asp:TextBox></td>
       </tr>
       <tr>
           <td style="width:200px;" class="space">Nombre(s):</td>
           <td><asp:TextBox runat="server" ID="TxtNames" Width="400"></asp:TextBox></td>
       </tr>
       <tr>
           <td colspan="2" style="text-align:right;" class="space"><asp:Button class="green" runat="server" ID="BtnSave" Text="Guardar" OnClick="BtnSave_Click" /></td>
       </tr>
   </table>
</asp:Content>
