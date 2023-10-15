<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="ResultadosBusqueda.aspx.cs" Inherits="Carrito.ResultadosBusqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="repeaterResultados" runat="server">
        <ItemTemplate>
            <div class="card" style="width: 18rem">
                <img src='<%# Eval("ImagenUrl") %>' alt="Imagen" class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <h5 class="card-title">$<%# Eval("Precio") %></h5>
                    <a href='<%# "Detalle.aspx?IdArticulo=" + Eval("IdArticulo") %>' class="btn btn-primary">Ver Detalle</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

