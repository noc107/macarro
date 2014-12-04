<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master"
    AutoEventWireup="true" CodeBehind="web_07_gestionarReservas.aspx.cs"
     Inherits="back_office.Interfaz.web.ReservasSombrillasServiciosPlaya.web_07_gestionarReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ReservasSombrillasServiciosPlaya/estilos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Reservas
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2 class="centrado subtitulo">Lista de Espera por Confirmacion</h2>
    <asp:Label ID="MensajeExito" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>

    <div class="lab">

            <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        
        <asp:TableRow>
            <asp:TableCell>
                <asp:TextBox ID="textBoxBuscar" runat="server"
                        AutoPostBack="True" 
                        EnableTheming="False" 
                        CssClass="textbox"
                        MaxLength="20"
                        placeholder="Buscar Usuario" >
                </asp:TextBox>
                <asp:RegularExpressionValidator ID="validarTextBoxBuscar" 
                        runat="server" 
                        text="*"
                        ForeColor="Red"
                        ControlToValidate="textBoxBuscar" ErrorMessage="Solo se admiten caracteres alfabeticos" 
                        ValidationExpression="^([a-zA-Z]? ?)*$">
                </asp:RegularExpressionValidator>

            </asp:TableCell>

            <asp:TableCell>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combo_box_estatus">
                    <asp:ListItem>Estatus</asp:ListItem>
                    <asp:ListItem>Activo</asp:ListItem>
                    <asp:ListItem>Inactivo</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>

            <asp:TableCell>
                 <asp:ImageButton id="ImageButton1" 
                             runat="server"
                             ImageUrl="../../../comun/resources/img/icon-buscar.png" 
                             CssClass=" botonCualquiera btnSearch"/>
            </asp:TableCell>

        </asp:TableRow>
    </asp:Table>

                             <br /><br /> 

         <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0" Visible="true">
                <asp:View ID="GV_Usuario" runat="server">

                    <asp:GridView ID="GridViewUsuario" CssClass="mGrid" AllowPaging="True" HorizontalAlign ="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                             Width="510px" ForeColor="#99CCFF" PageSize="4" OnRowDataBound="GV_RowDataBound">
                     

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Cedula" DataField="Cedula"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Acciones" DataField="Acciones"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>

                </asp:View>
            </asp:MultiView>


       </div>

         
            
             <asp:ValidationSummary ID="ValidationSummary0"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
                ForeColor="Red"/>

</asp:Content>
