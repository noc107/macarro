<%@ Page Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_02_agregarProveedores.aspx.cs" 
    Inherits="back_office.Interfaz.web.Proveedores.web_02_agregarProveedores" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/agregarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Agregar Proveedores</h2>
    <asp:Label CssClass="avisomensaje" ID="Label13" runat="server"  Visible="False"></asp:Label>
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
            <asp:TextBox CssClass="textbox caja" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="TextBox1"
                    ErrorMessage="RIF requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="TextBox3"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="remail" 
                    runat="server" ControlToValidate="TextBox5" 
                    ErrorMessage="Formato de correo invalido."
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate ="TextBox5"
                    ErrorMessage="Correo requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox7" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="revEmail" runat="server"
	                ControlToValidate="TextBox7" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="([\w-]+\.)+[\w-]+[.com]+(/[/?%&=]*)">
            </asp:regularexpressionvalidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox9" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "TextBox9" 
                    ErrorMessage="Formato de teléfono no valido: (XX)-YYY-ZZZZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\(\d{2}\)\-\d{3}\-\d{7}">
            </asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate ="TextBox9"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>     
        </div>
        <div class="divDerecho">
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label2" runat="server" Text="País (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label4" runat="server" Text="Estado (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label8" runat="server" Text="Municipio (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label></div>
        </div>
        <div class="divCajas">
            <asp:TextBox CssClass="textbox caja" ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="TextBox2" 
                    Text="*"
                    ErrorMessage="Pais no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate ="TextBox2"
                    ErrorMessage="Pais requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox4" 
                    Text="*"
                    ErrorMessage="Estado no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate ="TextBox4"
                    ErrorMessage="Estado requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox6" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox6" 
                    Text="*"
                    ErrorMessage="Ciudad no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
             </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate ="TextBox6"
                    ErrorMessage="Ciudad requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox8" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator4" runat="server" 
                    ControlToValidate="TextBox8" 
                    Text="*"
                    ErrorMessage="Municipio no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate ="TextBox8"
                    ErrorMessage="Municipio requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="TextBox10" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="TextBox10" 
                    Text="*"
                    ErrorMessage="Dirección no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate ="TextBox10"
                    ErrorMessage="Dirección requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
         </div>
    </div>
    <div class="divAbajo">
        <asp:GridView class="grid_view tabla" ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Lista de Items Ofrecidos" />
                <asp:CheckBoxField />
            </Columns>
        </asp:GridView>
        <asp:ImageButton CssClass="mas_menos_info imagenMas" ID="ImageButton1" runat="server" ImageUrl="~/comun/resources/img/agregar.png" />
        <br />
        <br />
        <asp:ImageButton CssClass="mas_menos_info imagenMenos" ID="ImageButton2" runat="server" ImageUrl="~/comun/resources/img/menos.png" />

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
        <asp:Button CssClass="Boton margenBoton" ID="Button1" runat="server" Text="Aceptar"/>
        <asp:Button CssClass="Boton margenBoton" ID="Button2" runat="server" Text="Regresar" OnClick="Button2_Click"/>
    </div>
</asp:Content>








