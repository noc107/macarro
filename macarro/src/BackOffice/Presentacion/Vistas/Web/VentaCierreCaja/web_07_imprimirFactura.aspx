<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_imprimirFactura.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm2" %>
<%@ PreviousPageType VirtualPath="web_07_gestionarVenta.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Cierre de Caja
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Factura</h2>
 
       <asp:Label ID="_mensajeError" runat="server"  Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
       <asp:Label ID="_mensajeExito" runat="server"  Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

  
      <div id="contFactura">

        <%-- Datos Cliente--%>
        
    <div>

        <asp:Table CssClass="TablaCliente" ID="TableClient" runat="server">
               
            <asp:TableRow ID="TableRow10" runat="server">

                <asp:TableCell CssClass="TablaNombre" ID="TableCell15" runat="server">

                    <asp:Label CssClass="labels" ID="labelFecha" runat="server" >Fecha:</asp:Label>

                </asp:TableCell><asp:TableCell CssClass="TablaValor"  ID="TableCell17" runat="server">
                    
                    <asp:Label CssClass="labels" ID="Fecha" runat="server"></asp:Label>

                    </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRow1" runat="server">

                <asp:TableCell CssClass="TablaNombre" ID="TableCell1" runat="server">

                    <asp:Label CssClass="labels" ID="labelDocIdentidad" runat="server" >Doc. Identidad:</asp:Label>

                </asp:TableCell><asp:TableCell CssClass="TablaValor"  ID="TableCell2" runat="server">
                    
                    <asp:Label CssClass="labels" ID="DocIdentidad" runat="server"></asp:Label>

                    </asp:TableCell>

            </asp:TableRow>

             <asp:TableRow ID="TableRow2" runat="server">

                <asp:TableCell CssClass="TablaNombre" ID="TableCell3" runat="server">

                    <asp:Label CssClass="labels" ID="labelNombres" runat="server">Nombre(s):</asp:Label>

                </asp:TableCell><asp:TableCell CssClass="TablaValor"  ID="TableCell4" runat="server">
                    
                    <asp:Label CssClass="labels" ID="Nombres" runat="server"></asp:Label>

                    </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow ID="TableRow3" runat="server">

                <asp:TableCell CssClass="TablaNombre" ID="TableCell5" runat="server">

                    <asp:Label CssClass="labels" ID="labelApellido" runat="server" >Apellido(s):</asp:Label>

                </asp:TableCell><asp:TableCell CssClass="TablaValor"  ID="TableCell6" runat="server">
                    
                    <asp:Label CssClass="labels" ID="Apellidos" runat="server"></asp:Label>

                    </asp:TableCell>

            </asp:TableRow>

            </asp:Table>
     </div>
        <%-- Fin Datos Cliente--%>
        
        <%-- Grid Productos--%>
        <div id="facturaFinal">
            <asp:GridView CssClass="mGrid gestionVentas" ID="gridFactura" runat="server" AutoGenerateColumns="False"
              AllowPaging="True" HorizontalAlign="Center" PageSize="8" BorderStyle="None"  AllowSorting="True" 
              GridLines="None" ForeColor="#99CCFF" OnPageIndexChanging="gridFactura_PageIndexChanging">
           
            <AlternatingRowStyle CssClass="alt" />  
            <Columns>    
                
                <asp:BoundField DataField="NombreItem" HeaderText="Producto">  
                <ItemStyle Width="360px" HorizontalAlign="Center" />
                </asp:BoundField>  

                <asp:BoundField DataField="Tipo" HeaderText="Tipo" >       
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" >       
                <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Precio" HeaderText="Precio" >       
                <ItemStyle Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>


            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />  
        </asp:GridView>
        </div>
         <%-- Fin Grid Productos--%>

          <%-- Total--%>

        <table id="totales">
            <tr>
                <td></td>
                <td></td>
                <td style="text-align:right;"><label class="labels">Sub Total</label></td>
                <td style="text-align:center;"><asp:Label ID="subTotal" runat="server" CssClass="labels"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align:right;"><label class="labels">Impuesto </label></td>
                <td style="text-align:center;"><asp:Label ID="montoIva" runat="server" CssClass="labels"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align:right;"><asp:Label ID="labelDescuento" runat="server" CssClass="labels" Text="Descuento"></asp:Label></td>
                <td style="text-align:center;"><asp:Label ID="montoDescuento" runat="server" CssClass="labels"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td style="text-align:right; border-top:1px solid #2980B9"><label class="labels">TOTAL</label></td>
                <td style="text-align:center; border-top:1px solid #2980B9""><asp:Label ID="total" runat="server" CssClass="labels"></asp:Label></td>
            </tr>
            
        </table>

          <%-- Fin Total--%>

        <div id="botonImprimirFactura">
            <asp:Button ID="BotonRegresarFactura" runat="server" Text="Regresar" CssClass="Boton botonImprimir" OnClick="BotonRegresarFactura_Click"/>
            <asp:Button ID="BotonImprimir" runat="server" Text="Imprimir" CssClass="Boton botonImprimir" />
        </div>
    </div>
</asp:Content>
