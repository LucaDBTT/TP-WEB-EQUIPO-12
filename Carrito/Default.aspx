<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div id="carouselExampleIndicators" class="carousel slide">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://http2.mlstatic.com/D_NQ_873745-MLA72127774981_102023-OO.webp" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://http2.mlstatic.com/D_NQ_898711-MLA71976506754_092023-OO.webp" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://http2.mlstatic.com/D_NQ_785591-MLA72023382599_092023-OO.webp" class="d-block w-100" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>


    <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="repRepeater" runat="server">
        <ItemTemplate>
            <div class="card-container card mb-3">
                <img src="<%#Eval("ImagenUrl") %>" class="card-image card-img-top" alt="..." onerror="this.src='https://camarasal.com/wp-content/uploads/2020/08/default-image-5-1.jpg'">
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                    <p class="card-text"><%#Eval("Descripcion") %></p>
                    <a href='<%# "Detalle.aspx?IdArticulo=" + Eval("IdArticulo") %>' class="btn btn-primary">Ver Detalle</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

</asp:Content>
