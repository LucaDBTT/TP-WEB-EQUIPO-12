<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Carrito.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>
        <section style="margin-top: 100px;">
            <asp:Label ID="LBL" runat="server" Text=""></asp:Label>
            <div class="container text-center">
                <div class="row">
                    <div class="col-6 d-flex align-items-center">
                        <div id="myCarousel" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="repeaterImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                            <img id="Imagenes" src='<%# Container.DataItem %>' alt="Imagen" class="d-block w-100 carousel-image" onerror="this.src='https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg'" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <a class="carousel-control-prev" href="#myCarousel" role="button" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Anterior</span>
                            </a>
                            <a class="carousel-control-next" href="#myCarousel" role="button" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Siguiente</span>
                            </a>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="card custom-card" style="width: 30rem; box-shadow: 0 0 20px rgba(0, 128, 128, 0.5);">
                            <div class="card-body">
                                <h5 class="card-title"><%:marca %> <%:nombre %></h5>
                                <p class="card-text"><%:descripcion %></p>
                                <h5 class="car-title">$<%:precio %></h5>
                             <a href='<%= "Compra.aspx?IdArticulo=" + Request.QueryString["IdArticulo"] %>' class="btn btn-primary">Agregar al Carrito</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </body>



</asp:Content>
