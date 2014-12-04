<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_gestionarVenta.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm3" %>
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
    <h2>Gestionar Ventas</h2>
    <div id="gestionVentas">
        <asp:GridView CssClass="mGrid gestionVentas" ID="Ventas" runat="server" AutoGenerateColumns="False" AllowPaging="True"
         OnRowDataBound="Ventas_RowDataBound" HorizontalAlign="Center" PageSize="8" BorderStyle="None"  AllowSorting="true" GridLines="None" ForeColor="#99CCFF">
            <AlternatingRowStyle CssClass="alt" />  
            <Columns>    
                
                <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura">  
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Cliente" HeaderText="Cliente" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Fecha" HeaderText="Fecha" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Monto" HeaderText="Monto" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Facturado" HeaderText="Facturado" >       
                <ItemStyle Width="50px" HorizontalAlign="Center" />
                </asp:BoundField>
               
                <asp:BoundField HeaderText="Acciones" DataField="Acciones" >       
                <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>

            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />  
        </asp:GridView>

        <asp:Label ID="LabelCierreCaja" runat="server" Text="Cierre de Caja" CssClass="labels labelCierre"></asp:Label><br />

        <div id="buttonsFactura">
            <asp:Button ID="ButtonCierreDiario" runat="server" Text="Diario" CssClass="Boton botonCierre" />
            <asp:Button ID="ButtonCierreMensual" runat="server" Text="Mensual" CssClass="Boton botonCierre" />
        </div>
        
    
    </div>
    

</asp:Content>
