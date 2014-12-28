<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" CodeBehind="web_14_buscarMembresia.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia.web_14_buscarMembresia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMembresia/buscarMembresia.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresia
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
<h2>Buscar Membresia</h2>

    <div style="margin:0 auto;">
        <div>
            <asp:Label ID="MensajeExito" runat="server" Text="Membresia Encontrada." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
        </div>



       <%-- <div class="centrado">
             <asp:Label CssClass="labels" ID="Label4"  runat="server" Text="Seleccione el modo de busqueda" ></asp:Label>
        <br/><br/>
        </div>

        <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <ASP:RADIOBUTTONLIST CssClass="radio_list" ID="listaDeOpciones" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">Busqueda General</asp:ListItem>
                        <asp:ListItem Value="1">Numero de Carnet</asp:ListItem>
                        <asp:ListItem Value="2">Numero de Cedula</asp:ListItem>
                    </ASP:RADIOBUTTONLIST>
                </asp:TableCell>
           </asp:TableRow>
        </asp:Table>
        <div class="centrado">
            <asp:Textbox  CssClass="textbox" ID="busqueda" runat="server" MaxLength="8"></asp:Textbox>
            
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="busqueda"
                        Text="*"
                        ErrorMessage="La Cedula esta fuera del rango numerico."
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*$">
            </asp:RegularExpressionValidator>

        </div>
         <div>
            <asp:Table ID="tabla1" HorizontalAlign="Center" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary2"
                            runat="server"
                            DisplayMode="BulletList"
                            EnableClientScript="true"
                            ShowSumary="True"
                            HeaderText="" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div>
         
        
        <br />
        
        <div class="marginBotonCentrar">
            <asp:Button CssClass="Boton" ID="Btn" runat="server" Text="Buscar" OnClientClick="OpenChild()" OnClick="Btn_Click" ></asp:Button>
            <asp:Button CssClass="Boton" ID="Button1" runat="server" Text="Buscar" OnClick="BC"></asp:Button>
        </div>      
     
    </div>--%>
    </div>
     <div>
     <asp:GridView ID="TablaMembresia"  CssClass="mGrid" AllowPaging="true" HorizontalAlign="Center" runat="server" onrowcommand="Membresia_RowCommand"
                         BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"
                                              ForeColor="#99CCFF" PageSize="5" OnRowDataBound="Membresia_RowDataBound" OnSelectedIndexChanged="Membresia_SelectedIndexChanged" 
											  OnPageIndexChanging="Membresia_PageIndexChanged">
            <AlternatingRowStyle CssClass="alt" />  
            <Columns>    
                
                <asp:BoundField DataField="Codigo" HeaderText="Carnet">  
                <ItemStyle Width="80px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="Cedula" HeaderText="Cedula" >       
                <ItemStyle Width="80px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField DataField="ApellidoNombre" HeaderText="Apellido, Nombre" >       
                <ItemStyle Width="350px" HorizontalAlign="Center" />
                </asp:BoundField>


                <asp:BoundField HeaderText="Estado" DataField="Estado" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Acciones" DataField="Acciones" >       
                <ItemStyle Width="150px" HorizontalAlign="Center" />
                </asp:BoundField>

                

            </Columns>
            <PagerStyle CssClass="pgr" />
            <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />  
        </asp:GridView>

    </div>
    
</asp:Content>











       
    
    
        

