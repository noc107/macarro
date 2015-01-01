<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_07_gestionarVenta.aspx.cs" Inherits="back_office.Interfaz.web.VentaCierreCaja.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/VentaCierreCaja/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Cierre de Caja
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Ventas</h2>


    <asp:Label ID="_mensajeExito" runat="server" CssClass="avisoMensaje MensajeError" Visible="false"></asp:Label>
    <asp:Label ID="_mensajeError" runat="server" CssClass="avisoMensaje MensajeError" Visible="false"></asp:Label>
  
    <%--Buscador --%>
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
                    <asp:ListItem Value = "1">Facturada</asp:ListItem>
                    <asp:ListItem Value = "2">Sin Facturar</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>

            <asp:TableCell>
                 <asp:ImageButton ID="imgBuscar" 
                             runat="server"
                             ImageUrl="~/comun/resources/img/icon-buscar.png" 
                             CssClass=" botonCualquiera btnSearch"/>
                             <%-- OnClick="imgBuscar_Click"--%>
                            
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
    
     <%--Fin Buscador --%>
    

    <%-- GridView --%>
      <div id="gestionVentas">
        <asp:GridView CssClass="mGrid gestionVentas" ID="Ventas" runat="server" AutoGenerateColumns="False" AllowPaging="True"
         OnRowDataBound="Ventas_RowDataBound" HorizontalAlign="Center" PageSize="8" BorderStyle="None"  AllowSorting="True"
         GridLines="None" ForeColor="#99CCFF" OnPageIndexChanging="Ventas_PageIndexChanging" ShowHeader="true" >
          
              <AlternatingRowStyle CssClass="alt" />  
            <Columns>    
                
                <asp:BoundField DataField="Codigo" HeaderText="Nro. Factura">  
                <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>

                 <asp:BoundField DataField="fkUsuario" HeaderText="Cliente" >       
                <ItemStyle Width="200px" HorizontalAlign="Center" />
                </asp:BoundField>
   
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" >       
                <ItemStyle Width="140px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Total" HeaderText="Total" >       
                <ItemStyle Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>
            
                <asp:BoundField HeaderText="Acciones"  >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>


            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />  
        </asp:GridView>

    </div>
    <%--Fin GridView --%>

</asp:Content>
