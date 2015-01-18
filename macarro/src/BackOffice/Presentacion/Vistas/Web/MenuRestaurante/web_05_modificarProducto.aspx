﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_05_modificarProducto.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.MenuRestaurante.web_05_modificarProducto" %>
<%--<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/mensajeDeConfirmacion.ascx" TagPrefix="uc2" TagName="mensajeDeConfirmacion" %>

<%@ Register Src="~/Presentacion/Vistas/Web/MenuRestaurante/componentes/NombreProducto.ascx" TagPrefix="uc1" TagName="NombreProducto" %>
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

                <h2>Modificar Plato</h2>

                <div>
                    <asp:Label ID="_mensajeExito" runat="server" Text="Plato Modificado Exitosamente" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
                    <asp:Label ID="_mensajeError" runat="server" Text="Plato no modificado" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
                </div>

                <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                    <asp:TableRow ID="TableRow6" runat="server">
                        <asp:TableCell ID="TableCell15" runat="server">
                            <asp:Label ID="_nombrePlatoLabel" runat="server" Text="Nombre (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell16" runat="server">
                            <asp:TextBox ID="_nombreProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="_nombreProducto"
                                Text="*"
                                ErrorMessage="Nombre requerido."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server"
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

                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell ID="TableCell1" runat="server">
                            <asp:Label ID="Label7" runat="server" Text="Precio (*):" CssClass="labels"></asp:Label>
                        </asp:TableCell>

                        <asp:TableCell ID="TableCell2" runat="server">
                            <asp:TextBox ID="_precioProducto" runat="server" CssClass="textbox" Height="30px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio requerido."
                                ForeColor="Red">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio debe ser numerico"
                                ForeColor="Red"
                                ValidationExpression="^\d+(.[0-9]*)*$">
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                ControlToValidate="_precioProducto"
                                Text="*"
                                ErrorMessage="Precio debe ser mayor a cero"
                                ForeColor="Red"
                                ValidationExpression="^([1-9][0-9]*)(.[0-9]*){0,1}$">
                            </asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
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
                                <asp:ListItem Value="Seleccione..">Seleccione..</asp:ListItem>
                                <asp:ListItem Value="1">Entradas</asp:ListItem>
                                <asp:ListItem Value="2">Internacionales</asp:ListItem>
                                <asp:ListItem Value="3">Pescados</asp:ListItem>
                                <asp:ListItem Value="4">Bebidas</asp:ListItem>
                                <asp:ListItem Value="5">Postres</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                runat="server" ControlToValidate="_seccion"
                                ErrorMessage="Seleccione el tipo de Sección"
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione..." Display="Dynamic" Enabled="true">
                            </asp:RequiredFieldValidator>
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
                            <asp:Button ID="ButtonAgregar" CssClass="Boton" runat="server" Text="Modificar" OnClientClick="" OnClick="modificarPlato" />
                            <asp:HiddenField runat="server" ID="campoOculto" Value="0" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </div>
        </div>
 </div>
</asp:Content>