<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_consultarInventario.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.web_2_consultarInventario" 
    MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"%>

<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>
<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/comboConsultarInventario.ascx" TagPrefix="uc1" TagName="comboConsultarInventario" %>




<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Consultar Inventario
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Consultar Inventario</h2>
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <uc1:mensajeDeEstado runat="server" id="mensajeDeEstado" />
        <uc1:comboConsultarInventario runat="server" ID="comboConsultarInventario" />
     <div>
        <div class="btn_aceptar_posicion">
            <asp:Button ID="botonAceptar"  OnClick="ConsultarListaInventario"  runat="server" Text="Aceptar" CssClass="Boton"/>
        </div>
    </div>
        
        <div id="Datos"  role="form" runat="server">
            <asp:MultiView ID="MvListaInventario" runat="server" ActiveViewIndex="0">
                <!-- Gridview con Ajax -->
                <asp:View ID="GvOrdenInventario" runat="server">
                   
                            <asp:GridView ID="GvInventario" runat="server"  CssClass="mGrid" BorderStyle="None"  AllowSorting="true"
                                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True"  PageSize="7"
                                            DataKeyNames="ID"                                            
                                            OnPageIndexChanging="GvInventarioPageIndexChanging"
                                            OnRowCommand ="GvInventarioRowCommand" >
                                <AlternatingRowStyle CssClass="alt" />

                                <Columns>
                                    <asp:BoundField HeaderText="Codigo" DataField="CODIGO" ItemStyle-Width="105px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Tipo" DataField="TIPO" ItemStyle-Width="95px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Descripcion" DataField="DESCRIPCION" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Estado" DataField ="ESTADO" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Precio" DataField="PRECIO" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                                         
                                         <asp:ButtonField  CommandName="Modificar"
                                            ImageUrl="~/comun/resources/img/Data-Edit-128.png" 
                                             ButtonType="Image" 
                                             ControlStyle-CssClass="actions_icons"
                                             ItemStyle-Width="50px" 
                                             ItemStyle-Height="50px"                                              
                                             ItemStyle-VerticalAlign="Middle"
                                             ItemStyle-HorizontalAlign="Center"
                                            />

                                        <asp:ButtonField  CommandName="Eliminar"
                                             ImageUrl="~/comun/resources/img/Garbage-Closed-128.png" 
                                             ButtonType="Image" 
                                             ControlStyle-CssClass="actions_icons"
                                             ItemStyle-Width="50px" 
                                             ItemStyle-Height="50px"
                                             ItemStyle-VerticalAlign="Middle"
                                             ItemStyle-HorizontalAlign="Center"
                                            />
                                </Columns>
                                <PagerSettings Mode="Numeric" Position="Bottom"  PageButtonCount="5"/>
                                <pagerstyle CssClass="pgr"  />
                            </asp:GridView>
                        
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <br/>
                            Cargando ...
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </asp:View>
                    

            </asp:MultiView>
        </div>
                <div>
        <div class="btn_aceptar_posicion">
            <asp:Button ID="Btn_Modificar" Width="130px" OnClick="Btn_Modificar_Click" Visible="false"  runat="server" Text="Modificar Todo" CssClass="Boton"/>
        </div>
    </div>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="botonAceptar" />
            </Triggers>
                </asp:UpdatePanel>
    </div>
</asp:Content>
