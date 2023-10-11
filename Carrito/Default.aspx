<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<div class="row row-cols-1 row-cols-md-3 g-4">
<asp:repeater ID="repRepeater" runat="server"  >
    <ItemTemplate>
      
        
    </ItemTemplate>
</asp:repeater>

</div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView id="dgvArticulo" runat="server"></asp:GridView>
</asp:Content>
