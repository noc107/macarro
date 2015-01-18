﻿<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="web_02_agregarProveedores.aspx.cs" 
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
        
           <asp:Label CssClass="labels rif" ID="Label1" runat="server" Text="RIF (*):"></asp:Label>
           <asp:Label CssClass="labels razonsocial" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label>
           <asp:Label CssClass="labels correo" ID="Label5" runat="server" Text="Correo (*):"></asp:Label>
            <asp:Label CssClass="labels paginaweb" ID="Label7" runat="server" Text="Pagina Web:"></asp:Label>
           <asp:Label CssClass="labels telefono" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label>
            <asp:Label CssClass="labels contrato" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label>
        
        
            <asp:TextBox CssClass="textbox tbrif" ID="Rif" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="Rif"
                    ErrorMessage="RIF requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox tbrazonsocial" ID="RazonSocial" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="RazonSocial"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox tbcorreo" ID="Correo" runat="server"></asp:TextBox>
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
            <asp:TextBox CssClass="textbox tbpaginaweb" ID="PaginaWeb" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asterisco" ID="revEmail" runat="server"
	                ControlToValidate="PaginaWeb" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?"> </asp:regularexpressionvalidator>
            <asp:TextBox CssClass="textbox tbtelefono" ID="Telefono" runat="server"></asp:TextBox>
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
            <asp:TextBox CssClass="textbox tbcontrato" ID="FechaContrato" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate ="FechaContrato"
                    ErrorMessage="Fecha Contrato requerido." 
                    Text="*"
                    ForeColor="Red"></asp:RequiredFieldValidator>  
        
       
           <asp:Label CssClass="labels pais" ID="Label2" runat="server" Text="País (*):"></asp:Label>
            <asp:Label CssClass="labels estado" ID="Label4" runat="server" Text="Estado (*):"></asp:Label>
           <asp:Label CssClass="labels ciudad" ID="Label6" runat="server" Text="Ciudad (*):"></asp:Label>
            <asp:Label CssClass="labels direccion" ID="Label10" runat="server" Text="Dirección (*):"></asp:Label>
       
        
            <asp:DropDownList ID="_Pais" runat="server" OnSelectedIndexChanged="_Pais_SelectedIndexChanged" CssClass="combo_box tbpais"></asp:DropDownList>
          
            <br /> 
            <asp:DropDownList ID="_Estado" runat="server" OnSelectedIndexChanged="_Estado_SelectedIndexChanged" CssClass="combo_box tbestado"></asp:DropDownList>
         
            <br /> 
            <asp:DropDownList ID="_Ciudad" runat="server"  OnSelectedIndexChanged="_Ciudad_SelectedIndexChanged" CssClass="combo_box tbciudad"></asp:DropDownList>
          
            <br /> 
            <asp:TextBox CssClass="textbox tbdireccion" ID="Direccion" runat="server"></asp:TextBox>
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
             
       
    
 
    
        
    
    
        <asp:Button CssClass="Boton botonaceptar" ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click"/>
        <asp:Button CssClass="Boton botonregresar" ID="Regresar" runat="server" Text="Regresar" OnClick="Regresar_Click" CausesValidation="false"/>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>
</asp:Content>







