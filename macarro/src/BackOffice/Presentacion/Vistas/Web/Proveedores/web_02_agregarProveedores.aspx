<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="web_02_agregarProveedores.aspx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_agregarProveedores" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/agregarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Agregar Proveedores</h2>
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
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox caja" ID="RazonSocial" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="RazonSocial"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox caja" ID="Correo" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="remail" 
                    runat="server" ControlToValidate="Correo" 
                    ErrorMessage="Formato de correo invalido."
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate ="Correo"
                    ErrorMessage="Correo requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox caja" ID="PaginaWeb" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="revEmail" runat="server"
	                ControlToValidate="PaginaWeb" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?"> </asp:regularexpressionvalidator>
            <asp:TextBox CssClass="textbox caja" ID="Telefono" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "Telefono" 
                    ErrorMessage="Formato de teléfono no valido: (XX)-YYY-ZZZZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\(\d{2}\)\-\d{3}\-\d{7}"> </asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate ="Telefono"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator> 
            <asp:TextBox CssClass="textbox caja" ID="FechaContrato" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate ="FechaContrato"
                    ErrorMessage="Fecha Contrato requerido." 
                    Text="*"
                    ForeColor="Red"></asp:RequiredFieldValidator>  
        </div>
        <div class="divDerecho">
            <%--<div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label2" runat="server" Text="País (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label4" runat="server" Text="Estado (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label></div>
            <div class="divEtiqueta"><asp:Label CssClass="labels etiqueta" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label></div>
        </div>
        <div class="divCajas">
            <asp:DropDownList ID="_Pais" runat="server" OnSelectedIndexChanged="_Pais_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox CssClass="textbox caja" ID="Pais" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="Pais" 
                    Text="*"
                    ErrorMessage="Pais no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator5" 
                    runat="server" ControlToValidate ="Pais"
                    ErrorMessage="Pais requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:DropDownList ID="_Estado" runat="server" OnSelectedIndexChanged="_Pais_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox CssClass="textbox caja" ID="Estado" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Estado" 
                    Text="*"
                    ErrorMessage="Estado no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator6" 
                    runat="server" ControlToValidate ="Estado"
                    ErrorMessage="Estado requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="Ciudad" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="Ciudad" 
                    Text="*"
                    ErrorMessage="Ciudad no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator7" 
                    runat="server" ControlToValidate ="Ciudad"
                    ErrorMessage="Ciudad requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <br />
            <asp:TextBox CssClass="textbox caja" ID="Direccion" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="Direccion" 
                    Text="*"
                    ErrorMessage="Dirección no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate ="Direccion"
                    ErrorMessage="Dirección requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            --%>
         </div>
    </div>
    <div class="divAbajo">
        <%--<asp:GridView CssClass="grid_view tabla mGrid" ID="GridItems" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BorderStyle="None"
            AllowSorting="true" AllowPaging="True" GridLines="None" ForeColor="#99CCFF"  OnPageIndexChanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField HeaderText="ITE_id" DataField="ITE_id" ReadOnly="True" SortExpression="ITE_id" Visible="False" />
                <asp:BoundField DataField="ITE_nombre" HeaderText="Lista de Items Ofrecidos" />
                <asp:templatefield HeaderText="Selecionar">
                    <itemtemplate>
                        <asp:checkbox ID="aux" runat="server"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>
            </Columns>
        <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
        </asp:GridView>--%>

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
        <asp:Button CssClass="Boton margenBoton" ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click"/>
        <asp:Button CssClass="Boton margenBoton" ID="Regresar" runat="server" Text="Regresar" OnClick="Regresar_Click" CausesValidation="false"/>
    </div>
</asp:Content>








