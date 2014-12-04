<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_configurarPlaya.aspx.cs" UnobtrusiveValidationMode="None"
    MasterPageFile="~/Interfaz/temp/back_office_temp.Master" 
    Inherits="back_office.Interfaz.web.ConfiguracionPuestosPlaya.web_2_configurarPlaya" %>

<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/textboxConfigurarPlaya.ascx" TagPrefix="uc1" TagName="textboxConfigurarPlaya" %>
<%@ Register Src="~/Interfaz/web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>



<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Configurar Playa
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Configurar playa</h2>
    <div>
        <uc1:mensajeDeEstado runat="server" ID="mensajeDeEstado" />
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UDP" runat="server"> 
            <ContentTemplate> 
                <asp:GridView ID="estadoActualDeLaPlaya" runat="server"  Width="530px" Height="96px" ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="10">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                </asp:GridView>
            </ContentTemplate> 
        </asp:UpdatePanel>
        <uc1:textboxConfigurarPlaya runat="server" ID="textboxConfigurarPlaya" />
        <div>
        <div class="btn_aceptar_posicion">
            <asp:Button ID="botonAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonAceptar_Click"/>
        </div>
    </div>
    </div>
</asp:Content>
