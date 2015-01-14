<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" 
    AutoEventWireup="true" CodeBehind="web_13_ReporteMembresias.aspx.cs" 
    Inherits="BackOffice.Presentacion.Vistas.Web.ReportesFinancierosExportacion.web_13_ReporteMembresias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloReportes/ReporteMembresia.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Reporte Membresías
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reportes
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="middle_place_holder" runat="server">
   <script type="text/javascript" src="https://www.google.com/jsapi"></script> 
     <h2 class ="" id ="subtitulo">Reporte Membresías</h2>
     <div>
            <asp:Table CssClass="" ID="Table1" runat="server" Height="122px" Width="1091px" HorizontalAlign ="Center">

                <asp:TableRow ID="TableRow1" runat="server">

                    <asp:TableCell ID="TableCell1" runat="server" width="12%">
                      <asp:Label CssClass="labels" ID="labelFechaInicio" runat="server" Text="Label">Fecha Inicio(*):</asp:Label>       
                    </asp:TableCell>

                    <asp:TableCell>
                       <asp:TextBox CssClass="textbox" ID="inputFechaInicio" TextMode="Date" runat="server" align="left" onkeypress="return false;"></asp:TextBox>
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
                        <asp:TextBox CssClass="textbox" ID="inputFechaFin" TextMode="Date" runat="server" align="left" onkeypress="return false;"></asp:TextBox>
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

                     <asp:Label ID="graficaVaciaMembresia" CssClass="labels" 
                          runat="server" Text="" Visible="false" Width="100%" align="center" verticalalign="center"></asp:Label>
 
                      <div id ="membresia" align="center"></div>
                    </asp:TableCell>
                    <asp:TableCell Width="5%"> </asp:TableCell>

                    <asp:TableCell Width="65%">
                     <asp:Label ID="dataTableVaciaMembresia" CssClass="labels" runat="server" Text="" Visible="false"
                        Width="100%" align="center" verticalalign="center"></asp:Label>

                       <asp:GridView CssClass="mGrid" ID="Membresia"  HorizontalAlign="Center" runat="server"
                        BorderStyle="None" GridLines="None" AutoGenerateColumns="False" AllowPaging="False" 
                        Width="100%" ForeColor="#99CCFF">
            
                                <Columns>    
                
                                <asp:BoundField DataField="ingreso" HeaderText="Ingresos">  
                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                                </asp:BoundField>


                                <asp:BoundField DataField="fecha" HeaderText="Fecha" >       
                                <ItemStyle Width="30%" HorizontalAlign="Center"/>
                                </asp:BoundField>
                                </Columns>  
                            </asp:GridView>
                    </asp:TableCell>

                </asp:TableRow>
             </asp:Table>
           <asp:TableRow Height="10px"></asp:TableRow>

       </div>

    <asp:Literal ID ="literal" runat ="server"></asp:Literal>

                    <asp:ValidationSummary 
                        ID="ResumenValidaciones" 
                        runat="server" 
                        DisplayMode ="BulletList" 
                        EnableClientScript="true"
                        ShowSumary = "true"
                        ForeColor="Red"
                    />

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
