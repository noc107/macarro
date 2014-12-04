<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master"  UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_5_gestionarEstacionamiento.aspx.cs" Inherits="back_office.Interfaz.web.ConfiguracionEstacionamientos.web_5_gestionarEstacionamiento" %>
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
                <asp:RadioButtonList ID="listaDeOpciones" runat="server" CssClass="radio_list" RepeatDirection="Horizontal">
                    <asp:ListItem selected="true" Value="0">Consultar Todo</asp:ListItem>
                    <asp:ListItem Value="1" >Consultar por Nombre</asp:ListItem>
                    <asp:ListItem Value="2">Consultar por Capacidad</asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
    
    </asp:Table>
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="labelNombre" runat="server" Text="Nombre (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="textBoxNombre" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                            ControlToValidate="textBoxNombre"
                            Text="*"
                            ErrorMessage="Nombre Requerido."
                            ForeColor="Red">
                       </asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="textBoxNombre" 
                            Text="*"
                            ErrorMessage="El nombre no puede contener caracteres especiales." 
                            ForeColor="Red" 
                            ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                      </asp:RegularExpressionValidator>
            </asp:TableCell>
            
            <asp:TableCell>
                <asp:Label ID="labelCapacidad" runat="server" Text="Capacidad (*):" CssClass="labels"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%-- text --%>
                <asp:TextBox ID="textBoxCapacidad" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                            ControlToValidate="textBoxCapacidad"
                            Text="*"
                            ErrorMessage="Capacidad Requerida."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="textBoxCapacidad" 
                            Text="*"
                            ErrorMessage="Capacidad debe ser un valor numerico." 
                            ForeColor="Red" 
                            ValidationExpression="^\d+(.[0-9]*)*$">
                        </asp:RegularExpressionValidator>
                       <asp:RangeValidator 
                           ID="RangeValidator1"
                           ControlToValidate="textBoxCapacidad"
                           MinimumValue="0"
                           MaximumValue="2147483647"
                           Type="Integer"
                           ErrorMessage="Capacidad debe ser un entero mayor a cero."
                           Text="*"
                           ForeColor="Red"
                           runat="server"
                        />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>   
    <br />
    <div>
        <div class="boton_centrado">
                <asp:Button ID="BotonAgregarEstacionamiento" runat="server" CssClass="Boton" Text="Buscar"/>
            </div>
    </div> 
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
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:GridView ID="GridView1" runat="server">
                
                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Capacidad" DataField="Capacidad"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Estatus" DataField="Estatus"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                       <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
            </asp:GridView>
        </asp:View>
    </asp:MultiView>


          

</asp:Content>

