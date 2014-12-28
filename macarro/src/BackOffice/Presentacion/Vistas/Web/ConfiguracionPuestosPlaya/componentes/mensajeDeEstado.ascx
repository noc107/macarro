<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mensajeDeEstado.ascx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.componentes.mensajeDeError" %>
<div>
    <asp:Label ID="MensajeExito" runat="server" Text="Exito" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    <asp:Label ID="MensajeExcepcion" runat="server" Text="Error" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>
</div>