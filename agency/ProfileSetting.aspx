<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="ProfileSetting.aspx.cs" Inherits="agency_ProfileSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
	<ol class="breadcrumb">
		<li><a href="<%=CommonFunc.GetAgencyDomain() %>home/">
			<em class="fa fa-home"></em>
		</a></li>
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
       
    </div>
</div>
</asp:Content>

