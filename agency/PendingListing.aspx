﻿<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="PendingListing.aspx.cs" Inherits="agency_PendingListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="smanager"  EnablePageMethods="true" EnableViewState="true"/>
<div class="row">
	<ol class="breadcrumb">
		<li><a href="Default.aspx">
			<em class="fa fa-home"></em>
		</a></li>
		<li>
            <a href="Listing.aspx"><asp:Literal ID="Literal6" runat = "server" meta:resourceKey="listingBreadcrumb"></asp:Literal></a>
		</li>
		<li class="active"><asp:Literal ID="Literal3" runat = "server" meta:resourceKey="breadcrumb"></asp:Literal></li>
	</ol>
</div>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header"><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="breadcrumb"></asp:Literal></h1>
	</div>
</div>
<div class="panel panel-default">
	<div class="panel-body">
        <div class="col-md-12">
            <asp:UpdatePanel runat="server" ID="pendingPanel" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID ="pendingListRepeater">
                        <HeaderTemplate>
                            <table class="table table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col"></th>
                                        <th scope="col"><asp:Literal ID="Literal7" runat = "server" meta:resourceKey="title"></asp:Literal></th>
                                        <th scope="col"><asp:Literal ID="Literal8" runat = "server" meta:resourceKey="distict"></asp:Literal></th>
                                        <th scope="col"><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="size"></asp:Literal></th>
                                        <th scope="col"><asp:Literal ID="Literal4" runat = "server" meta:resourceKey="price"></asp:Literal></th>
                                        <th scope="col"><asp:Literal ID="Literal5" runat = "server" meta:resourceKey="duation"></asp:Literal></th>
                                    </tr>
                                </thead>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                              <th scope="row">

                              </th>
                              <td>
                                  <%# DataBinder.Eval(Container, "DataItem.titleEn")%><br />
                                  <%# DataBinder.Eval(Container, "DataItem.titleTc")%>
                              </td>
                              <td>
                                  <%# DataBinder.Eval(Container, "DataItem.district")%>
                              </td>
                              <td>
                                  <%# DataBinder.Eval(Container, "DataItem.size")%> / <%# DataBinder.Eval(Container, "DataItem.netSize")%>
                              </td>
                              <td>
                                  $<%# DataBinder.Eval(Container, "DataItem.salePrice")%> / $<%# DataBinder.Eval(Container, "DataItem.rentPrice")%>
                              </td>
                              <td>
                                  <asp:DropDownList runat="server" ID="durationDDL" CssClass="form-control">
                                      <asp:ListItem Value ="0" meta:resourceKey="notPublish"></asp:ListItem>
                                      <asp:ListItem Value ="15" meta:resourceKey="days15"></asp:ListItem>
                                      <asp:ListItem Value ="30" meta:resourceKey="days30"></asp:ListItem>
                                      <asp:ListItem Value ="45" meta:resourceKey="days45"></asp:ListItem>
                                      <asp:ListItem Value ="60" meta:resourceKey="days60"></asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                              </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>

                </Triggers>
            </asp:UpdatePanel>
            
        </div>
    </div>
</div>
</asp:Content>
