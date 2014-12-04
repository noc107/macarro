<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_03_consultaServicio.aspx.cs" Inherits="back_office.Interfaz.web.ConfiguracionServiciosPlaya.web_03_consultaServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

<link href="../../../comun/resources/css/ModuloServiciosPlaya/ConsultaServicioTabla.css" rel="stylesheet" />
    <link href="../../../comun/resources/css/standards.css" rel="stylesheet" />


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

    <h2 class="centrado subtitulo">Servicios registrados</h2>
    
    <asp:GridView CssClass="grid_view TablaConsulta" ID="Servicios" runat="server" AutoGenerateColumns="False" AllowPaging="True"
         OnRowDataBound="Servicio_RowDataBound">  
            <Columns>    
                
                <asp:BoundField DataField="NombreServicio" HeaderText="Nombre Servicio">  
                <ItemStyle Width="200px" />
                </asp:BoundField>


                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" >       
                <ItemStyle Width="450px" />
                </asp:BoundField>
               
                <asp:BoundField >       
                <ItemStyle Width="150px" />
                </asp:BoundField>

                
        
            </Columns>  
        </asp:GridView>

    
</asp:Content>
