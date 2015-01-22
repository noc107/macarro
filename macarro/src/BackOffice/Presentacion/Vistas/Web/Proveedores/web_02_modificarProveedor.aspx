﻿<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_02_modificarProveedor.aspx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_modificarProveedor" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/agregarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Modificar Proveedor</h2>
    <asp:Label CssClass="avisoMensaje MensajeExito" ID="Mensaje" runat="server"  Visible="False"></asp:Label>
    
    <div class="divArriba">
        
            <asp:Label CssClass="labels rif" ID="Label1" runat="server" Text="RIF (*):"></asp:Label>
            <asp:Label CssClass="labels razonsocial" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label>
            <asp:Label CssClass="labels paginaweb" ID="Label7" runat="server" Text="Pagina Web:"></asp:Label>
            <asp:Label CssClass="labels telefono" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label>
            <asp:Label CssClass="labels contrato" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label>
        
      
            <asp:TextBox CssClass="textbox tbrif" MaxLength="20" ID="Rif" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="Rif"
                    ErrorMessage="RIF requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>
            
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator20" runat="server" 
                    ControlToValidate="Rif" 
                    Text="*"
                    ErrorMessage="Rif no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-z0-9\-\ ]+)$">
            </asp:RegularExpressionValidator>
            
    
            <asp:TextBox CssClass="textbox tbrazonsocial" MaxLength="40" ID="RazonS" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="RazonS"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>

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
           
            <asp:regularexpressionvalidator CssClass="asterisco" ID="revEmail" runat="server"
	                ControlToValidate="PaginaWeb" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?">
            </asp:regularexpressionvalidator>
            <asp:TextBox CssClass="textbox tbpaginaweb" MaxLength="99" ID="PaginaWeb" runat="server"></asp:TextBox>
            
            <asp:TextBox CssClass="textbox tbtelefono" MaxLength="13" ID="Telefono" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "Telefono" 
                    ErrorMessage="Formato de teléfono no valido: XXXX-YYY-ZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\d{4}\-\d{3}\-\d{4}">
            </asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate ="Telefono"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>  


            <asp:TextBox CssClass="textbox tbcontrato" ID="FechaContrato" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate ="FechaContrato"
                    ErrorMessage="Fecha Contrato requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>    

            <asp:TextBox CssClass="textbox tbcorreo" MaxLength="99" ID="Correo" runat="server"></asp:TextBox>
            <asp:Label CssClass="labels correo" ID="Label5" runat="server" Text="Correo (*):"></asp:Label>

            <asp:Label CssClass="labels pais" ID="Label2" runat="server" Text="País (*):"></asp:Label>
            <asp:Label CssClass="labels estado" ID="Label4" runat="server" Text="Estado (*):"></asp:Label>
            <asp:Label CssClass="labels ciudad" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label>
            <asp:Label CssClass="labels direccion" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label>

            <asp:DropDownList CssClass="combo_box tbpais" ID="Pais" runat="server"></asp:DropDownList>
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
            
            <asp:DropDownList CssClass="combo_box tbestado" ID="Estado" runat="server"></asp:DropDownList>
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
            
            <asp:DropDownList CssClass="combo_box tbciudad" ID="Ciudad" runat="server"></asp:DropDownList>
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
            
           
            <asp:TextBox CssClass="textbox tbdireccion" height="150" MaxLength="99" ID="Direccion" runat="server" TextMode="multiline" Rows="5"> </asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asterisco" ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="Direccion" 
                    Text="*"
                    ErrorMessage="Dirección no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.:\-\ ]+)$">
            </asp:RegularExpressionValidator>



            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate ="Direccion"
                    ErrorMessage="Dirección requerido." 
                    Text="*"
                    ForeColor="Red">
            </asp:RequiredFieldValidator>

        
        <asp:Label CssClass="labels status" ID="Label8" runat="server" Text="Status (*):"></asp:Label>

        <asp:Button CssClass="Boton botonaceptar" ID="Button1" runat="server" Text="Aceptar"  
             OnClientClick="if(Page_ClientValidate()) return confirm('Esta acción modificará el item en el sistema ¿Desea continuar?'); else return false;" OnClick="Button1_Click"/>
        <asp:Button CssClass="Boton botonregresar" ID="Button2" runat="server" Text="Regresar" OnClick="Regresar_Click" CausesValidation="false"/>

        
        <asp:DropDownList CssClass="combo_box tbstatus" ID="Status" runat="server"></asp:DropDownList>

    </div>
     <asp:Table ID="TableMensajes" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                 <asp:ValidationSummary ID="ValidationSummary1"
                 CssClass="avisoMensajeBot MensajeError"
                 HeaderText=""
                 DisplayMode="BulletList"
                 EnableClientScript="true"
                 runat="server"/>
           </asp:TableCell>
        </asp:TableRow>
    </asp:Table>   

</asp:Content>
