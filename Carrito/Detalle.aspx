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
         <asp:Repeater ID="repeaterImages" runat="server" DataSource="<%# imagenesArticulo %>">
    <ItemTemplate>
        <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
            <img src='<%# Eval("Descripcion") %>' class="d-block w-100" alt="...">
        </div>
    </ItemTemplate>
</asp:Repeater>

        <div id="carouselExample" class="carousel slide">
  <div class="carousel-inner">
    <div class="carousel-item active">
    
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
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
