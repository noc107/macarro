<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web_2_consultarPuesto.aspx.cs" UnobtrusiveValidationMode="None"
    Inherits="BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya.web_2_consultarPuesto" 
    MasterPageFile="~/Presentacion/Vistas/Temp/back_office_temp.Master"%>

<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/formularioConsultarPuesto.ascx" TagPrefix="uc1" TagName="formularioConsultarPuesto" %>
<%@ Register Src="~/Presentacion/Vistas/Web/ConfiguracionPuestosPlaya/componentes/mensajeDeEstado.ascx" TagPrefix="uc1" TagName="mensajeDeEstado" %>



<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../../comun/resources/css/ConfiguracionPuestosPlaya/puestosPlaya.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
    Consultar Puesto
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    <!--- titulo de la ventana --->
    Gestion de playa
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">   
    <!--- contenido de la ventana --->
    <h2>Consultar Puesto</h2>
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UDP" runat="server"> 
            <ContentTemplate> 
        <uc1:mensajeDeEstado runat="server" id="mensajeDeEstado" />
        <uc1:formularioConsultarPuesto runat="server" ID="formularioConsultarPuesto" />
        
        <div>
             <div class="btn_aceptar_posicion">
            <asp:Button ID="botonBuscar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="botonBuscar_Click"/>
              
             </div>
          
   
    <asp:MultiView ID="MvListaPuesto" runat="server" ActiveViewIndex="0">
                <!-- Gridview con Ajax -->
    <asp:View ID="GvOrdenPuesto" runat="server">
        
                <asp:GridView ID="GV_ConsultarPuesto" CssClass="mGrid" runat="server"  
                    Height="96px" ForeColor="#333333" GridLines="None" AllowPaging="true"
                     PageSize="7" AllowSorting="true"
                     OnRowCommand="GridView_ConsultarPuesto_RowCommand" AutoGenerateColumns="False"
                     OnPageIndexChanging="GvPuestoPageIndexChanging" 
                     DataKeyNames="COLUMNA,FILA,DESCRIPCION,PRECIO">
                    
                    <AlternatingRowStyle CssClass="alt" />
                    

                    <Columns>
                    <asp:BoundField HeaderText="Filas" DataField="FILA" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                    <asp:BoundField HeaderText="Columnas" DataField="COLUMNA"  ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                    <asp:BoundField HeaderText="Descripcion" DataField="DESCRIPCION" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"></asp:BoundField>
                    <asp:BoundField HeaderText="Monto" DataField="PRECIO" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ></asp:BoundField>
                   

                        <asp:ButtonField CommandName="update"
                             ItemStyle-Width="50px" 
                                             ItemStyle-Height="50px" 
                                         ImageUrl="~/comun/resources/img/Data-Edit-128.png" 
                                         ButtonType="Image" ControlStyle-CssClass="actions_icons"  />

                        <asp:ButtonField CommandName="delete" 
                             ItemStyle-Width="50px" 
                                             ItemStyle-Height="50px" 
                                         ImageUrl="~/comun/resources/img/Garbage-Closed-128.png" 
                                         ButtonType="Image" ControlStyle-CssClass="actions_icons"/>


                    </Columns>
                     <PagerSettings Mode="Numeric" Position="Bottom"  PageButtonCount="5"/>
                                <pagerstyle CssClass="pgr"  />
                </asp:GridView>
              
           
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <br/>
                            Cargando ...
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                </asp:View>
                    

            </asp:MultiView>
            </div>
                    <div>
         <table>
              <tr>
                  <td>
           <asp:Button ID="Modificar" Visible="false" runat="server" Text="Modificar" CssClass="Boton" OnClick="Modificar_Click" />
            </td>
            <td>
          <asp:Button ID="Eliminar" Visible="false" runat="server" Text="Eliminar" CssClass="Boton" OnClick="Eliminar_Click" />
           </td>
            </tr>
           </table>
        </div>
     </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="botonBuscar" />
            </Triggers>
                </asp:UpdatePanel>

      
    </div>
     
      
           
</asp:Content>
