<%@ Page Title="Consuta de Acciones" Language="C#" MasterPageFile="~/Interfaz/temp/back_office_temp.Master" AutoEventWireup="true" CodeBehind="web_08_consultarAcciones.aspx.cs" Inherits="back_office.Interfaz.web.RolesSeguridad.web_08_consultarAcciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Roles y Acciones
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/standards.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="middle_place_holder" runat="server">
    <h2>Consultar Acciones</h2>

     <asp:Table ID="Table0" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="center">             
                <asp:Label CssClass="avisoMensaje" ID="LabelMensaje" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" Style="padding-bottom:20px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">

                <asp:GridView ID="GridView1" CssClass="mGrid" AllowPaging="True" HorizontalAlign="Center" runat="server" BorderStyle="None"  
                              AllowSorting="true" GridLines="None" AutoGenerateColumns="False" Width="510px" ForeColor="#99CCFF" 
                              PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField HeaderText="Acción" DataField="Acción" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                             <asp:BoundField HeaderText="Descripción" DataField="Descripción"  ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        </Columns>
                    <PagerStyle CssClass="pgr" />
                    <SelectedRowStyle HorizontalAlign="Center" BackColor="#3366FF" BorderColor="Black" />
                </asp:GridView>

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>

