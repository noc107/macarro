<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_11_ConsultarTicket.aspx.cs" Inherits="front_office.Interfaz.web.Estacionamiento.web_5_ConsultarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
            <link href="../../../comun/resources/css/Estacionamiento/estilo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Estacionamiento
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
                <asp:RadioButtonList ID="listaDeOpciones" runat="server" CssClass="radio_list" RepeatDirection="Horizontal">
                    <asp:ListItem selected="true" Value="0">Consultar Todo</asp:ListItem>
                    <asp:ListItem Value="1" >Consultar por Hora</asp:ListItem>
                    <asp:ListItem Value="2">Consultar por Fecha</asp:ListItem>
                    <asp:ListItem Value="3">Consultar por Placa</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        
        <%-- Por Hora --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="labelHoraEntrada" runat="server" Text="Hora de Entrada (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="datetimepicker" runat="server" CssClass="textbox" TextMode="DateTime"></asp:TextBox>
                
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:Label ID="labelHoraSalida" runat="server" Text="Hora de Salida (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="datetimepicker2" runat="server" CssClass="textbox" TextMode="DateTime" ClientIDMode="Inherit"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        
        <%-- Por Fecha --%>
        <asp:TableRow>
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

        
        <%-- Placa --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="labelPlaca" runat="server" Text="Placa (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textbox_placa" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
                        runat="server" 
                        ControlToValidate="textbox_placa" ErrorMessage="No se admiten caracteres especiales"  Text="*" ForeColor="Red"
                       ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <div>
        <div class="boton_centrado">
                <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Buscar"/>
            </div>
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
                    ForeColor="Red"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <div>
        <asp:GridView ID="consultarTicket" runat="server">
        </asp:GridView>
   </div>
</asp:Content>
