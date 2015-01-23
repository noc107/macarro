<%@ Page Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="web_02_agregarProveedores.aspx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.Proveedores.web_02_agregarProveedores" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content2" runat="server" contentplaceholderid="title_shown_place_holder">
    <link href="/comun/resources/css/ModuloProveedores/agregarProveedor.css" rel="stylesheet" />
    Proveedores
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="middle_place_holder">
    <h2 class="centrar subtitulo">Agregar Proveedores</h2>
    <asp:Label CssClass="avisoMensaje MensajeExito" ID="Mensaje" runat="server"  Visible="False"></asp:Label>
    <div class="divArriba">
        
           <asp:Label CssClass="labels rif" ID="Label1" runat="server" Text="RIF (*):"></asp:Label>
           <asp:Label CssClass="labels razonsocial" ID="Label3" runat="server" Text="Razón Social (*):"></asp:Label>
           <asp:Label CssClass="labels correo" ID="Label5" runat="server" Text="Correo (*):"></asp:Label>
            <asp:Label CssClass="labels paginaweb" ID="Label7" runat="server" Text="Pagina Web:"></asp:Label>
           <asp:Label CssClass="labels telefono" ID="Label9" runat="server" Text="Telefono (*):"></asp:Label>
            <asp:Label CssClass="labels contrato" ID="Label11" runat="server" Text="Fecha Contrato (*):"></asp:Label>
        
        
            <asp:TextBox CssClass="textbox tbrif" MaxLength="20" ID="Rif" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asteriscorif" ID="RequiredFieldValidator1" 
                    runat="server" ControlToValidate ="Rif"
                    ErrorMessage="RIF requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator CssClass="asteriscorif1" ID="RegularExpressionValidator20" runat="server" 
                    ControlToValidate="Rif" 
                    Text="*"
                    ErrorMessage="Rif no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-z0-9\-\ ]+)$">
            </asp:RegularExpressionValidator>
            
            <asp:TextBox CssClass="textbox tbrazonsocial" MaxLength="40" ID="RazonSocial" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asteriscorazonsocial" ID="RequiredFieldValidator2" 
                    runat="server" ControlToValidate ="RazonSocial"
                    ErrorMessage="Razon Social requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox tbcorreo" ID="Correo" MaxLength="99" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asteriscocorreo" ID="remail" 
                    runat="server" ControlToValidate="Correo" 
                    ErrorMessage="Formato de correo invalido."
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asteriscocorreo1" ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate ="Correo"
                    ErrorMessage="Correo requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>
            <asp:TextBox CssClass="textbox tbpaginaweb" MaxLength="99" ID="PaginaWeb" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asteriscopagina" ID="revEmail" runat="server"
	                ControlToValidate="PaginaWeb" 
                    ErrorMessage="Formato de pagina web no valido" 	
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?"> </asp:regularexpressionvalidator>
            <asp:TextBox CssClass="textbox tbtelefono" MaxLength="13" ID="Telefono" runat="server"></asp:TextBox>
            <asp:regularexpressionvalidator CssClass="asteriscotelefono" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "Telefono" 
                    ErrorMessage="Formato de teléfono no valido: XXXX-YYY-ZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\d{4}\-\d{3}\-\d{4}"></asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asteriscotelefono1" ID="RequiredFieldValidator4" 
                    runat="server" ControlToValidate ="Telefono"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator> 
            <asp:TextBox CssClass="textbox tbcontrato" ID="FechaContrato" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="asteriscocontrato" ID="RequiredFieldValidator8" 
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
            <asp:TextBox CssClass="textbox tbdireccion" height="150" MaxLength="99" ID="Direccion" runat="server" TextMode="multiline" Rows="5"></asp:TextBox>
            <asp:RegularExpressionValidator CssClass="asteriscodireccion" ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="Direccion" 
                    Text="*"
                    ErrorMessage="Dirección no debe contener caracteres especiales" 
                    ForeColor="Red" 
                    ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.:\-\ ]+)$"> </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator CssClass="asteriscodireccion1" ID="RequiredFieldValidator9" 
                    runat="server" ControlToValidate ="Direccion"
                    ErrorMessage="Dirección requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator>    
    
        <asp:Button CssClass="Boton botonaceptar" ID="Aceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click"/>
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








