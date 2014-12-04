<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" UnobtrusiveValidationMode="None"
    AutoEventWireup="true" CodeBehind="web_07_reservacionServicio.aspx.cs"
     Inherits="front_office.Interfaz.web.Reservas.web_07_reservacionServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">

          <link href="../../../comun/resources/css/Reservas/estilo.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
     Reservar
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">

   <h2>Reservar Servicios de Playa</h2>

       <asp:Label ID="Label1" runat="server" Text="Se ha guardado correctamente la reserva." Visible="false" CssClass="avisoMensaje MensajeExito"></asp:Label>
<div  id="reservar">
    
     <asp:MultiView ID="MV_ListaUsuario" runat="server" ActiveViewIndex="0">
                <asp:View ID="GV_Usuario" runat="server">

                    <asp:GridView id="GridViewUsuario2" CssClass="mGrid" AllowPaging="True" HorizontalAlign ="Center" runat="server" 
                                        BorderStyle="None"   AllowSorting="true" GridLines="None" AutoGenerateColumns="False"  
                                        Width="832px" ForeColor="#99CCFF" PageSize="8" OnRowDataBound="GV_RowDataBound" >
                     

                       <AlternatingRowStyle CssClass="alt" />
                         <Columns>
                              <asp:TemplateField HeaderText="Reserva">         
                    <ItemTemplate> 
                            <asp:CheckBox ID="check" runat="server"   ></asp:CheckBox>
                                  </ItemTemplate>
                     </asp:TemplateField>
                   
                     
                            <asp:BoundField  HeaderText="Sevicio" DataField="Servicio" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        

                            <asp:BoundField HeaderText="Costo"  DataField="Costo"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


                            <asp:BoundField HeaderText="Cantidad Disponible" DataField="Cantidad Disponible"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


            <asp:TemplateField HeaderText="Fecha">         
                    <ItemTemplate>
                       <asp:RequiredFieldValidator  DataField="Fecha" runat="server" ControlToValidate="fechaT"  ErrorMessage="Fecha Requerida" Text="*" ForeColor="Red">  </asp:RequiredFieldValidator>
                     </ItemTemplate>
        </asp:TemplateField>
                   
                    
                  <asp:TemplateField HeaderText="Hora Inicio">         
                    <ItemTemplate>
                       <asp:RequiredFieldValidator DataField="HoraInicio" runat="server" ControlToValidate="horaI"  ErrorMessage="Hora Inicio Requerida" Text="*" ForeColor="Red">  </asp:RequiredFieldValidator>
                     </ItemTemplate>
                   </asp:TemplateField>
       

                           <asp:TemplateField HeaderText="Hora Fin">         
                    <ItemTemplate>
                       <asp:RequiredFieldValidator  DataField="HoraFin" runat="server" ControlToValidate="horaF"  ErrorMessage="Hora Fin Requerida" Text="*" ForeColor="Red">  </asp:RequiredFieldValidator>
                     </ItemTemplate>
                     </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">         
                    <ItemTemplate>
                       <asp:RequiredFieldValidator DataField="cantidad" runat="server" ControlToValidate="cantidad"  ErrorMessage="Cantidad Requerida" Text="*" ForeColor="Red">  </asp:RequiredFieldValidator>
                     </ItemTemplate>
                     </asp:TemplateField>

                         </Columns>
                        <PagerStyle CssClass="pgr" />
                                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                    </asp:GridView>

                </asp:View>
            </asp:MultiView>

    <br />

     <asp:Button ID="Button4" runat="server" CssClass="Boton" Text="Aceptar" OnClick="Button4_Click" />


</div>
     <asp:ValidationSummary CssClass="avisoMensaje MensajeError" ID="ValidationSummary1"
                HeaderText=""
                DisplayMode="BulletList"
                EnableClientScript="true"
                runat="server" 
  />

</asp:Content>
