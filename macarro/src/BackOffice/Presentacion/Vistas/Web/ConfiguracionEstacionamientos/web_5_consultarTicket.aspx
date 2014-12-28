<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_5_consultarTicket.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionEstacionamientos.web_5_ConsultarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
    <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
     <h2>Consultar ticket</h2>

    <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell  >
                <div class="centrado">
                    <asp:Label ID="labelBusqueda" runat="server" Text="Seleccione (*)" CssClass="labels"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell  >
                <asp:RadioButtonList ID="listaDeOpciones" runat="server" CssClass="radio_list" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="validar_entrada">
                    <asp:ListItem selected="true" Value="0">Consultar Todo</asp:ListItem>
                    <asp:ListItem Value="1">Consultar por Placa</asp:ListItem>
                    <asp:ListItem Value="2">Consultar por Fecha</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>
    <asp:Label ID="labelPrueba" runat="server"></asp:Label>
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        
        <%-- Placa --%>
        <asp:TableRow ID="porPlaca">
            <asp:TableCell>
                <asp:Label ID="labelPlaca" runat="server" Text="Placa (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textbox_placa" runat="server" CssClass="textbox" MaxLength="7"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="textbox_placa" 
                            Text="*"
                            ErrorMessage="El nombre no puede contener caracteres especiales." 
                            ForeColor="Red" 
                            ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                      </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        
        <%-- Por Fecha --%>
        <asp:TableRow ID="porFecha">
            <asp:TableCell>
                <asp:Label ID="labelFechaEntrada" runat="server" Text="Fecha de Entrada (*):" CssClass="labels" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="TextBoxFechaEntrada" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox>
                
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:Label ID="labelFechaSalida" runat="server" Text="Fecha de Salida (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="TextBoxFechaSalida" runat="server" CssClass="textbox" TextMode="Date"></asp:TextBox>
                <asp:CompareValidator id="cvtxtStartDate" runat="server" 
                   controltocompare="TextBoxFechaSalida" 
                   cultureinvariantvalues="true" 
                   display="Dynamic"
                   enableclientscript="true" 
                   controltovalidate="TextBoxFechaEntrada" 
                   errormessage="Fecha de entrada mayor a la fecha de salida" 
                   type="Date" 
                   setfocusonerror="true" 
                   operator="LessThanEqual" 
                   text="*"
                   ForeColor="Red">
                </asp:CompareValidator>
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
            AllowSorting="False" Width="650px" ShowFooter="False"  OnPageIndexChanging="GridView1_PageIndexChanging">
            
            <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="# Control" SortExpression="id"  ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa"  ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="horaEntrada" HeaderText="Fecha De Entrada" SortExpression="horaEntrada" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="horaSalida" HeaderText="Fecha De Salida" SortExpression="horaSalida" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField HeaderText="Acciones" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            </Columns>
            <PagerStyle CssClass="pgr" />
        </asp:GridView>

   </div>
    
    <br />
    
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:ValidationSummary ID="ValidationSummary2"
                    HeaderText=""
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    runat="server" 
                    CssClass="avisoMensajeBot MensajeError"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
   
</asp:Content>
