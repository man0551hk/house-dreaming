<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
    .box {
        width:100%;
        -webkit-box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);
        -moz-box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);
        box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);    
    }
    .onlyShadow {
        margin:0px;!important
        -webkit-box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);
        -moz-box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);
        box-shadow: 6px 6px 18px -2px rgba(138,134,138,0.81);    
    }
    .noPadding {
        padding:0px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" EnableViewState="true"/>
    <div class="container">

        <asp:UpdatePanel runat="server" ID="searchResultPanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:UpdateProgress runat="server" ID ="searchResultUpdateProgress">
                    <ProgressTemplate>
                    Loading...
                    </ProgressTemplate>
                </asp:UpdateProgress>

        <div class="row" style="padding-top:5px;">
            <div class ="col-md-3" style="padding-bottom:5px;">
                <b><asp:Literal ID="Literal7" runat = "server" meta:resourceKey="lbKeyword"></asp:Literal></b>
                <asp:TextBox runat="server" ID="keywordText" CssClass="form-control"></asp:TextBox>
            </div>
            <div class ="col-md-3">
                <b><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="lbDistrict"></asp:Literal></b>
                <asp:DropDownList ID="districtDDL" runat="server" CssClass="form-control"  DataTextField="district" DataValueField="districtID"></asp:DropDownList>
            </div>
            <div class ="col-md-3">
                <b><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="lbRoom"></asp:Literal></b>
                <asp:DropDownList ID="roomDDL" runat="server"  CssClass="form-control">
                    <asp:ListItem Value="" meta:resourceKey="lbAny"></asp:ListItem>
                    <asp:ListItem Value="0" Text ="9+"></asp:ListItem>
                    <asp:ListItem Value="1" Text ="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text ="2"></asp:ListItem>
                    <asp:ListItem Value="3" Text ="3"></asp:ListItem>
                    <asp:ListItem Value="4" Text ="4"></asp:ListItem>
                    <asp:ListItem Value="5" Text ="5"></asp:ListItem>
                    <asp:ListItem Value="6" Text ="6"></asp:ListItem>
                    <asp:ListItem Value="7" Text ="7"></asp:ListItem>
                    <asp:ListItem Value="8" Text ="8"></asp:ListItem>
                    <asp:ListItem Value="9" Text ="9"></asp:ListItem>
                    <asp:ListItem Value="10" Text ="9+"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class ="col-md-3">
                <b><asp:Literal ID="Literal3" runat = "server" meta:resourceKey="lbNetSize"></asp:Literal></b>
                <asp:DropDownList ID="netsizeDDL" runat="server"  CssClass="form-control">
                    <asp:ListItem Value="" meta:resourceKey="lbAny"></asp:ListItem>
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
                    <asp:ListItem Value ="3"  meta:resourceKey="lbSaleRent"></asp:ListItem>
                    <asp:ListItem Value ="1"  meta:resourceKey="lbSale"></asp:ListItem>
                    <asp:ListItem Value ="2"  meta:resourceKey="lbRent"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class ="col-md-4">
                <b><asp:Literal ID="Literal5" runat = "server" meta:resourceKey="lbSalePrice"></asp:Literal></b>
                <asp:DropDownList ID="salepriceDDL" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" meta:resourceKey="lbAny"></asp:ListItem>
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
                    <asp:ListItem Value="0" meta:resourceKey="lbAny"></asp:ListItem>
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
                        <asp:LinkButton runat="server" ID ="topPrevLink" CssClass="page-link" OnClick="topPrevLink_Click"></asp:LinkButton>
                    </li>
                    <asp:Repeater runat="server" ID ="topPageRepeater">
                        <ItemTemplate>
                            <li class="page-item">
                                <asp:LinkButton runat="server" ID="page" CssClass="page-link" Text=""></asp:LinkButton>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
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

                                <asp:TextBox runat="server" ID="testMsg" Visible="false"></asp:TextBox>
                                <asp:Repeater runat ="server" ID ="listingRepeater">
                                    <ItemTemplate>
                                        <%# ConstructLayout(
                                        Convert.ToInt32(DataBinder.Eval(Container, "DataItem.classID")),
                                        Convert.ToInt32(DataBinder.Eval(Container, "DataItem.listingID")),
                                        DataBinder.Eval(Container, "DataItem.district").ToString(),
                                        DataBinder.Eval(Container, "DataItem.title").ToString(),
                                        DataBinder.Eval(Container, "DataItem.size").ToString(),
                                        DataBinder.Eval(Container, "DataItem.netSize").ToString(),
                                        DataBinder.Eval(Container, "DataItem.salePrice").ToString(),
                                        DataBinder.Eval(Container, "DataItem.rentPrice").ToString(),
                                        DataBinder.Eval(Container, "DataItem.companyName").ToString(),
                                        DataBinder.Eval(Container, "DataItem.photoPath").ToString())%>

                           
                                    </ItemTemplate>
                                </asp:Repeater>                            

                    </div>
                </div>
            </div>

            <div class ="col-md-3">

            </div>
        </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID ="searchBtn" EventName ="Click" />
                <asp:AsyncPostBackTrigger ControlID ="topPrevLink" EventName ="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script>
            $('.carousel').carousel()
    </script>

</asp:Content>

