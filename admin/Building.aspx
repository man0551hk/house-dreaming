<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Building.aspx.cs" Inherits="admin_Building" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" EnableViewState="true"/>
<div class="row">
	<ol class="breadcrumb">
		<li><a href="<%=CommonFunc.GetMasterDomain() %>home/">
			<em class="fa fa-home"></em>
		</a></li>
		<li class="active">Building</li>
	</ol>
</div>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header">Building</h1>
	</div>
</div>
<div class ="row">
    <div class="col-md-12">
        <div class="panel panel-primary">
	        <div class="panel-body">
                <asp:FileUpload runat="server" ID ="fileUpload" CssClass="form-control" />
                <asp:Button runat="server" ID ="uploadBtn" Text="Upload" OnClick="uploadBtn_Click" />
	        </div>
        </div>
    </div>
</div>
</asp:Content>

