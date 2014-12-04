<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_modificarProducto.aspx.cs" Inherits="back_office.Interfaz.web.MenuRestaurante.web_05_modificarProducto" %>
<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>

<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/NombreProducto.ascx" TagPrefix="uc1" TagName="NombreProducto" %>
<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/PrecioProducto.ascx" TagPrefix="uc2" TagName="PrecioProducto" %>
<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/DescripcionProducto.ascx" TagPrefix="uc3" TagName="DescripcionProducto" %>
<%@ Register Src="~/Interfaz/web/MenuRestaurante/componentes/mensajeDeError.ascx" TagPrefix="uc4" TagName="Mensaje" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMenuRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menu de restaurante
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

    <div  id="contenedor" class="Estilocontenedor;">
    <div class="Divporfila;">
        <div class="Estilodivlabels; Estilodivtextbox;">

            <h2>Modificar Producto</h2>

            <uc2:mensajeDeConfirmacion runat="server" ID="mensajeDeConfirmacion" />

    
        <asp:Table ID="Table2" runat="server"  CssClass="tabla">
            
            <asp:TableRow ID="TableRow6" runat="server"> 

                    <asp:TableCell ID="TableCell15" runat="server">
              
                        <asp:Label ID="Label4" runat="server" Text="Nombre (*):" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell16" runat="server">
                
                        <uc1:NombreProducto runat="server" ID="NombreProducto" />

                    </asp:TableCell>

                </asp:TableRow> 
   
            <asp:TableRow ID="TableRow10" runat="server"> 

                    <asp:TableCell ID="TableCell17" runat="server">
              
                        <asp:Label ID="Label10" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell18" runat="server">
                
                        <uc3:DescripcionProducto runat="server" ID="DescripcionProducto" />

                    </asp:TableCell>

             </asp:TableRow>

            <asp:TableRow ID="TableRow1" runat="server"> 

                    <asp:TableCell ID="TableCell1" runat="server">
              
                         <asp:Label ID="Label7" runat="server" Text="Precio (*):" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell2" runat="server">
                
                        <uc2:PrecioProducto runat="server" ID="precioProducto" />

                    </asp:TableCell>

             </asp:TableRow> 

            <asp:TableRow ID="TableRow2" runat="server"> 

                    <asp:TableCell ID="TableCell3" runat="server">
              
                         <asp:Label ID="Label8" runat="server" Text="Seccion (*):" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell4" runat="server">
                
                        
                <asp:DropDownList ID="Seccion" CssClass="combo_box" runat="server">
                    <asp:ListItem Value="Seleccione..">Seleccione..</asp:ListItem>
                    <asp:ListItem Value="1">Entradas</asp:ListItem>
                    <asp:ListItem Value="2">Carnes</asp:ListItem>
                    <asp:ListItem Value="3">Pescados</asp:ListItem>
                    <asp:ListItem Value="4">Bebidas</asp:ListItem>
                    <asp:ListItem Value="5">Postres</asp:ListItem>
                </asp:DropDownList>
          
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="Seccion"
                    ErrorMessage="Seleccione el tipo de Sección" 
                    Text="*"
                    ForeColor="Red"
                    InitialValue="Seleccione..">
                </asp:RequiredFieldValidator>
            
                  
               </asp:TableCell>    

             </asp:TableRow> 
        </asp:Table>

   <table class="tabla">
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>
            </td>
        </tr>
    </table>
    <br />

    <div class="marginBotonAgregar">
        <asp:Button ID="ButtonAgregar" CssClass="Boton" runat="server" Text="Modificar" OnClientClick=""/>
    </div>
      
        </div> 
    </div>
   <uc4:Mensaje runat="server" ID="MensajeLabel" />
 </div>
</asp:Content>
