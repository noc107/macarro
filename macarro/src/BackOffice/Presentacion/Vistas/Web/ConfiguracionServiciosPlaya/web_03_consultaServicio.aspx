<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_03_consultaServicio.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya.web_03_consultaServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

 <link href="../../../comun/resources/css/standards.css" rel="stylesheet" />
 <link href="../../../comun/resources/css/ModuloServiciosPlaya/ConsultaServicioTabla.css" rel="stylesheet" />

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

    <asp:Label ID="LabelMensaje" runat="server"></asp:Label>
    
<%-- Diseño de Buscador tomado del grupo de "Usuarios Internos" --%>

    <asp:Table ID="tableBuscador" runat="server" HorizontalAlign="Center">    

        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="txtBuscar" runat="server"
                        AutoPostBack="True" 
                        EnableTheming="False" 
                        CssClass="textbox"
                        MaxLength="20"
                        placeholder="Buscar">
                </asp:TextBox>
                    <asp:RegularExpressionValidator ID="expresionRegularBuscar" runat="server" 
                        ControlToValidate="txtBuscar"
                        Text="*"
                        ErrorMessage="No se permiten caracteres especiales."
                        ValidationExpression="[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚ ,.]{1,20}"
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
            </asp:TableCell>

            <asp:TableCell>
                <asp:DropDownList ID="listEstado" runat="server" CssClass="combo_box_estatus">                    
                    <asp:ListItem Value = "1">Activo</asp:ListItem>
                    <asp:ListItem Value = "2">Inactivo</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>

            <asp:TableCell>
                 <asp:ImageButton ID="imgBuscar" 
                             runat="server"
                             ImageUrl="../../../comun/resources/img/icon-buscar.png" 
                             CssClass=" botonCualquiera btnSearch"
                             OnClick="imgBuscar_Click"/>
            </asp:TableCell>
        </asp:TableRow>      
    </asp:Table>

      <asp:Table ID="tableMensaje" runat="server" HorizontalAlign="Center">

        <asp:TableRow>

            <asp:TableCell>
                <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary2"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                />
            </asp:TableCell>

        </asp:TableRow>        
    </asp:Table>

<%-- Diseño de Buscador tomado del grupo de "Usuarios Internos" --%>

    <asp:GridView CssClass="mGrid " ID="Servicios" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="5"
          HorizontalAlign="Center" BorderStyle="None"  AllowSorting="true" GridLines="None" Width="810px" ForeColor="#99CCFF"
         OnRowCommand="Servicios_RowCommand" OnRowDeleting="Servicios_RowDeleting" OnRowEditing="Servicios_RowEditing" 
        OnPageIndexChanging="Servicios_PageIndexChanging" OnSelectedIndexChanging="Servicios_SelectedIndexChanging" 
         OnRowDataBound="Servicios_RowDataBound" ShowHeaderWhenEmpty="true">  

        <AlternatingRowStyle CssClass="alt" />

            <Columns>    
                
                <asp:BoundField DataField="NombreServicio" HeaderText="Nombre Servicio">  
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" >       
                <ItemStyle Width="450px" HorizontalAlign="Center" />
                </asp:BoundField>
                              
                <asp:CommandField ShowSelectButton="true" ButtonType="Image"  SelectImageUrl="~/comun/resources/img/ModuloServiciosPlaya/Ver.png"  />
                <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/comun/resources/img/ModuloServiciosPlaya/Editar.png"  />
                <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/comun/resources/img/ModuloServiciosPlaya/Eliminar.png"/>
            
                   
             </Columns> 
    
            <PagerStyle CssClass="pgr" /> 
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
       
         </asp:GridView>
 


</asp:Content>
