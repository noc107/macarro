<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"  UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_5_gestionarEstacionamiento.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos.web_5_gestionarEstacionamiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
        <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Gestionar Estacionamiento</h2>
    
    
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell  >
                <div class="centrado">
                    <asp:Label ID="labelBusqueda" runat="server" Text="Seleccione (*)" CssClass="labels"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  >
                <asp:RadioButtonList ID="listaDeOpciones" runat="server" CssClass="radio_list" RepeatDirection="Horizontal" OnSelectedIndexChanged="validar_entrada" AutoPostBack="true">
                    <asp:ListItem selected="true" Value="0">Consultar Todo</asp:ListItem>
                    <asp:ListItem Value="1" >Consultar por Nombre</asp:ListItem>
                    <asp:ListItem Value="2">Consultar por Estado</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow ID="anti_salto" Visible="false">
            <asp:TableCell>
                <asp:TextBox ID="tb_antisalto" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="fila_nombre">
            
            <asp:TableCell ID="celda_l_nombre">
                <asp:Label ID="labelNombre" runat="server" Text="Nombre :" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="celda_tb_nombre">
                <%-- text --%>
                <asp:TextBox ID="textBoxNombre" runat="server" CssClass="textbox" ></asp:TextBox>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="textBoxNombre" 
                            Text="*"
                            ErrorMessage="El nombre no puede contener caracteres especiales." 
                            ForeColor="Red" 
                            ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                      </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="fila_estado">
            <%-- FILTRO ESTADO --%>
            <asp:TableCell>
                <asp:Label ID="l_estado" runat="server" Text="Estado :" CssClass="labels"></asp:Label>
            </asp:TableCell>
            
                <%-- text --%>
                <asp:TableCell>
                            <asp:DropDownList CssClass="combo_box" ID="DropDown_estatus" runat="server">
                                <asp:ListItem>Seleccione</asp:ListItem>
                                <asp:ListItem>Activado</asp:ListItem>
                                <asp:ListItem>Desactivado</asp:ListItem>
                            </asp:DropDownList>
                   </asp:TableCell>
        </asp:TableRow>
    </asp:Table>   
   <br />
    <div>
        <div class="boton_centrado">
            <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Buscar" OnClick="BotonAgregarEstacionamiento_Click"/>
        </div>
    </div> 
    <div >
        <asp:GridView ID="My_GV" CssClass="mGrid centrado" runat="server"  AllowPaging="True"  GridLines="None"  
            OnRowDataBound="My_GV_RowDataBound" BorderStyle="None" AutoGenerateColumns="False" PageSize="7" 
            AllowSorting="False" Width="890px" ShowFooter="False" OnPageIndexChanging="GVAccion_PageIndexChanging" >
            
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="# Control" SortExpression="id"  ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="Nombre"  ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="capacidad" HeaderText="Capacidad" SortExpression="Capacidad" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="tarifa" HeaderText="Tarifa" SortExpression="Tarifa" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="Estado" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Acciones" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            </Columns>
            <PagerStyle CssClass="pgr" />
        </asp:GridView>

   </div>
    
    <br />
        <asp:Table ID="Table3" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ValidationSummary ID="ValidationSummary2"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server" 
                    ForeColor="Red"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


          

</asp:Content>

