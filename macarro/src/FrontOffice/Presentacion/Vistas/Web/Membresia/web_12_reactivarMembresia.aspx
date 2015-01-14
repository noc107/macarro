<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_12_reactivarMembresia.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_12_reactivarMembresia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
        <link id="Link1" runat="server" media="screen" href="/comun/resources/css/loged_in.css" rel="stylesheet" />
    <link id="Link2" runat="server" media="screen" href="/comun/resources/css/standards.css" rel="stylesheet" />
    <link id="Link3" runat="server" media="screen" href="/comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
    <script src="../../../../comun/resources/js/jquery-1.11.1.js"></script>
    <script src="../../../../comun/resources/js/fileupload.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
    

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresía
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Activar Membresía</h2>
    <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
    
    <h3>Informacion de usuario</h3>
     <asp:Panel ID="Carnet" CssClass="Carnet2" runat="server">
        <div id="headerCarnet">
            <asp:Image ID="headerCarnetLogo" ImageUrl="/comun/resources/img/logo-macarro.png" runat="server" />
        </div>
        <div id="headerSeparador">
            <h2>Macarro</h2>
        </div>
        <div id="bodyCarnet">
            <div id="izquierdaCarnet">
                <asp:Label ID="_nombreD" CssClass="Identificadores" runat="server" Text="Label">Nombre :</asp:Label>
                <asp:Label ID="_apellidoD" CssClass="Identificadores" runat="server" Text="Label">Apellido :</asp:Label>
                <asp:Label ID="_fechaNacimientoD" CssClass="Identificadores" runat="server" Text="Label">F. Nacimiento :</asp:Label>
                <asp:Label ID="_fechaVencimientoD" CssClass="Identificadores" runat="server" Text="Label">F. Vencimiento :</asp:Label>
                <asp:Label ID="_tipoDocumentoIdentidad" CssClass="Identificadores" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroTelefonoD" CssClass="Identificadores" runat="server" Text="Label">Teléfono :</asp:Label>
            </div>
            <div id="centroCarnet">
                <asp:Label ID="_nombre" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_apellido" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_fechaNacimiento" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_fechaVencimiento" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroDocumentoIdentidad" CssClass="Data" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="_numeroTelefono" CssClass="Data" runat="server" Text="Label"></asp:Label>
                
            </div>
            <div id="derechaCarnet">
                <asp:Image ID="_foto" CssClass="foto Data" runat="server" />
                <asp:Label ID="_numeroCarnet" CssClass="Data numeroCarnet" runat="server" Text="Label"></asp:Label>
                <asp:UpdatePanel ID="PanelCancelarUpload" runat="server">
                    <ContentTemplate>
                        <label class="cabinet" title="Cambiar Foto">
                            <asp:FileUpload CssClass="file" ID="FileUpload1" runat="server"  />    
                        </label>
                    </ContentTemplate>
                    <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="CancelarUpload" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                
                <asp:Button ID="CancelarUpload" CausesValidation="false" runat="server" CssClass="Boton Boton2 BotonCancelUp" Visible="true" Text="Cancelar" OnClick="CancelarUpload_Click"/>
                    
