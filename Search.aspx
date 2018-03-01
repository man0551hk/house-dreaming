<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row" style="padding-top:5px;">
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="lbDistrict"></asp:Literal></b>
            <asp:DropDownList ID="districtDDL" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="lbRoom"></asp:Literal></b>
            <asp:DropDownList ID="roomDDL" runat="server"  CssClass="form-control">
                <asp:ListItem Value="1" Text ="1"></asp:ListItem>
                <asp:ListItem Value="2" Text ="2"></asp:ListItem>
                <asp:ListItem Value="3" Text ="3"></asp:ListItem>
                <asp:ListItem Value="4" Text ="4"></asp:ListItem>
                <asp:ListItem Value="5" Text ="5"></asp:ListItem>
                <asp:ListItem Value="6" Text ="6"></asp:ListItem>
                <asp:ListItem Value="7" Text ="7"></asp:ListItem>
                <asp:ListItem Value="8" Text ="8"></asp:ListItem>
                <asp:ListItem Value="9" Text ="9"></asp:ListItem>
                <asp:ListItem Value="0" Text ="9+"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal3" runat = "server" meta:resourceKey="lbNetSize"></asp:Literal></b>
            <asp:DropDownList ID="netsizeDDL" runat="server"  CssClass="form-control">
                <asp:ListItem Value = "1" meta:resourceKey="size1"></asp:ListItem>
                <asp:ListItem Value = "2" meta:resourceKey="size2"></asp:ListItem>
                <asp:ListItem Value = "3" meta:resourceKey="size3"></asp:ListItem>
                <asp:ListItem Value = "4" meta:resourceKey="size4"></asp:ListItem>
                <asp:ListItem Value = "5" meta:resourceKey="size5"></asp:ListItem>
                <asp:ListItem Value = "6" meta:resourceKey="size6"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" style="padding-bottom:5px;">
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal4" runat = "server" meta:resourceKey="lbListingType"></asp:Literal></b>
            <asp:DropDownList ID="listingTypeDDL" runat="server"  CssClass="form-control">
                <asp:ListItem Value ="1"  meta:resourceKey="lbSale"></asp:ListItem>
                <asp:ListItem Value ="2"  meta:resourceKey="lbRent"></asp:ListItem>
                <asp:ListItem Value ="3"  meta:resourceKey="lbSaleRent"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal5" runat = "server" meta:resourceKey="lbSalePrice"></asp:Literal></b>
            <asp:DropDownList ID="salepriceDDL" runat="server" CssClass="form-control">
                <asp:ListItem Value = "1" meta:resourceKey="sale1"></asp:ListItem>
                <asp:ListItem Value = "2" meta:resourceKey="sale2"></asp:ListItem>
                <asp:ListItem Value = "3" meta:resourceKey="sale3"></asp:ListItem>
                <asp:ListItem Value = "4" meta:resourceKey="sale4"></asp:ListItem>
                <asp:ListItem Value = "5" meta:resourceKey="sale5"></asp:ListItem>
                <asp:ListItem Value = "6" meta:resourceKey="sale6"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class ="col-md-4">
            <b><asp:Literal ID="Literal6" runat = "server" meta:resourceKey="lbRentPrice"></asp:Literal></b>
            <asp:DropDownList ID="rentPriceDDL" runat="server" CssClass="form-control">
                <asp:ListItem Value = "1" meta:resourceKey="rent1"></asp:ListItem>
                <asp:ListItem Value = "2" meta:resourceKey="rent2"></asp:ListItem>
                <asp:ListItem Value = "3" meta:resourceKey="rent3"></asp:ListItem>
                <asp:ListItem Value = "4" meta:resourceKey="rent4"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class ="col-md-12" style="padding-bottom:5px;">
            <asp:Button runat="server" ID ="searchBtn" meta:resourceKey="lbSearchBtn" OnClick="searchBtn_Click" CssClass="btn btn-primary btn-block"/>
        </div>
    </div>
    <div class ="row">
        <div class ="col-md-9">
            <nav aria-label="Page navigation example">
              <ul class="pagination">
                <li class="page-item">
                  <a class="page-link" href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                    <span class="sr-only">Previous</span>
                  </a>
                </li>
                <li class="page-item"><a class="page-link" href="#">1</a></li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
                <li class="page-item">
                  <a class="page-link" href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                    <span class="sr-only">Next</span>
                  </a>
                </li>
              </ul>
            </nav>

            <div class="row">
                <div class="col-md-12">
<%--<div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src ="/images/2.jpg" alt="First slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src ="/images/3.jpg" alt="Second slide">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src ="/images/4.jpg" alt="Third slide">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>--%>
                </div>
            </div>


            <asp:Repeater runat ="server" ID ="listingRepeater">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:Repeater>
            <nav aria-label="Page navigation example">
              <ul class="pagination">
                <li class="page-item disabled">
                  <a class="page-link" href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                    <span class="sr-only">Previous</span>
                  </a>
                </li>
                <li class="page-item"><a class="page-link" href="#">1</a></li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>
                <li class="page-item">
                  <a class="page-link" href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                    <span class="sr-only">Next</span>
                  </a>
                </li>
              </ul>
            </nav>
        </div>
        <div class ="col-md-3">

        </div>
    </div>
        <script>
            $('.carousel').carousel()
    </script>

</asp:Content>

