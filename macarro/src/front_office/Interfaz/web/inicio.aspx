<%@ Page Title="" Language="C#" MasterPageFile="~/Interfaz/temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="front_office.view.web.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
    Prato , Daniel
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <div>
        <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
    
        <asp:RadioButtonList CssClass="radio_list" ID="RadioButtonList1" runat="server">
               <asp:ListItem selected="true">Item 1</asp:ListItem>
               <asp:ListItem>Item 2</asp:ListItem>
               <asp:ListItem>Item 3</asp:ListItem>
               <asp:ListItem>Item 4</asp:ListItem>
        </asp:RadioButtonList>

    </div>
    <div>
        <asp:DropDownList CssClass="combo_box" ID="DropDownList1" runat="server">
            <asp:ListItem selected="true">Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
            <asp:ListItem>Item 4</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>

    </div>
    <div>
        <asp:CheckBoxList CssClass="check_box_list" ID="CheckBoxList1" runat="server">
            <asp:ListItem selected="true">Item 1</asp:ListItem>
            <asp:ListItem>Item 2</asp:ListItem>
            <asp:ListItem>Item 3</asp:ListItem>
            <asp:ListItem>Item 4</asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <div>
        <asp:Button CssClass="Boton" ID="Button1" runat="server" Text="Button" />
    </div>
    <div>
        <asp:ImageButton CssClass="actions_icons" src="/comun/resources/img/Data-Edit-128.png" ID="ImageButton3" runat="server" />
    </div>
    <div>
        <asp:ImageButton CssClass="actions_icons" src="/comun/resources/img/Garbage-Closed-128.png" ID="ImageButton4" runat="server" />
    </div>
    <div>
        <asp:ImageButton CssClass="actions_icons" src="/comun/resources/img/View-128.png" ID="ImageButton5" runat="server" />
    </div>
    <div>
        <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <p></p>
</asp:Content>

