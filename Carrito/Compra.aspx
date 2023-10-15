<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Carrito.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>Carrito de Compras</header>
     <asp:Label ID="LBL" runat="server" Text=""></asp:Label>
     <asp:Repeater ID="repeaterResultados" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 18rem">
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <h5 class="card-title">$<%# Eval("Precio") %></h5>
                     
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
