<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="web_12_reactivarMembresia.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.Membresia.web_12_reactivarMembresia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/Membresia/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
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
     <div id="Carnet" class="Carnet2">
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
                <asp:Button ID="_cambiarFoto" CssClass="Boton Boton2" runat="server" Text="Cambiar foto" OnClick="_cambiarFoto_Click" />
                <asp:TextBox ID="_pathImagen" Enabled="false" CssClass="textbox textbox2" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <h3>Informacion de Pago</h3>
    <div id="InfoPago">
        <asp:GridView CssClass="mGrid " ID="_gridTarjetasUsadas" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="5"
          HorizontalAlign="Center" BorderStyle="None"  AllowSorting="true" GridLines="None" Width="810px" ForeColor="#99CCFF"
         OnRowCommand= "_gridTarjetasUsadas_RowCommand" OnPageIndexChanging="_gridTarjetasUsadas_PageIndexChanging" OnSelectedIndexChanging="_gridTarjetasUsadas_SelectedIndexChanging" 
         OnRowDataBound="_gridTarjetasUsadas_RowDataBound" ShowHeaderWhenEmpty="true">  

            <AlternatingRowStyle CssClass="alt" />

            <Columns>    
                
                <asp:BoundField DataField="concepto" HeaderText="Tipo">  
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="fechaPago" HeaderText="Numero">  
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>
                              
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" ButtonType="Image"  SelectImageUrl="/comun/resources/img/View-128.png"  />
                   
             </Columns> 
    
            <PagerStyle CssClass="pgr" /> 
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
       
        </asp:GridView>
        <asp:CheckBox ID="_tarjetaElegidaEnGrid" Visible="false" runat="server"></asp:CheckBox>
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
