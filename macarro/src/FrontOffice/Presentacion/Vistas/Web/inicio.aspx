<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Vistas/Temp/master_loged_in.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="FrontOffice.Presentacion.Vistas.Web.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="css_place_holder" runat="server">
    <link href="../../../comun/resources/css/jquery.bxslider.css" rel="stylesheet" />
    <link href="../../../comun/resources/css/Inicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="libs_place_holder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="js_place_holder" runat="server">
    <script src="../../../../comun/resources/js/jquery.bxslider.min.js"></script>
    <script src="../../../comun/resources/js/slider.js"></script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="username_place_holder" runat="server">
 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="title_shown_place_holder" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="middle_place_holder" runat="server">
    <ul class="bxslider">
      <li>
          <img src="../../../comun/resources/img/pic1Slider.jpg" />

      </li>
      <li>
          <img src="../../../comun/resources/img/pic2Slider.jpg" />

      </li>
      <li>
          <img src="../../../comun/resources/img/pic3Slider.jpg" />

      </li>
      <li>
          <img src="../../../comun/resources/img/pic4Slider.jpg" />

      </li>
    </ul>
    <div id="aside_left">
       
    </div>
    <div id="aside_right">
       
    </div>
</asp:Content>

