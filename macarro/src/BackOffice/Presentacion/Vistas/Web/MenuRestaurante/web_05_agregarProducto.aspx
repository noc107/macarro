<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_agregarProducto.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.web_05_agregarProducto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>

<%--<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/NombreProducto.ascx" TagPrefix="uc1" TagName="NombreProducto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/PrecioProducto.ascx" TagPrefix="uc2" TagName="PrecioProducto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/DescripcionProducto.ascx" TagPrefix="uc3" TagName="DescripcionProducto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/mensajeDeError.ascx" TagPrefix="uc4" TagName="Mensaje" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
     <link href="../../../comun/resources/css/ModuloMenuRestaurante/Estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
     
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Menú Restaurante  
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

   

<div id="contenedor" class="Estilocontenedor;">
        <div class="Divporfila;">
            <div class="Estilodivlabels; Estilodivtextbox;">

                <h2>Agregar Plato al Menú</h2>

                <div>
                    <asp:Label ID="_mensajeExito" runat="server" Text="Plato añadido al menú" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
                    <asp:Label ID="_mensajeError" runat="server" Text="Plato no pudo ser añadido al menú" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
                </div>
                
                <asp:Table ID="tabla" runat="server" HorizontalAlign="Center">
                    <asp:TableRow ID="TableRow6" runat="server">
                        
                        <asp:TableCell ID="TableCell15" runat="server">
                            <asp:Label ID="Label4" runat="server" Text="Nombre (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>
                        
                        <asp:TableCell ID="TableCell16" runat="server">
                            <asp:TextBox ID="_nombreProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_requiredFieldValidator1" runat="server"
                                ControlToValidate="_nombreProducto"
                                Text="*"
                                ErrorMessage="Nombre requerido."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator1" runat="server"
                                ControlToValidate="_nombreProducto"
                                Text="*"
                                ErrorMessage="Nombre no debe contener numeros ni caracteres especiales."
                                ForeColor="Red"
                                ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)$"> 
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator6" runat="server"
                                ControlToValidate="_nombreProducto"
                                Text="*"
                                ErrorMessage="Nombre debe estar entre 3 a 100 caracteres."
                                ForeColor="Red"
                                ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.: ]){3,100}$"> 
                            </asp:RegularExpressionValidator>
                        </asp:TableCell>

                    </asp:TableRow>
                    <asp:TableRow ID="TableRow10" runat="server">
                        <asp:TableCell ID="TableCell17" runat="server">
                            <asp:Label ID="Label10" runat="server" Text="Descripcion (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell18" runat="server">
                            <asp:TextBox ID="_descripcionProducto" runat="server" CssClass="textbox inputTextbox inputTextarea" Height="30px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_requiredFieldValidator2" runat="server"
                                ControlToValidate="_descripcionProducto"
                                Text="*"
                                ErrorMessage="Descripción requerida."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidato2" runat="server"
                                ControlToValidate="_descripcionProducto"
                                Text="*"
                                ErrorMessage="Descripción solo puede incluir Letras, Numeros, Puntos, Dos Puntos y Comas"
                                ForeColor="Red"
                                ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.: ]+)$"> 
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator7" runat="server"
                                ControlToValidate="_descripcionProducto"
                                Text="*"
                                ErrorMessage="Descripción debe ser de entre 10 a 100 caracteres."
                                ForeColor="Red"
                                ValidationExpression="^([A-Za-zÑñáéíóúÁÉÍÓÚ0-9,.: ]){10,100}$"> 
                            </asp:RegularExpressionValidator>
                        </asp:TableCell>

                    </asp:TableRow>
                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell ID="TableCell1" runat="server">
                            <asp:Label ID="Label7" runat="server" Text="Precio (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell2" runat="server">
                            <asp:TextBox ID="_precioProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="_requiredFieldValidator3" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio requerido."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator3" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio debe ser numerico"
                                ForeColor="Red"
                                ValidationExpression="^\d+(.[0-9]*)*$">
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator4" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio debe ser mayor a cero"
                                ForeColor="Red"
                                ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="_regularExpressionValidator5" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio debe tener maximo dos decimales"
                                ForeColor="Red"
                                ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                            </asp:RegularExpressionValidator>
                        </asp:TableCell>

                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server">
                        <asp:TableCell ID="TableCell3" runat="server">
                            <asp:Label ID="Label8" runat="server" Text="Seccion (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell4" runat="server">
                            <asp:DropDownList ID="_seccion" CssClass="combo_box" runat="server">
                                <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="_requiredFieldValidator4"
                                runat="server" ControlToValidate="_seccion"
                                ErrorMessage="Seleccione el tipo de Sección"
                                Text="*"
                                ForeColor="Red"
                                InitialValue="0">
                            </asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

                <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText=""
                                CssClass="avisoMensaje MensajeError"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />

                <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="ButtonAgregar" CssClass="Boton" runat="server" Text="Agregar" OnClientClick="" OnClick="agregaPlato" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </div>
        </div>

    </div>   
 </asp:Content>