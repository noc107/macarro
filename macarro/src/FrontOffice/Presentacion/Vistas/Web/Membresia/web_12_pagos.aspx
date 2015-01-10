<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_12_pagos.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_12_pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link runat="server" media="screen" href="/comun/resources/css/loged_in.css" rel="stylesheet" />
    <link runat="server" media="screen" href="/comun/resources/css/standards.css" rel="stylesheet" />
    <link runat="server" media="screen" href="/comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
    <h2>Ver Pagos</h2>
    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
    <div id="Mensajes">
        <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
    </div>
    <div class="botones">

        <asp:TextBox ID="busquedaPorFecha" CssClass="textbox owntext" TextMode="Date" runat="server"></asp:TextBox>
        <asp:ImageButton ID="busqueda" ImageUrl="/comun/resources/img/icon-buscar.png" CssClass="botonBusqueda" runat="server" OnClick="busqueda_Click" />

    </div>
    <div id="Grid">
                <asp:MultiView ID="MvListaPagos" runat="server" ActiveViewIndex="0">
                <!-- Gridview con Ajax -->
                <asp:View ID="ViewPagos" runat="server">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            <asp:GridView ID="_gridPagosHechos" runat="server"  CssClass="mGrid" BorderStyle="None"  AllowSorting="true"
                                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True"  PageSize="7"
                                            DataKeyNames="ID"                                            
                                            OnPageIndexChanging="_gridPagosHechos_PageIndexChanging"
                                            OnRowCommand ="_gridPagosHechos_RowCommand" ShowHeaderWhenEmpty="true">
                                <AlternatingRowStyle CssClass="alt" />

                                <Columns>
                                    <asp:BoundField HeaderText="Fecha pago" DataField="FECHAPAGO" ItemStyle-Width="105px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Monto" DataField="MONTO" ItemStyle-Width="95px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Ultimos 4 digitos de tarjeta" DataField="NUMEROTARJETA" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                                         
                                         <asp:ButtonField HeaderText="Ver detalle"  CommandName="Ver"
                                            ImageUrl="~/comun/resources/img/View-128.png" 
                                             ButtonType="Image" 
                                             ControlStyle-CssClass="actions_icons"
                                             ItemStyle-Width="50px" 
                                             ItemStyle-Height="50px"                                              
                                             ItemStyle-VerticalAlign="Middle"
                                             ItemStyle-HorizontalAlign="Center"
                                            />

                                </Columns>
                                <EmptyDataTemplate> 
                                    <center>No se encontraron resultados</center> 
                                </EmptyDataTemplate>
                                <PagerSettings Mode="Numeric" Position="Bottom"  PageButtonCount="5"/>
                                <pagerstyle CssClass="pgr"  />
                            </asp:GridView>
                        </ContentTemplate>
                       <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="busqueda" EventName="Click" />
                       </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div class="wrapper">
                                <asp:Label ID="Label1" CssClass="updateProgress" runat="server" Text="Cargando.."></asp:Label>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </asp:View>
                    

            </asp:MultiView>

    </div>
    <div class="botones">
        <asp:Button ID="_volver" CssClass="Boton VolverSolo" runat="server" Text="Volver"  OnClick="_volver_Click" />
    </div>
</asp:Content>
