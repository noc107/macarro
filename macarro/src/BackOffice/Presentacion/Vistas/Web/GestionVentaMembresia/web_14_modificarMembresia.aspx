<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master" UnobtrusiveValidationMode="None" CodeBehind="web_14_modificarMembresia.aspx.cs" Inherits="BackOffice.Presentacion.Vistas.Web.GestionVentaMembresia.web_14_modificarMembresia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/ModuloMembresia/modificarMembresia.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato, Daniel
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Membresia
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    
<h2>Modificar Membresia</h2>
    <div>
        <asp:Label ID="MensajeExito" runat="server" Text="Membresia Modificada" Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
    </div>
    <div style="margin:0 auto;">
        
        <asp:Table ID="tabla" runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="labels" ID="lbCodigo"  runat="server" Text="N Carnet:"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:Label  CssClass="textbox" ID="lbCarnet" runat="server" Text="####"   ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="50">
                    <asp:Label CssClass="labels" ID="lbStatus"  runat="server" Text="Status:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="50">
                    <asp:DropDownList  CssClass="combo_box" ID="cbStatus" runat="server" >
                        <asp:ListItem Text="Activado"></asp:ListItem>
                        <asp:ListItem Text="Desactivado"></asp:ListItem>
                    </asp:DropDownList>
                    


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="cbStatus"
                        Text="*"
                        ErrorMessage="Status requerido."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                  
                



                    

                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label CssClass="labels" ID="lbDescuento" runat="server" Text="Aplicar Descuento (*):" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="descuento1" runat="server" MaxLength="5"></asp:TextBox>


                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="descuento1"
                        Text="*"
                        ErrorMessage="Aplicar Descuento."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                
                    <asp:RangeValidator ID="rvclass"
                        runat="server"
                        ControlToValidate="descuento1"
                        Text="*"
                        ErrorMessage="Descuento de (0-100)"
                        ForeColor="Red"
                        MaximumValue="100"
                        MinimumValue="0"
                        Type="Double">
                    </asp:RangeValidator>




                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label  CssClass="labels" ID="lbCedula" runat="server" Text="Cedula:"  ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox  CssClass="textbox" ID="tbCedula" runat="server" MaxLength="8" ReadOnly="True" BackColor="#CCCCCC"></asp:Textbox>
                    
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="tbCedula"
                        Text="*"
                        ErrorMessage="Campo de Cedula vacio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="tbCedula"
                        Text="*"
                        ErrorMessage="La Cedula esta fuera del rango numerico."
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*$">
                    </asp:RegularExpressionValidator>--%>



                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label  CssClass="labels" ID="lbNombre" runat="server" Text="Nombre (*):"   ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox  CssClass="textbox" ID="tbNombre" runat="server" MaxLength="50" ReadOnly="True" BackColor="#CCCCCC"></asp:Textbox>
                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ControlToValidate="tbNombre"
                        Text="*"
                        ErrorMessage="Campo de Nombre Vacio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RequiredFieldValidator12" runat="server"
                        ControlToValidate="tbNombre"
                        Text="*"
                        ErrorMessage="Nombre no permitido."
                        ForeColor="Red"
                        ValidationExpression="^[a-z A-ZáéíóúÁÉÍÓÚ]*$">
                    </asp:RegularExpressionValidator>--%>

                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label CssClass="labels" ID="lbApellido"  runat="server" Text="Apellido (*):" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox  CssClass="textbox" ID="tbApellido" runat="server"  MaxLength="90" ReadOnly="True" BackColor="#CCCCCC" ></asp:Textbox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ControlToValidate="tbApellido"
                        Text="*"
                        ErrorMessage="Campo de Apellido Vacio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="tbApellido"
                        Text="*"
                        ErrorMessage="Apellido no permitido."
                        ForeColor="Red"
                        ValidationExpression="^[a-z A-ZáéíóúÁÉÍÓÚ]*$">
                    </asp:RegularExpressionValidator>--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                     <asp:Label  CssClass="labels" ID="lbFechaNac" runat="server" Text="Fecha de Nacimiento (*):" ></asp:Label>
                    </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="FechaNacimiento" runat="server"  TextMode="Date" width="240" height="38" ReadOnly="True" BackColor="#CCCCCC" ></asp:TextBox>
                   <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ControlToValidate="FechaNacimiento"
                        Text="*"
                        ErrorMessage="Campo de Fecha Vacio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                  
                    --%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label  CssClass="labels" ID="Label5" runat="server" Text="Fecha de Admision:" ></asp:Label>
                    </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="tbFechaAdmision" runat="server"  TextMode="Date" width="240" height="38" ReadOnly="True" BackColor="#CCCCCC" ></asp:TextBox>

                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label  CssClass="labels" ID="Label6" runat="server" Text="Fecha de Vencimiento:" ></asp:Label>
                    </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox CssClass="textbox" ID="tbFechaVencimiento" runat="server"  TextMode="Date" width="240" height="38" ReadOnly="True" BackColor="#CCCCCC" ></asp:TextBox>

                </asp:TableCell>


            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Telefono(*):" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Textbox  CssClass="textbox" ID="telefono"  runat="server" ReadOnly="True" BackColor="#CCCCCC"></asp:Textbox>
                    
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ControlToValidate="telefono"
                        Text="*"
                        ErrorMessage="Campo de Telefono Vacio."
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                        ControlToValidate="telefono"
                        Text="*"
                        ErrorMessage="Telefono no permitido."
                        ForeColor="Red"
                        ValidationExpression="^[0-9]*$">
                    </asp:RegularExpressionValidator>--%>


                </asp:TableCell>
                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:TableCell>
                        <asp:Label  CssClass="textbox" ID="Label4" runat="server" Text="(Telefono sin espacio ni guiones)" ></asp:Label>
                </asp:TableCell>

                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
               
            </asp:TableRow>
        </asp:Table>

        <br/>

        <div class="centrado">
             <asp:Label CssClass="labels" ID="Label3"  runat="server" Text="Presionar el Boton Carnet para generar Un carnet Fisico" ></asp:Label>
        </div>
        <br/>
        <div class="marginBotonCarnet">
             <asp:Button  CssClass="Boton"  ID="btnCarnet" runat="server" Text="Carnet" OnClick="btnCarnet_Click"  ></asp:Button>
        
        </div>
        <div>
            <asp:Table ID="tabla1" HorizontalAlign="Center" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                            runat="server"
                            DisplayMode="BulletList"
                            EnableClientScript="true"
                            ShowSumary="True"
                            HeaderText="" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

        </div>
       


         <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" style="margin-top: 0px" Width="395px">
            <asp:TableRow>
                <asp:TableCell CssClass="centrado" Height="50">
                     <asp:Button  CssClass="Boton"  ID="btnCancelar" runat="server" Text="Atras"></asp:Button>
                </asp:TableCell>
                <asp:TableCell  CssClass="centrado">
                </asp:TableCell>
                <asp:TableCell  CssClass="centrado">
                     <asp:Button  CssClass="Boton"  ID="btnAceptar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"  ></asp:Button>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <br />
    </div>
   
    
</asp:Content>
