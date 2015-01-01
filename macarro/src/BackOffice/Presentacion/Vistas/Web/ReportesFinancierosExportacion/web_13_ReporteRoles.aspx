﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"
    AutoEventWireup="true" CodeBehind="web_13_ReporteRoles.aspx.cs"
    Inherits="BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion.web_13_ReporteRoles" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloReportes/ReporteRoles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Reporte Roles
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reportes
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="middle_place_holder" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <h2 class="" id="subtitulo">Reporte Roles</h2>
    <div>
        <asp:Table CssClass="TablaConsulta" ID="Table2" runat="server" Height="100px" Width="400px" align="center">
            <asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell CssClass="BotonTabla" ID="TableCell16" runat="server" Width="100%" align="center">
                    <asp:Button ID="BuscarBoton" CssClass="Boton" Text="Buscar" runat="server" align="center" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <asp:Table CssClass="TablaConsulta" ID="Table4" runat="server" Height="100px" Width="1090px" align="center">
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell2" runat="server" Width="100%" align="right">
                    <asp:Button ID="ExportarBoton" CssClass="Boton" Text="Exportar a Excel" width="200px" runat="server" align="right" Visible ="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="100%">
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>

        <asp:Label ID="_mensajeExito" runat="server" Text="" Visible="false" CssClass="avisoMensaje"></asp:Label>
        <asp:Label ID="_mensajeError" runat="server" Text="" Visible="false" CssClass="avisoMensaje MensajeError"></asp:Label>

        <asp:Table CssClass="TablaConsulta" ID="Table3" runat="server" Height="100px" Width="1200px" align="center">

            <asp:TableRow>

                <asp:TableCell Width="30%">
                      <div id ="roles" align="center"></div>
                      <asp:Label ID="graficaVaciaRoles" CssClass="labels" 
                          runat="server" Text="" Visible="false" Width="100%" align="center" verticalalign="center"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="5%"> </asp:TableCell>

                <asp:TableCell Width="65%">
                     <asp:Label ID="dataTableVaciaRoles" CssClass="labels" runat="server" Text="" Visible="false" 
                         Width="100%" align="center" verticalalign="center"></asp:Label>


                     <asp:GridView CssClass="mGrid" ID="Roles" HorizontalAlign="Center" runat="server"
                        BorderStyle="None" GridLines="None" AutoGenerateColumns="False" AllowPaging="False" 
                        Width="100%" ForeColor="#99CCFF">

                        <Columns>

                            <asp:BoundField DataField="rol" HeaderText="Rol">
                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                                <ItemStyle Width="30%" HorizontalAlign="Center" />
                            </asp:BoundField>

                        </Columns>
                    </asp:GridView>
                </asp:TableCell>

            </asp:TableRow>
        <asp:TableRow Height="10px"></asp:TableRow>
        </asp:Table>

    </div>

    <asp:Literal ID="literal" runat="server"></asp:Literal>

                    <asp:ValidationSummary
                        ID="ResumenValidaciones"
                        runat="server"
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        ShowSumary="true"
                        ForeColor="Red" />

</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>