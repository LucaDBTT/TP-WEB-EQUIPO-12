<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Carrito.Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <section style="margin-top: 100px;">
            <h1 class="carrito-header">Detalle del carrito</h1>
            <div class="container">
                <div class="row justify-content-center"> 
                    <asp:Repeater ID="repeaterResultados" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 mb-4">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                        <p class="card-text"><%# Eval("Descripcion") %></p>
                                        <h5 class="card-title">$<%# Eval("Precio") %></h5>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div id="totalContainer" class="container mt-4">
                <h3>Total del Carrito</h3>
                <p>Total del carrito: <span runat="server" id="totalAmount"></span></p>
                <a href="FinalizarCompra.aspx" class="btn btn-primary">Finalizar compra</a>
            </div>
        </section>
    </body>
</asp:Content>




