<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_03_consultaServicioCompleta.aspx.cs" Inherits="back_office.Interfaz.web.ConfiguracionServiciosPlaya.web_03_consultaServicioCompleta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

    <link href="../../../comun/resources/css/ModuloServiciosPlaya/ConsultaServicioCompleta.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Servicios de playa
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">


        <div> 
            <asp:Table CssClass="TablaConsulta" ID="Table1" runat="server" Height="222px" Width="600px">
               
                 <asp:TableRow CssClass="separadorTabla" ID="TableRow7" runat="server"></asp:TableRow>
            
                <asp:TableRow ID="TableRow1" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell1" runat="server">
              
                        <asp:Label CssClass="labels" ID="labelNombreServicio" runat="server" Text="Label">Nombre del Servicio:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor"  ID="TableCell2" runat="server">
                
                        <asp:Label CssClass="labels" ID="NombreServcio" runat="server" Text="Label">Motos de Agua</asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow2" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell3" runat="server">

                        <asp:Label CssClass="labels" ID="labelDescripcion" runat="server" Text="Label">Descripción:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell4" runat="server">
               
                        <asp:Label CssClass="labels" ID="Descripcion" runat="server" TextMode="multiline">Increibles motos de agua para dar un agragable paseo por los alrrededores</asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow8" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell11" runat="server">

                        <asp:Label CssClass="labels" ID="label1" runat="server" Text="Label">Categoría:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell12" runat="server">
                    
                         <asp:Label CssClass="labels" ID="Categoria" runat="server" Text="Label">Acuático</asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow9" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell13" runat="server">

                        <asp:Label CssClass="labels" ID="label2" runat="server" Text="Label">Lugar de retiro:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell14" runat="server">
                    
                        <asp:Label CssClass="labels" ID="LugarRetiro" runat="server" Text="Label">Muelle</asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow3" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell5" runat="server">

                        <asp:Label CssClass="labels" ID="labelCantidad" runat="server" Text="Label">Cantidad:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell6" runat="server">
                    
                        <asp:Label CssClass="labels" ID="Cantidad" runat="server" Text="Label">10</asp:Label>

                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow ID="TableRow4" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell7" runat="server">

                        <asp:Label CssClass="labels" ID="labelCapacidad" runat="server" Text="Label">Capacidad:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell8" runat="server">
                    
                        <asp:Label CssClass="labels" ID="Capacidad" runat="server" Text="Label">2</asp:Label>

                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow5" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell9" runat="server">

                        <asp:Label CssClass="labels" ID="labelCosto" runat="server" Text="Label">Costo:</asp:Label>

                    </asp:TableCell>

                    <asp:TableCell CssClass="TablaValor" ID="TableCell10" runat="server">
                    
                       <asp:Label CssClass="labels" ID="Costo" runat="server" Text="Label">60 $</asp:Label>

                    </asp:TableCell>

                   </asp:TableRow>
                
                <asp:TableRow ID="TableRow26" runat="server">

                    <asp:TableCell CssClass="TablaNombre" ID="TableCell41" runat="server">

                        <asp:Label CssClass="labels" ID="label19" runat="server" Text="Label">Horario(s):</asp:Label>

                    </asp:TableCell><asp:TableCell CssClass="TablaValor"  ID="TableCell42" runat="server">
                    
                       <asp:Label CssClass="labels" ID="Label3" runat="server" Text="Label">8:00am a 13:00pm</asp:Label>

                     </asp:TableCell>

                </asp:TableRow>

               
            </asp:Table>

            <asp:Table CssClass="TablaConsulta" ID="Table2" runat="server" Height="100px" Width="400px">
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell CssClass="BotonTabla"  ID="TableCell16" runat="server">
                             <asp:button ID="VolverConsulta" CssClass="Boton" text="Volver" runat="server" OnClick="VolverConsulta_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>



</asp:Content>
