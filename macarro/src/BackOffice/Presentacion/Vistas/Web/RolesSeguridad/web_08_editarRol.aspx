<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" 
    CodeBehind="web_08_editarRol.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.RolesSeguridad.web_08_editarRol" 
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

    <asp:Label ID="MensajeExitoso" runat="server"  Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="MensajeErrores" runat="server"  Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>


    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" Style="padding-bottom:20px">

        <%-- Fila para el nombre --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" >
                <br />
                <asp:Label ID="Label1" runat="server" Text="Nombre(*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <br />
                <asp:TextBox ID="tNombre" runat="server" CssClass="textbox" MaxLength="30"></asp:TextBox>
                 <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBNombre_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="tNombre"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir un nombre">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBNombre_Validator_Letras"
                    runat="server"
                    ControlToValidate ="tNombre"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Solo se permiten letras para el nombre"
                    ValidationExpression="^[a-zA-Z À-ÿ]*$">                        
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Fila para la descripcion --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label2" runat="server" Text="Descripcion(*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tDescripcion" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                
                 <%-- Validar que nombre no este vacio --%>
                <asp:RequiredFieldValidator ID="TBDescripcion_Validator_Vacio" 
                    runat="server" 
                    ControlToValidate ="tDescripcion"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Es obligatorio introducir una descripcion">  
                </asp:RequiredFieldValidator>

                <%-- Validar que nombre solo contenga letras --%>
                <asp:RegularExpressionValidator ID="TBDescripcion_Validator_Letras"
                    runat="server"
                    ControlToValidate ="tDescripcion"
                    Text="*"
                    ForeColor="Red" 
                    ErrorMessage="Solo se permiten letras, numeros o espacios para la descripcion"
                    ValidationExpression="^[A-Z0-9 a-zÀ-ÿ]*$">  
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
                <asp:ListBox ID="ListaAccionesAsignadas" runat="server" CssClass = "list_box list_box_propio">
                </asp:ListBox>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton1" runat="server" src="../../../comun/resources/img/menos.png" CssClass ="mas_menos_info" 
                OnClick="quitar_Click" CausesValidation="false"/>
            </asp:TableCell>                   
        </asp:TableRow>

        <%-- Fila para lista de acciones disponibles  --%>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="Label4" runat="server" Text="Acciones disponibles:" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="ListaAccionesDisponibles" runat="server" CssClass = "list_box list_box_propio">
                </asp:ListBox>
            </asp:TableCell>    
            <asp:TableCell>
                <asp:ImageButton ID="ImageButton2" runat="server" src="../../../comun/resources/img/agregar.png" CssClass ="mas_menos_info" 
                OnClick="agregar_Click" CausesValidation="false"/>
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
                <asp:Button ID="Aceptar" runat="server" Text="Aceptar" cssclass="Boton Botones" OnClick="aceptar_Click" 
                OnClientClick="return confirm('Esta acción modificará el ítem en el sistema ¿desea continuar?')"/>
            </asp:TableCell>

            <asp:TableCell HorizontalAlign="center">                      
                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" cssclass="Boton Botones" OnClick="cancelar_Click" CausesValidation="false"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <br />

    
</asp:Content>