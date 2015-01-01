<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"
    UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_13_ReporteComidaBebida.aspx.cs"
    Inherits="BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion.web_13_ReporteComidaBebida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Reporte Comida y Bebida Más Popular
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reportes
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="middle_place_holder" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <h2 class="" id="subtitulo">Reporte Comida y Bebida Más Popular</h2>
    <div>

        <asp:Table CssClass="" ID="Table1" runat="server" Height="122px" Width="1091px" HorizontalAlign="Center">

            <asp:TableRow ID="TableRow1" runat="server">

                <asp:TableCell ID="TableCell1" runat="server" Width="12%">
                    <asp:Label CssClass="labels" ID="labelFechaInicio" runat="server" Text="Label">Fecha Inicio(*):</asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="inputFechaInicio" TextMode="Date" runat="server" align="left" onkeypress="return false;"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="CampoFechaInicioRequerido" runat="server"
                        ControlToValidate="inputFechaInicio"
                        Text="*"
                        ErrorMessage="Debes Introducir una Fecha de Inicio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </asp:TableCell>


                <asp:TableCell ID="TableCell3" runat="server" Width="10%">
                    <asp:Label CssClass="labels" ID="labelFechaFin" runat="server" Text="Label">Fecha Fin(*):</asp:Label>
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="inputFechaFin" TextMode="Date" runat="server" align="left" onkeypress="return false;"></asp:TextBox>
                    <asp:CompareValidator
                        ID="validarFechas"
                        runat="server"
                        ControlToCompare="inputFechaInicio"
                        ControlToValidate="inputFechaFin"
                        Text="*"
                        ErrorMessage="La Fecha de Inicio debe ser Más Antigua que la Fecha de Fin"
                        Type="Date"
                        SetFocusOnError="true"
                        Operator="GreaterThanEqual"
                        ForeColor="Red">
                    </asp:CompareValidator>
                    <asp:RequiredFieldValidator
                        ID="CampoFechaFinRequerido" runat="server"
                        Text="*"
                        ControlToValidate="inputFechaFin"
                        ErrorMessage="Debes Introudcir una Fecha de Fin."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>


                </asp:TableCell>

            </asp:TableRow>

        </asp:Table>

        <asp:Table CssClass="TablaConsulta" ID="Table2" runat="server" Height="100px" Width="800px" align="center">
            <asp:TableRow ID="TableRow6" runat="server">
                <asp:TableCell CssClass="BotonTabla" ID="TableCell16" runat="server" Width="100%" align="center">
                    <asp:Button ID="BuscarBoton" CssClass="Boton" Text="Buscar" runat="server" align="center" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="100%">
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

        <asp:Table  ID="Table3" runat="server" Height="100px"
            Width="1200px" align="center">

            <asp:TableRow>

                <asp:TableCell Width="30%">
                     <asp:Label ID="graficaVaciaComida" CssClass="labels" 
                          runat="server" Text="" Visible="false" Width="100%" align="center" verticalalign="center"></asp:Label>
                      <div id ="graficoplatos" align="center"></div>
                </asp:TableCell>
                <asp:TableCell Width="5%"> </asp:TableCell>

                <asp:TableCell Width="65%">

                     <asp:Label ID="dataTableVaciaComida" CssClass="labels" 
                          runat="server" Text="" Visible="false" Width="100%" align="center" verticalalign="center"></asp:Label>

                    <asp:GridView CssClass="mGrid" ID="ComidaPopular"  HorizontalAlign="Center" runat="server"
                        BorderStyle="None" GridLines="None" AutoGenerateColumns="False"
                        Width="100%" ForeColor="#99CCFF">


                        <Columns>

                            <asp:BoundField DataField="PLA_nombre" HeaderText="Nombre">
                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="ingresos" HeaderText="Ingresos">
                                <ItemStyle Width="30%" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:TableCell>

            </asp:TableRow>

            <asp:TableRow Height="10px"></asp:TableRow>

            <asp:TableRow>
                <asp:TableCell Width="30%">   
                     <asp:Label ID="graficaVaciaBebida" CssClass="labels" 
                          runat="server" Text="" Visible="false" Width="100%" align="center" verticalalign="center"></asp:Label>
                      <div id ="graficobebidas" align="center"></div>
                </asp:TableCell>

                <asp:TableCell Width="5%"> </asp:TableCell>

                <asp:TableCell Width="70%">
                    <asp:Label ID="dataTableVaciaBebida" CssClass="labels" runat="server" Text="" Visible="false"
                        Width="100%" align="center" verticalalign="center"></asp:Label>

                    <asp:GridView CssClass="mGrid" ID="BebidaPopular" HorizontalAlign="Center" runat="server"
                        BorderStyle="None" GridLines="None" AutoGenerateColumns="False"
                        Width="100%" ForeColor="#99CCFF">

                        <Columns>

                            <asp:BoundField DataField="PLA_nombre" HeaderText="Nombre">
                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:BoundField DataField="ingresos" HeaderText="Ingresos">
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

    <asp:Literal ID="literal2" runat="server"></asp:Literal>

    <asp:ValidationSummary
        ID="ResumenValidaciones"
        runat="server"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSumary="true" />



</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>






