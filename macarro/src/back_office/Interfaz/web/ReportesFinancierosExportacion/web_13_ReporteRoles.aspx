<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" 
    AutoEventWireup="true" CodeBehind="web_13_ReporteRoles.aspx.cs" 
    Inherits="back_office.Interfaz.web.ReportesFinancierosExportacion.web_13_ReporteRoles" %>




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
    <h2 class ="" id ="subtitulo">Reporte Roles</h2>
                        <div>
       
            <asp:Table CssClass="" ID="Table1" runat="server" Height="122px" Width="1091px" HorizontalAlign ="Center">

            
                <asp:TableRow ID="TableRow1" runat="server">

                    <asp:TableCell ID="TableCell1" runat="server" width="12%">
                      <asp:Label CssClass="labels" ID="labelFechaInicio" runat="server" Text="Label">Fecha Inicio(*):</asp:Label>       
                    </asp:TableCell>

                    <asp:TableCell>
                       <asp:TextBox CssClass="textbox" ID="inputFechaInicio" TextMode="Date" runat="server" align="left"></asp:TextBox>
                        <asp:RequiredFieldValidator 
                        id="CampoFechaInicioRequerido" runat="server"
                        ControlToValidate="inputFechaInicio"
                        Text="*"
                        ErrorMessage="Debes Introducir una Fecha de Inicio."
                        ForeColor="Red"
                        >
                        </asp:RequiredFieldValidator>
                    </asp:TableCell>


                     <asp:TableCell ID="TableCell3" runat="server" width="10%">
                        <asp:Label CssClass="labels" ID="labelFechaFin" runat="server" Text="Label">Fecha Fin(*):</asp:Label>  
                    </asp:TableCell>

                    <asp:TableCell>
                        <asp:TextBox CssClass="textbox" ID="inputFechaFin" TextMode="Date" runat="server" align="left"></asp:TextBox>
                        <asp:CompareValidator 
                        id="validarFechas" 
                        runat="server" 
                        ControlToCompare="inputFechaInicio" 
                        ControlToValidate="inputFechaFin"
                        Text="*"
                        ErrorMessage="La Fecha de Inicio debe ser Más Antigua que la Fecha de Fin" 
                        type="Date" 
                        setfocusonerror="true" 
                        Operator="GreaterThanEqual" 
                        ForeColor="Red"                       
                        >
                        </asp:CompareValidator>
                        <asp:RequiredFieldValidator 
                        id="CampoFechaFinRequerido" runat="server"
                        Text="*"
                        ControlToValidate="inputFechaFin"
                        ErrorMessage="Debes Introudcir una Fecha de Fin."
                        ForeColor="Red"
                            >
                        </asp:RequiredFieldValidator>

                   
                    </asp:TableCell>

                </asp:TableRow>




            </asp:Table>

               <asp:Table CssClass="TablaConsulta" ID="Table2" runat="server" Height="100px" Width="400px" align="center">
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell CssClass="BotonTabla"  ID="TableCell16" runat="server" width="100%" align="center">
                             <asp:button ID="BuscarBoton" CssClass="Boton" text="Buscar" runat="server" align="center"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell width="100%">
                    <asp:ValidationSummary 
                        ID="ResumenValidaciones" 
                        runat="server" 
                        DisplayMode ="BulletList" 
                        EnableClientScript="true"
                        ShowSumary = "true"
                        ForeColor="Red"
                    />
                    </asp:TableCell>
                 </asp:TableRow>
            </asp:Table>


       </div>

</asp:Content>



<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>