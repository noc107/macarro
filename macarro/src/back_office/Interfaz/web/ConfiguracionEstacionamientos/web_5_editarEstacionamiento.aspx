<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true"   CodeBehind="web_5_editarEstacionamiento.aspx.cs" Inherits="back_office.Interfaz.web.ConfiguracionEstacionamientos.web_5_editarEstacionamiento" %>
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
    <h2>Modificar Estacionamiento</h2>
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center"> 
             <asp:TableRow>
           <asp:TableCell  HorizontalAlign="Center" >
               <asp:label ID="LabelMensaje" runat="server" CssClass="labels">  Mensaje de Confirmacion </asp:label>
               <br />
                <br />
           </asp:TableCell>
       </asp:TableRow>     
            <asp:TableRow>
                   <asp:TableCell  >
                        <asp:label ID="label_nombre" runat="server" CssClass="labels">   Nombre <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_nombre" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                   <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                            ControlToValidate="tb_nombre"
                            Text="*"
                            ErrorMessage="Nombre Requerido."
                            ForeColor="Red">
                       </asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="tb_nombre" 
                            Text="*"
                            ErrorMessage="El nombre no puede contener caracteres especiales." 
                            ForeColor="Red" 
                            ValidationExpression="^([0-9a-zA-Z]? ?)*$">
                      </asp:RegularExpressionValidator>
                   </asp:TableCell>
               </asp:TableRow>

                <asp:TableRow>
                   <asp:TableCell  >
                        <asp:label ID="label_Capacidad" runat="server" CssClass="labels">   Capacidad <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_Capacidad" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                            ControlToValidate="tb_Capacidad"
                            Text="*"
                            ErrorMessage="Capacidad Requerida."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="tb_Capacidad" 
                            Text="*"
                            ErrorMessage="Capacidad debe ser un valor numerico." 
                            ForeColor="Red" 
                            ValidationExpression="^\d+(.[0-9]*)*$">
                        </asp:RegularExpressionValidator>
                       <asp:RangeValidator 
                           ID="RangeValidator1"
                           ControlToValidate="tb_Capacidad"
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

               <asp:TableRow>
                   <asp:TableCell  >
                        <asp:label ID="label_Tarifa" runat="server" CssClass="labels">   Tarifa <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_Tarifa" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server"
                            ControlToValidate="tb_Tarifa"
                            Text="*"
                            ErrorMessage="Tarifa requerida."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="tb_Tarifa" 
                            Text="*"
                            ErrorMessage="Tarifa debe ser un valor numerico" 
                            ForeColor="Red" 
                            ValidationExpression="^\d+(.[0-9]*)*$">
                        </asp:RegularExpressionValidator>
                       <asp:RangeValidator 
                           ID="range"
                           ControlToValidate="tb_tarifa"
                           MinimumValue="0"
                           MaximumValue="2147483647"
                           Type="Double"
                           ErrorMessage="Tarifa debe ser un entero mayor a cero."
                           Text="*"
                           ForeColor="Red"
                           runat="server"
                        />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="tb_Tarifa" 
                            Text="*"
                            ErrorMessage="Tarifa solo debe tener dos decimales" 
                            ForeColor="Red" 
                            ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                        </asp:RegularExpressionValidator>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  >
                        <asp:label ID="label_tarifaTicketPerdido" runat="server" CssClass="labels">   Tarifa de Ticket Perdido <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                        <asp:TextBox ID="tb_tarifaTicketPerdido" MaxLength="30" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server"
                            ControlToValidate="tb_tarifaTicketPerdido"
                            Text="*"
                            ErrorMessage="Tarifa de Ticket Perdido requerida."
                            ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="tb_tarifaTicketPerdido" 
                            Text="*"
                            ErrorMessage="Tarifa de Ticket Perdido debe ser un valor numerico" 
                            ForeColor="Red" 
                            ValidationExpression="^\d+(.[0-9]*)*$">
                        </asp:RegularExpressionValidator>
                       <asp:RangeValidator 
                           ID="RangeValidator2"
                           ControlToValidate="tb_tarifaTicketPerdido"
                           MinimumValue="0"
                           MaximumValue="2147483647"
                           Type="Double"
                           ErrorMessage="Tarifa de Ticket Perdido debe ser un entero mayor a cero."
                           Text="*"
                           ForeColor="Red"
                           runat="server"
                        />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                            ControlToValidate="tb_tarifaTicketPerdido" 
                            Text="*"
                            ErrorMessage="Tarifa de Ticket Perdido solo debe tener dos decimales" 
                            ForeColor="Red" 
                            ValidationExpression="^([1-9][0-9]*)(.[0-9]{1,2}){0,1}$">
                        </asp:RegularExpressionValidator>
                   </asp:TableCell>
               </asp:TableRow>

               <asp:TableRow>
                   <asp:TableCell  >
                        <asp:label ID="label_estatus" runat="server" CssClass="labels">   Estatus <span>(*)</span> : </asp:label>
                   </asp:TableCell>
                   <asp:TableCell>
                            <asp:DropDownList CssClass="combo_box" ID="DropDown_estatus" runat="server">
                                <asp:ListItem>Seleccione</asp:ListItem>
                                <asp:ListItem>Activo</asp:ListItem>
                                <asp:ListItem>Inactivo</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                runat="server" ControlToValidate ="DropDown_estatus"
                                ErrorMessage="Seleccione el estatus" 
                                Text="*"
                                ForeColor="Red"
                                InitialValue="Seleccione">
                            </asp:RequiredFieldValidator>
                   </asp:TableCell>

               </asp:TableRow>
         </asp:Table>
     <br />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center"> 
        <asp:TableRow>
            <asp:TableCell>
                <div class="boton_centrado">
                    <asp:Button ID="Button1" runat="server" CssClass="Boton" Text="Aceptar"/>
                </div>
            </asp:TableCell>
            <asp:TableCell>
                <div class="boton_centrado">
                    <asp:Button ID="Button3" runat="server" CssClass="Boton" Text="Cancelar"/>
                </div> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
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

</asp:Content>
