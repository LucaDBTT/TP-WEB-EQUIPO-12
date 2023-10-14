<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Carrito.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>Carrito de Compras</header>
     <asp:GridView ID="dgvCarrito" runat ="server" AutoGenerateColumns="False" cssclass="table table-dark table-striped-columns">
                <Columns>
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="IdArticulo" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
</asp:Content>
