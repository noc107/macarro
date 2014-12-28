<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"
    AutoEventWireup="true" CodeBehind="web_07_listaReservas.aspx.cs"
     Inherits="BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya.web_07_listaReservas" %>
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
    <h2 class="centrado subtitulo">Lista de Reservas en Espera por Confirmacion</h2>
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <div class="lab">

         <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View ID="GV_Usuario" runat="server">

                    <asp:GridView ID="GridView" CssClass="mGrid" AllowPaging="True" HorizontalAlign ="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                             Width="510px" ForeColor="#99CCFF" PageSize="5" OnRowCommand="grid_RowCommand" OnRowEditing="grid_RowEditing" 
                                            OnPageIndexChanging="grid_PageIndexChanging">
                     

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Reserva" DataField="Reserva" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Total" DataField="Total"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                             <asp:BoundField HeaderText="Fecha Reserva" DataField="FechaReserva"  ItemStyle-Width="400px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/comun/resources/img/ModuloServiciosPlaya/Editar.png"  />

                            <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/comun/resources/img/ModuloServiciosPlaya/Eliminar.png"/>


                         </Columns>
                        <PagerStyle CssClass="pgr" />
                        <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>

                </asp:View>
            </asp:MultiView>


       </div>

         
            
             <asp:ValidationSummary ID="ValidationSummary0"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>

</asp:Content>