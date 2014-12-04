<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" 
    CodeBehind="web_08_editarRol.aspx.cs" Inherits="back_office.Interfaz.web.RolesSeguridad.web_08_editarRol" 
    UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Roles y Acciones
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/RolesSeguridad/Estilos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="middle_place_holder" runat="server">


    <h2>Modificar Rol</h2>

     <asp:Table ID="Table0" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">             
                <asp:Label CssClass="avisoMensaje" ID="LabelMensaje" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Label CssClass="avisoMensaje" ID="Label5" runat="server" Text="Label"></asp:Label>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" Style="padding-bottom:20px">

        <%-- Fila para el nombre --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" >
                <br />
                <asp:Label ID="Label1" runat="server" Text="Nombre(*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                 <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBNombre_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="TextBox1"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir un nombre">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBNombre_Validator_Letras"
                    runat="server"
                    ControlToValidate ="TextBox1"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Solo se permiten letras para el nombre"
                    ValidationExpression="^[a-zA-Z]*$">                        
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Fila para la descripcion --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label2" runat="server" Text="Descripcion(*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                
                 <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBDescripcion_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="TextBox2"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir una descripcion">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBDescripcion_Validator_Letras"
                    runat="server"
                    ControlToValidate ="TextBox2"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Solo se permiten letras, numeros o espacios para la descripcion"
                    ValidationExpression="^[A-Z0-9 a-z]*$">  
                </asp:RegularExpressionValidator>
            </asp:TableCell>
            <asp:TableCell>
                
            </asp:TableCell>
        </asp:TableRow>

        <%-- Fila para lista de acciones asignadas --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label3" runat="server" Text="Acciones Asignadas(*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="ListBox2" runat="server" CssClass = "list_box list_box_propio">
                    <asp:ListItem>Accion1</asp:ListItem>
                    <asp:ListItem>Accion2</asp:ListItem>
                    <asp:ListItem>Accion3</asp:ListItem>
                    <asp:ListItem>Accion4</asp:ListItem>
                    <asp:ListItem>Accion5</asp:ListItem>
                </asp:ListBox>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton1" runat="server" src="../../../comun/resources/img/menos.png" CssClass ="mas_menos_info"/>
            </asp:TableCell>                   
        </asp:TableRow>

        <%-- Fila para lista de acciones disponibles  --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label4" runat="server" Text="Acciones disponibles:" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="ListBox1" runat="server" CssClass = "list_box list_box_propio">
                    <asp:ListItem>Accion1</asp:ListItem>
                    <asp:ListItem>Accion2</asp:ListItem>
                    <asp:ListItem>Accion3</asp:ListItem>
                    <asp:ListItem>Accion4</asp:ListItem>
                    <asp:ListItem>Accion5</asp:ListItem>
                </asp:ListBox>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton2" runat="server" src="../../../comun/resources/img/agregar.png" CssClass ="mas_menos_info"/>
            </asp:TableCell>                       
        </asp:TableRow>
    </asp:Table>

        
    <%-- Mensajes de error --%>
    <asp:Table ID="TableMensajes" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ValidationSummary CssClass="avisoMensajeBot MensajeError" ID="ValidationSummary1"
                       HeaderText=""
                       DisplayMode="BulletList"
                       EnableClientScript="true"
                       runat="server" 
                        />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    
        <%-- Botones --%>
    <asp:Table ID="TableBotones" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">             
                <asp:Button ID="Aceptar" runat="server" Text="Aceptar" cssclass="Boton Botones" OnClick="Button1_Click" OnClientClick="return confirm('Esta acción modificará el ítem en el sistema ¿desea continuar?')"/>
            </asp:TableCell>

            <asp:TableCell HorizontalAlign="center">                      
                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" cssclass="Boton Botones" OnClick="Button2_Click" CausesValidation="false"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

    
</asp:Content>