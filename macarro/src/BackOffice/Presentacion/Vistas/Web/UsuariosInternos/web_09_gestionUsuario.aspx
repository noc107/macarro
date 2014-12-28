<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="web_09_gestionUsuario.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.UsuariosInternos.web_09_gestionUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Usuarios Internos
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">

<h2>Lista de Usuarios</h2>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <asp:Label ID="mensajeExito" runat="server" CssClass="avisoMensaje MensajeExito" ></asp:Label>
                <asp:Label ID="mensajeError" runat="server" CssClass="avisoMensaje MensajeError" ></asp:Label>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center"> 
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

            </asp:TableRow >
            <asp:TableRow HorizontalAlign="Center" >
            <asp:TableCell>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="combo_box_estatus" width="250" height="38" visible="false">
                    <asp:ListItem>Estatus</asp:ListItem>
                    <asp:ListItem>Activo</asp:ListItem>
                    <asp:ListItem>Inactivo</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                 <asp:Button ID="ButtonBuscar" CssClass="Boton" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click"/>
            </asp:TableCell>

            </asp:TableRow>
    </asp:Table>


            

         <br/><br/>                     

              <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0">
                <asp:View ID="GV_Usuario" runat="server">

                    <asp:GridView ID="GridViewUsuario" CssClass="mGrid" AllowPaging="True" HorizontalAlign="Center" runat="server" 
                                            BorderStyle="None"  AllowSorting="true" GridLines="None" AutoGenerateColumns="False"
                                            Width="510px" ForeColor="#99CCFF" PageSize="8" OnRowDataBound="GV_RowDataBound" 
                                            OnPageIndexChanging="GridViewUsuario_PageIndexChanging"  >
       
                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                             
                            <asp:BoundField HeaderText="Nombre" DataField="Persona.PrimerNombre" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             
                            <asp:BoundField HeaderText="Apellido" DataField="Persona.PrimerApellido"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                            <asp:BoundField HeaderText="Acciones" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>
    

                </asp:View>
            </asp:MultiView>

            <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Center"  >
                <asp:ValidationSummary CssClass="avisoMensajeBot MensajeError" ID="ValidationSummary1"
                        HeaderText=""
                        DisplayMode="BulletList"
                        EnableClientScript="true"
                        runat="server" 
                        />
        </asp:TableCell>
       </asp:TableRow>
        </asp:Table>


</asp:Content>