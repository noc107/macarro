<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master"
     AutoEventWireup="true" CodeBehind="web_07_consultaReservaServicio.aspx.cs"
     Inherits="FrontOffice.Presentacion.Vistas.Web.Reservas.web_07_consultaReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

          <link href="../../../../comun/resources/css/Reservas/estilo.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Consulta Reserva Servicios
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

   
<div  id="principal1">

     <asp:Label ID="MensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    
     <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0">
                <asp:View id="GV_Usuario" runat="server">



                    <asp:GridView ID="GridViewUsuario1" CssClass="mGrid" AllowPaging="False" HorizontalAlign ="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                             Width="900px" ForeColor="#99CCFF" OnRowDataBound="GV_RowDataBound" DataKeyNames="IDReserva,Estado,Cantidad,Nombre">
                     

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="ID Reserva" DataField="IDReserva" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Hora Inicio" DataField="Inicio"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Hora Fin" DataField="Fin"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Nombre Servicio" DataField="Nombre"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Costo Total" DataField="Total"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                 
                            <asp:BoundField HeaderText="Estado" DataField="Estado"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                 
                            <asp:BoundField HeaderText="Acciones" DataField="Acciones"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>

                </asp:View>
            </asp:MultiView>

        <asp:Label ID="MensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
    
    
</div>
    

</asp:Content>
