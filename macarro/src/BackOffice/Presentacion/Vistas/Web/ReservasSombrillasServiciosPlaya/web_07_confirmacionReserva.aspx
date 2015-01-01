<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_confirmacionReserva.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya.web_07_confirmacionReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
        <link href="../../../comun/resources/css/ReservasSombrillasServiciosPlaya/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
      <h2 class="centrado subtitulo">Confirmacion de Reservas</h2>
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
      <div class="lab">

         <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0">
                <asp:View ID="GV_Usuario" runat="server">

                    <asp:GridView ID="Tabla" CssClass="mGrid" AllowPaging="True" HorizontalAlign ="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                             Width="832px" ForeColor="#99CCFF" PageSize="5" OnRowCommand="grid_RowCommand_Puesto" OnRowEditing="grid_RowEditing" 
                                            OnPageIndexChanging="grid_PageIndexChanging_Puesto">

                      

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Reserva" DataField="ID" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText=" Fecha de la reserva" DataField="Fecha"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Fila" DataField="Fila"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Columna" DataField="Columna"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                           

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>


                    <asp:GridView ID="Tabla2" CssClass="mGrid" AllowPaging="False" HorizontalAlign ="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                             Width="832px" ForeColor="#99CCFF" PageSize="5" >

                      

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Reserva" DataField="ID" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Servicio" DataField="Servicio"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Hora Inicio" DataField="Inicio"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Hora Fin" DataField="Fin"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>

                </asp:View>
            </asp:MultiView>
          <br />
          <br />
                <asp:Table CssClass="" ID="Table1" runat="server" Height="100px" Width="560px" HorizontalAlign="Center">
                    
                    <asp:TableRow ID="TableRow2" runat="server">
                        <asp:TableCell runat="server" Width="50%">
                             <asp:Label ID="Estado_Reserva" CssClass ="combo_box" runat="server" Text="Estado Actual de la Reserva" align="center"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="50%"> 
                          <asp:DropDownList ID="ddlConfirmar" runat="server" CssClass ="combo_box" align="center">
                          </asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell ID="TableCell1" runat="server" Width="50%" horizontalalign="right">
                             <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" horizontalalign="right" OnClientClick ="return confirm('El estado seleccionado sera asginado a la reserva.') "/>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell2" runat="server" Width="50%" align="left">
                            <asp:Button ID="botonCancelar" runat="server" Text="Cancelar" CssClass="Boton" align="center"  />
                        </asp:TableCell>
                     </asp:TableRow>

                </asp:Table>
           
    </div>
</asp:Content>
   

        