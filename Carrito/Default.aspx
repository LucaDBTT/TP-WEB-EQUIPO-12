<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepeater" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="..." onerror="this.src='https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg'">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <asp:HyperLink ID="lnkDetalle" runat="server" DataKeyNames="IdArticulo" NavigateUrl="Detalle.aspx" Text="Ver Detalle" CssClass="btn btn-primary" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
