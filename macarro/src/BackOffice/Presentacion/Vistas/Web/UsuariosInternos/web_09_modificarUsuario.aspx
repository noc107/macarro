﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_09_modificarUsuario.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.UsuariosInternos.web_09_modificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Usuarios Internos
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

   <h2>Modificar Usuario</h2>
    <br />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell ColumnSpan="6" HorizontalAlign="Center" >
                <asp:label ID="_mensajeExito" runat="server" CssClass="avisoMensaje MensajeExito" Visible="false">  Mensaje de Confirmacion </asp:label>
               <asp:label ID="_mensajeError" runat="server" CssClass="avisoMensaje MensajeError" Visible="false">  Mensaje de Confirmacion </asp:label>
                <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:label ID="LabelNombre" runat="server" CssClass="labels">   Nombre <span>(*)</span> : </asp:label>
            </asp:TableCell>

            <asp:TableCell>
                <asp:TextBox ID="TextBoxNombre" MaxLength="20" runat="server" CssClass="textbox" ></asp:TextBox>
            </asp:TableCell>
             <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                        runat="server" 
                        ControlToValidate="TextBoxNombre" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                       ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                    ControlToValidate="TextBoxNombre"
                    Text="*"
                    ErrorMessage="Se requiere el Nombre"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>              
             <asp:TableCell >
                <asp:label ID="LabelSegNom" runat="server" CssClass="labels" >  Segundo Nombre: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxSegNombre" MaxLength="20" runat="server" CssClass="textbox" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" 
                        ControlToValidate="TextBoxSegNombre" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                       ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </asp:TableCell> 
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell >
                <asp:label ID="LabelApellido" runat="server" CssClass="labels" OnClick="TextBoxApellido_Click">   Apellido<span>(*)</span>  : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxApellido" MaxLength="20" runat="server" CssClass="textbox" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                        runat="server" 
                        ControlToValidate="TextBoxApellido" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                       ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TextBoxApellido"
                    Text="*"
                    ErrorMessage="Se requiere el Apellido"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>  
            <asp:TableCell >
                <asp:label ID="LabelSegApellido" runat="server" CssClass="labels">  Segundo Apellido : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxSegApellido" MaxLength="20" runat="server" CssClass="textbox" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                        runat="server" 
                        ControlToValidate="TextBoxSegApellido" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                       ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
                
            </asp:TableCell>  
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:label ID="Label5" runat="server" CssClass="labels">  Tipo de Documento<span>(*)</span> : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListCedula" runat="Server" CssClass="combo_box" Enabled="false" ReadOnly="true">
                     <asp:ListItem value ="Cedula">Cedula</asp:ListItem>
                    <asp:ListItem value ="Pasaporte">Pasaporte</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11"  runat="server" 
                    ControlToValidate="DropDownListCedula"
                    ErrorMessage="Se requiere la ciudad" InitialValue="Seleccione"
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
            <asp:TableCell >
                <asp:label ID="LabelCedula" runat="server" CssClass="labels">   Cédula <span>(*)</span> : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxCedula" MaxLength="20" runat="server" CssClass="textbox"  ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
           <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                        runat="server" 
                        ControlToValidate="TextBoxCedula" ErrorMessage="Solo se admiten numeros"  Text="*" ForeColor="Red"
                       ValidationExpression="^[0-9]+$">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                    ControlToValidate="TextBoxCedula"
                    Text="*"
                    ErrorMessage="Se requiere la Cedula"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>  
            </asp:TableCell>   
            
        </asp:TableRow>
        <asp:TableRow>
             <asp:TableCell>
                <asp:label ID="LabelFechaNac" runat="server" CssClass="labels">   Fecha de Nacimiento <span>(*)</span>  : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox CssClass="textbox" ID="TextBoxFechaNac" runat="server"  TextMode="Date" width="250" height="38" ></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RangeValidator ID="validatorfechanac"
                        ControlToValidate="TextBoxFechaNac" runat="server" ErrorMessage="El empleado debe tener entre 18 y 65 años"
                        Type="Date" Text="*" ForeColor="Red">
                </asp:RangeValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server"
                    ControlToValidate="TextBoxFechaNac"
                    Text="*"
                    ErrorMessage="Se requiere la fecha de nacimiento"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell> 
            <asp:TableCell >
                <asp:label ID="LabelCorreo" runat="server" CssClass="labels">  E-mail <span>(*)</span> : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxCorreo" MaxLength="20" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                        runat="server" 
                        ControlToValidate="TextBoxCorreo" ErrorMessage="Enter your email"  Text="*" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                    ControlToValidate="TextBoxCorreo"
                    Text="*"
                    ErrorMessage="Se requiere el Correo"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
             </asp:TableCell>  
              </asp:TableRow>
          
        <asp:TableRow>
            <asp:TableCell>
                <asp:label ID="LabelContraseña" runat="server" CssClass="labels">   Contraseña: </asp:label>
            </asp:TableCell>

            <asp:TableCell>
                <asp:TextBox ID="TextBoxContraseña" MaxLength="8" runat="server" CssClass="textbox" TextMode="password"></asp:TextBox>
            </asp:TableCell>
             <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                        runat="server" 
                        ControlToValidate="TextBoxContraseña" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                      ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$">
                </asp:RegularExpressionValidator>
                
            </asp:TableCell>              
             <asp:TableCell >
                <asp:label ID="LabelVerifContraseña" runat="server" CssClass="labels"> Verificar Contraseña: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxVerifContraseña" MaxLength="8" runat="server" CssClass="textbox" TextMode="password"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" 
                        runat="server" 
                        ControlToValidate="TextBoxVerifContraseña" ErrorMessage="Solo se admiten caracteres alfabéticos"  Text="*" ForeColor="Red"
                       ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$">
                </asp:RegularExpressionValidator>
            </asp:TableCell> 
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell >
                <asp:label ID="labelEstatus" runat="server" CssClass="labels">  Estatus<span>(*)</span> : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="CBlistaEstatus" runat="Server" CssClass="combo_box" >
                    <asp:ListItem>Activado</asp:ListItem>
                    <asp:ListItem>Desactivado</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server"
                    ControlToValidate="CBlistaEstatus"
                    Text="*"
                    ErrorMessage="Se requiere el Estatus"
                    InitialValue="Seleccione un estatus"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell> 
            <asp:TableCell>
                <asp:Label ID ="labelTelefono" runat="server" CssClass="labels">Teléfono <span>(*)</span> : </asp:Label>
            </asp:TableCell> 
            <asp:TableCell>
                <asp:TextBox CssClass="textbox caja" ID="Telefono" runat="server"></asp:TextBox>
            </asp:TableCell>
               <asp:TableCell>
                <asp:regularexpressionvalidator CssClass="asterisco" ID="RegularExpressionValidator11" runat="server" 
                    ControlToValidate= "Telefono" 
                    ErrorMessage="Formato de teléfono no valido: (XX)-YYY-ZZZZZZZ"
                    Text="*" 
                    ForeColor= "Red"
                    ValidationExpression="\(\d{2}\)\-\d{3}\-\d{7}"> </asp:regularexpressionvalidator>
            <asp:RequiredFieldValidator CssClass="asterisco" ID="RequiredFieldValidator12" 
                    runat="server" ControlToValidate ="Telefono"
                    ErrorMessage="Telefono requerido." 
                    Text="*"
                    ForeColor="Red"> </asp:RequiredFieldValidator> 
                
            </asp:TableCell> 
        </asp:TableRow>

        <asp:TableRow >  
                <asp:TableCell >
                    <br />
                    <asp:label ID="LabelDireccion1" runat="server" CssClass="labels" Font-Bold="true">   Dirección <span>(*)</span>  : </asp:label>
                </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:label ID="Label1" runat="server" CssClass="labels">   País <span>(*)</span> : </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListPais" runat="Server" CssClass="combo_box" AutoPostBack="True" OnSelectedIndexChanged = "cbEstado_SelectionChangeCommitted"> 
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  runat="server" 
                    ControlToValidate="DropDownListPais"
                    ErrorMessage="Se requiere el País" InitialValue="Seleccione"
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
            <asp:TableCell >
                <asp:label ID="LabelDireccion" runat="server" CssClass="labels">   Dirección <span>(*)</span>  : </asp:label>
            </asp:TableCell>
            <asp:TableCell RowSpan="3">
                <asp:TextBox CssClass="textbox" height="150"  ID="TextBoxDireccion" Rows="5" runat="server" TextMode="multiline"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                    <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                    ControlToValidate="TextBoxDireccion"
                    Text="*"
                    ErrorMessage="Se requiere la Dirección"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                    ControlToValidate="TextBoxDireccion" 
                    Text="*"
                    ErrorMessage="La dirección no debe contener caracteres especiales)" 
                    ForeColor="Red" 
                    ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </asp:TableCell>  
            
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell >
                <asp:label ID="Label2" runat="server" CssClass="labels">  Estado<span>(*)</span>: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListEstado" runat="Server" CssClass="combo_box" AutoPostBack="True" OnSelectedIndexChanged = "cbCiudad_SelectionChangeCommitted">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  runat="server" 
                    ControlToValidate="DropDownListEstado"
                    ErrorMessage="Se requiere el Estado" InitialValue="Seleccione"
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
                <asp:TableRow>
            <asp:TableCell >
                <asp:label ID="Label4" runat="server" CssClass="labels">  Ciudad<span>(*)</span>: </asp:label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListCiudad" runat="Server" CssClass="combo_box"  DataTextField="Seleccione">
                    <asp:ListItem>Seleccione</asp:ListItem>
                     <asp:ListItem>Ciudad 1</asp:ListItem>
                    <asp:ListItem>Ciudad 2</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Left" Width="60px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10"  runat="server" 
                    ControlToValidate="DropDownListCiudad"
                    ErrorMessage="Se requiere la ciudad" InitialValue="Seleccione"
                    Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        
    
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center"  >
                <asp:ValidationSummary CssClass="avisoMensajeBot MensajeError" ID="ValidationSummary1"
                        HeaderText=""
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        runat="server" 
                        />
        </asp:TableCell>
       </asp:TableRow>
        </asp:Table>

    <asp:Table runat="server" HorizontalAlign="Center">
    <asp:TableRow>
           <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" >
               <br />
               <br />
               <asp:Button ID="buttonSiguiente" Class="Boton" runat="server" Text="Siguiente" OnClick="Siguiente"/>
           </asp:TableCell>
        <asp:TableCell Width="60">

        </asp:TableCell>
           <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" >
               <br />
               <br />
               <asp:Button ID="buttonCancelar" Class="Boton" runat="server" Text="Cancelar" OnClick="Regresar"  CausesValidation="false"/>
           </asp:TableCell> 
       </asp:TableRow>


    </asp:Table>

</asp:Content>
