<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Carrito.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="LBL" runat="server" Text=""></asp:Label>
    <h1><%: nombre %></h1>


    <body>
        <div class="container text-center">
            <div class="row">
                <div class="col">
              <div class="carousel">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner">
            <asp:Repeater ID="repeaterImagenes" runat="server">
    <ItemTemplate>
        <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
            <img src='<%# Container.DataItem %>' alt="Imagen" class="d-block w-100" />
        </div>
    </ItemTemplate>
</asp:Repeater>
        </div>
        <a class="carousel-control-prev" href="#myCarousel" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Anterior</span>
        </a>
        <a class="carousel-control-next" href="#myCarousel" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Siguiente</span>
        </a>
    </div>
</div>


                </div>
                <div class="col1">
                    <div class="card" style="width: 18rem;">
                        <div class="card-body">
                            <h5 class="card-title"><%:nombre %></h5>
                            <p class="card-text"><%:descripcion %></p>
                            <a href="Compra.aspx" class="btn btn-primary">Añadir al Carrito</a>
                        </div>
                    </div>
                </div>
    </body>


</asp:Content>
