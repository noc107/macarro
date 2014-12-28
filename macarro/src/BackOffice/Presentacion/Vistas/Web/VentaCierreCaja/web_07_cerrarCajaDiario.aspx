<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_cerrarCajaDiario.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
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

    <div  id="contenedor" class="Estilocontenedor">
    <div class="Divporfila;">
        <div class="Estilodivlabels;">
          <h2>Datos del cierre diario</h2>

        <asp:Table ID="TablaCierreMensual" runat="server"  CssClass="tablaCierreCaja">
            
            <asp:TableRow ID="TableRow6" runat="server"> 

                    <asp:TableCell ID="TableCell15" runat="server">
              
                        <asp:Label ID="Label5" runat="server" Text="Fecha:" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell6" runat="server">

                        <asp:Label ID="Fecha" CssClass="labels" runat="server" Text="Label"></asp:Label>
                        
                    </asp:TableCell>

                </asp:TableRow> 

                <asp:TableRow ID="TableRow1" runat="server"> 

                    <asp:TableCell ID="TableCell1" runat="server">
              
                        <asp:Label ID="Label6" runat="server" Text="Saldo anterior:" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell5" runat="server">

                        <asp:Label ID="SaldoAnterior" CssClass="labels" runat="server" Text="Label"></asp:Label>
                        
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow2" runat="server"> 

                    <asp:TableCell ID="TableCell2" runat="server">
              
                        <asp:Label ID="Label1" runat="server" Text="Entradas:" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell4" runat="server">

                        <asp:Label ID="Entrada" CssClass="labels" runat="server" Text="Label"></asp:Label>
                        
                    </asp:TableCell>


                </asp:TableRow>
                
                <asp:TableRow ID="TableRow3" runat="server"> 

                    <asp:TableCell ID="TableCell3" runat="server">
              
                        <asp:Label ID="Label2" runat="server" Text="Saldo actual:" CssClass="labels"></asp:Label>

                    </asp:TableCell>

                    <asp:TableCell ID="TableCell7" runat="server">

                        <asp:Label ID="SaldoActual" CssClass="labels" runat="server" Text="Label"></asp:Label>
                        
                    </asp:TableCell>


                </asp:TableRow>

            </asp:Table>
        <div id="botonImprimirFactura">
            <asp:Button ID="BotonCerrarCaja" runat="server" Text="Cerrar" CssClass="Boton botonImprimir" OnClick="BotonCerrarCaja_Click" />
        </div>
        </div>
       </div>
      </div>
</asp:Content>
