<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="Listing.aspx.cs" Inherits="agency_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
	<ol class="breadcrumb">
		<li>
            <a href="Default.aspx"><em class="fa fa-home"></em></a
		</li>
		<li class="active"><asp:Literal ID="Literal3" runat = "server" meta:resourceKey="breadcrumb"></asp:Literal></li>
	</ol>
</div>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header"><asp:Literal ID="Literal4" runat = "server" meta:resourceKey="breadcrumb"></asp:Literal></h1>
	</div>
</div>
<div class="panel panel-container">
    <div class="row">
        <div class="col-xs-4 col-md-4 col-lg-4 no-padding">
			<div class="panel panel-teal panel-widget border-right">
				<a href ="NewListing.aspx"><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="NewListing"></asp:Literal></a>
			</div>
		</div>
        <div class="col-xs-4 col-md-4 col-lg-4 no-padding">
			<div class="panel panel-teal panel-widget border-right">
				<a href ="PendingListing.aspx"><asp:Literal ID="Literal5" runat = "server" meta:resourceKey="PendingListing"></asp:Literal></a>
			</div>
		</div>
		<div class="col-xs-4 col-md-4 col-lg-4 no-padding">
			<div class="panel panel-blue panel-widget border-right">
				<a href ="ViewAllListing.aspx"><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="ViewAllListing"></asp:Literal></a>
			</div>
		</div>
    </div>
</div>
</asp:Content>