<%--             
       <asp:Button ID="_cambiarFoto"  CssClass="Boton Boton2" runat="server" Text="Cambiar foto" OnClick="_cambiarFoto_Click" />
                <asp:TextBox ID="_pathImagen" Enabled="false" CssClass="textbox textbox2" runat="server"></asp:TextBox>--%>
            </div>
        </div>
         <asp:UpdatePanel ID="RegularExpCancel" runat="server">
                    <ContentTemplate>
                        <asp:RegularExpressionValidator ID="ValidadorImagen" CssClass="avisoMensajeBot MensajeError" runat="server" ErrorMessage="Solo se permiten imagenes con formato : Gif, Jpg , Jpeg o Png! , debe cancelar la carga o cargar una imagen valida para continuar" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.gif|.GIF|.jpg|.JPG|.jpeg|.JPEG|.png|.PNG)$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>
                    </ContentTemplate>
                    <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="CancelarUpload" EventName="Click" />
                    </Triggers>
        </asp:UpdatePanel>
     </asp:Panel>
    <h3 id="infoPago">Informacion de Pago</h3>
    <div id="InfoPago">
        <div id="Grid">
                <asp:MultiView ID="MvListaPagos" runat="server" ActiveViewIndex="0">
                <!-- Gridview con Ajax -->
                <asp:View ID="ViewPagos" runat="server">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            <asp:GridView ID="_gridTarjetasUsadas" runat="server"  CssClass="mGrid" BorderStyle="None"  AllowSorting="true"
                                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True"  PageSize="7"
                                            DataKeyNames="ID"                                            
                                            OnPageIndexChanging="_gridTarjetasUsadas_PageIndexChanging"
                                            ShowHeaderWhenEmpty="true">
                                <AlternatingRowStyle CssClass="alt" />

                                <Columns>
                                    <asp:BoundField HeaderText="Tipo tarjeta" DataField="tipoTarjetaGet" ItemStyle-Width="105px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Ultimos 4 digitos de tarjeta" DataField="numero" ItemStyle-Width="95px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Nombre impreso" DataField="NombreEnTarjeta" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                                    <asp:BoundField HeaderText="Fecha Vencimiento" DataField="FechaVencimiento" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>  

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:RadioButton ID="_tarjetaElegidaEnGrid" runat="server" 
                                                GroupName="Seleccion" OnCheckedChanged="_tarjetaElegidaEnGrid_CheckedChanged" AutoPostBack="true"/>
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            Seleccione
                                        </HeaderTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataTemplate> 
                                    <center>No se encontraron resultados</center> 
                                </EmptyDataTemplate>
                                <PagerSettings Mode="Numeric" Position="Bottom"  PageButtonCount="5"/>
                                <pagerstyle CssClass="pgr"  />
                            </asp:GridView>
                        </ContentTemplate>
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
            <div id="AgregarMas">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="_agregarTarjeta" runat="server" CssClass="BotonAgregarMas" Text="Usar otra tarjeta" OnClick="_agregarTarjeta_Click" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="_agregarTarjeta" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Panel ID="formularios" visible="false" runat="server">        
                    <div id="izquierdaDPago2">
                        <asp:Label ID="_numeroTarjetaD" CssClass="Identificadores3" runat="server" Text="Numero de tarjeta :"></asp:Label>
                        <asp:Label ID="_nombreImpresoEnTarjetaD" CssClass="Identificadores3" Text="Nombre impreso en tarjeta :" runat="server"></asp:Label>
                        <asp:Label ID="_cvvD" CssClass="Identificadores3" Text="Cvv :" runat="server"></asp:Label>
                        <asp:Label ID="FVencimiento" CssClass="Identificadores3" Text="Fecha de Vencimiento :" runat="server"></asp:Label>
                    </div>
                    <div id="derechaDPago2">
                        <asp:TextBox ID="_numeroTarjeta" CssClass="textbox" runat="server"></asp:TextBox>
                        <asp:TextBox ID="_nombreImpresoEnTarjeta" CssClass="textbox" runat="server"></asp:TextBox>
                        <asp:TextBox ID="_cvv" CssClass="textbox" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="_mesVencimiento" CssClass="combo_box combo2" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="_anoVencimiento" CssClass="combo_box combo2" runat="server"></asp:DropDownList>
                    </div>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="_agregarTarjeta" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </div>
        <h3 id="Tot">Total</h3>
        <div id="totalmonto">
            <asp:Label ID="_montoTotal" CssClass="Identificadores3" runat="server" Text="Bsf."></asp:Label>
        </div>
     </div>
    
    <div class="botones">
        <asp:Button ID="_aceptar" CssClass="Boton botonesDescargarPDF" runat="server" Text="Aceptar" OnClick="_aceptar_Click" />
        <asp:Button ID="_cancelar" CssClass="Boton botonVerPagos" runat="server" Text="Cancelar" OnClick="_cancelar_Click" />
    </div>
</asp:Content>
