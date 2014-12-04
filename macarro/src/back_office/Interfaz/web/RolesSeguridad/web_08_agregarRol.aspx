<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" 
    CodeBehind="web_08_agregarRol.aspx.cs" Inherits="back_office.Interfaz.web.RolesSeguridad.Agregar_Rol" 
    UnobtrusiveValidationMode="None" %>

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


<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

    <h2>Agregar Rol</h2>
    

    <asp:Table ID="Table0" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">             
                <asp:Label CssClass="avisoMensaje" ID="LabelMensaje" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">


        <%-- Fila para el nombre --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Nombre" runat="server" Text="Nombre del rol(*):" cssclass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxNombre" runat="server" cssclass="textbox" MaxLength="30"></asp:TextBox>

                <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBNombre_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="TextBoxNombre"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir un nombre">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBNombre_Validator_Letras"
                    runat="server"
                    ControlToValidate ="TextBoxNombre"
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
                <asp:Label ID="Descripcion" runat="server" Text="Descripcion del rol(*):" cssclass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDescripcion" runat="server" cssclass="textbox" MaxLength="100"></asp:TextBox>

                 <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBDescripcion_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="TextBoxDescripcion"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir una descripcion">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBDescripcion_Validator_Letras"
                    runat="server"
                    ControlToValidate ="TextBoxDescripcion"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Solo se permiten letras, numeros o espacios para la descripcion"
                    ValidationExpression="^[A-Z0-9 a-z]*$">  
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>


        <%-- Fila para lista de acciones disponibles  --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" >
                <asp:Label ID="AccionesDisponibles" runat="server" Text="Acciones disponibles:" cssclass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
               <asp:ListBox ID="ListaAccionesDisponibles" runat="server" CssClass="list_box list_box_propio">
                   <asp:ListItem>Accion 1</asp:ListItem>
                   <asp:ListItem>Accion 2</asp:ListItem>
                   <asp:ListItem>Accion 3</asp:ListItem>
                   <asp:ListItem>Accion 4</asp:ListItem>
                   <asp:ListItem>Accion 5</asp:ListItem>
                   <asp:ListItem>Accion 6</asp:ListItem>
                   <asp:ListItem>Accion 7</asp:ListItem>
                   <asp:ListItem>Accion 8</asp:ListItem>
                   <asp:ListItem>Accion 9</asp:ListItem>
               </asp:ListBox>
            </asp:TableCell>
            <asp:TableCell>
               <asp:ImageButton ID="ButtonAgregarAccion" runat="server" cssclass="mas_menos_info" 
                   ImageUrl="../../../comun/resources/img/Agregar.png"/>
            </asp:TableCell>
        </asp:TableRow>


        <%-- Fila para lista de acciones asignadas --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" VerticalAlign="NotSet">
                <asp:Label ID="AccionesAsignadas" runat="server" Text="Acciones asignadas:" cssclass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="ListaAccionesAsignadas" runat="server" CssClass="list_box list_box_propio">
                   <asp:ListItem>Accion 2</asp:ListItem>
                   <asp:ListItem>Accion 4</asp:ListItem>
                   <asp:ListItem>Accion 7</asp:ListItem>
                </asp:ListBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ImageButton ID="ButtonQuitarAccion" runat="server" cssclass="mas_menos_info" 
                    ImageUrl="../../../comun/resources/img/menos.png"/>
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
                <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" cssclass="Boton Botones" OnClick="Aceptar_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

</asp:Content>

