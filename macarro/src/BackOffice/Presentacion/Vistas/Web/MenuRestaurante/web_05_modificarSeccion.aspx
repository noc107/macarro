<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_modificarSeccion.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.web_05_modificarSeccion" %>
<%--<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>
--%>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMenuRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
      <script src="/comun/resources/js/ModuloMenuRestaurante/MenuRestaurante.js"></script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menu de restaurante
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
   
    <div  id="contenedor" class="Estilocontenedor;">
    <div class="Divporfila;">
        <div class="Estilodivlabels; Estilodivtextbox;">

            <h2>Modificar Seccion</h2>

            <div>
                <asp:Label ID="_mensajeExito" runat="server" Text="Sección Modificada Exitosamente" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
                <asp:Label ID="_mensajeError" runat="server" Text="Seccion no modificada" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
            </div>

            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell ID="TableCell15" runat="server">
                        <asp:Label ID="Label4" runat="server" Text="Nombre (*):" CssClass="labels"></asp:Label>
                    </asp:TableCell>

                    <asp:TableCell ID="TableCell16" runat="server">
                        <asp:TextBox ID="_nombreProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"
                            ControlToValidate="_nombreProducto"
                            Text="*"
                            ErrorMessage="Nombre requerido."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="_nombreProducto"
                            Text="*"
                            ErrorMessage="Nombre no debe contener numeros ni caracteres especiales."
                            ForeColor="Red"
                            ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)$"> 
                        </asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow10" runat="server">
                    <asp:TableCell ID="TableCell17" runat="server">
                        <asp:Label ID="Label10" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
                    </asp:TableCell>

                    <asp:TableCell ID="TableCell18" runat="server">
                        <asp:TextBox ID="_descripcionProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="_descripcionProducto"
                            Text="*"
                            ErrorMessage="Descripción requerida."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="_descripcionProducto"
                            Text="*"
                            ErrorMessage="Descripción solo puede incluir Letras, Numeros, Puntos, Dos Puntos y Comas"
                            ForeColor="Red"
                            ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.: ]+)$"> 
                        </asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell5" runat="server">
                        <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                            HeaderText=""
                            DisplayMode="BulletList"
                            EnableClientScript="true"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />

            <asp:Table ID="Table3" runat="server" HorizontalAlign="Center">
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server">
                        <asp:Button ID="ButtonModificar" CssClass="Boton" runat="server" Text="Modificar" OnClientClick="" OnClick="modificaSeccion" />
                        <asp:HiddenField runat="server" ID="campoOculto" Value="0" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div> 
    </div>
 </div>
</asp:Content>
