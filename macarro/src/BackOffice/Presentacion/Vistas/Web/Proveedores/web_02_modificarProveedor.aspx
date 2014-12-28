<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_02_modificarProveedor.aspx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_modificarProveedor" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/agregarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Modificar Proveedor</h2>
    <asp:Label CssClass="avisomensaje" ID="Mensaje" runat="server"  Visible="False"></asp:Label>
    <div class="divArriba">
        <div class="divIzquierdo">
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label1" runat="server" Text="RIF (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label5" runat="server" Text="Correo (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label7" runat="server" Text="Pagina Web:"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label></div>
        </div>
        <div class="divCajas">
            <asp:TextBox CssClass="textbox caja" ID="Rif" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="Rif"
                    ErrorMessage="RIF requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="RazonSocial" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="RazonSocial"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="Correo" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="remail" 
                    runat="server" ControlToValidate="Correo" 
                    ErrorMessage="Formato de correo invalido."
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate ="Correo"
                    ErrorMessage="Correo requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="PaginaWeb" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="revEmail" runat="server"
	                ControlToValidate="PaginaWeb" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?">
            </asp:regularexpressionvalidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="Telefono" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "Telefono" 
                    ErrorMessage="Formato de teléfono no valido: (XX)-YYY-ZZZZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\(\d{2}\)\-\d{3}\-\d{7}">
            </asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate ="Telefono"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>  
            <asp:TextBox CssClass="textbox caja" ID="FechaContrato" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate ="FechaContrato"
                    ErrorMessage="Fecha Contrato requerido." 
                    Text="*"
                    ForeColor="Red"></asp:RequiredFieldValidator>    
        </div>
        <div class="divDerecho">
           <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label2" runat="server" Text="País (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label4" runat="server" Text="Estado (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label8" runat="server" Text="Municipio (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label></div>
        </div>
        <div class="divCajas">
            <asp:DropDownList CssClass="textbox caja" ID="Pais" runat="server"></asp:DropDownList>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="Pais" 
                    Text="*"
                    ErrorMessage="Pais no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate ="Pais"
                    ErrorMessage="Pais requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList CssClass="textbox caja" ID="Estado" runat="server"></asp:DropDownList>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Estado" 
                    Text="*"
                    ErrorMessage="Estado no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate ="Estado"
                    ErrorMessage="Estado requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList CssClass="textbox caja" ID="Ciudad" runat="server"></asp:DropDownList>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="Ciudad" 
                    Text="*"
                    ErrorMessage="Ciudad no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
             </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate ="Ciudad"
                    ErrorMessage="Ciudad requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
           
            <asp:TextBox CssClass="textbox caja" ID="Direccion" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="Direccion" 
                    Text="*"
                    ErrorMessage="Dirección no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate ="Direccion"
                    ErrorMessage="Dirección requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
         </div>
    </div>
    <div class="divAbajo">
        <asp:GridView CssClass="grid_view tabla mGrid" ID="GridItems" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Lista de Items Ofrecidos" />
                <asp:CheckBoxField />
            </Columns>
        </asp:GridView>
        <asp:ImageButton CssClass="mas_menos_info imagenMas" ID="ImageButton1" runat="server" ImageUrl="~/comun/resources/img/agregar.png" OnClick="ImageButton1_Click" />
        <br />
        <br />
        <asp:ImageButton CssClass="mas_menos_info imagenMenos" ID="ImageButton2" runat="server" ImageUrl="~/comun/resources/img/menos.png" OnClick="ImageButton2_Click" />

   </div>
    <div class="divValidacion">
        <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>
    </div>
    <div class="divBoton">
        <asp:Button CssClass="Boton margenBoton" ID="Button1" runat="server" Text="Aceptar"  OnClientClick="return confirm('Esta acción modificará el ítem en el sistema ¿desea continuar?')"/>
        <asp:Button CssClass="Boton margenBoton" ID="Button2" runat="server" Text="Regresar" OnClick="Button2_Click" CausesValidation="false"/>
    </div>
</asp:Content>
