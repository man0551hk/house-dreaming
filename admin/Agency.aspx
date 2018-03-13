<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="Agency.aspx.cs" Inherits="admin_Agency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" EnableViewState="true"/>
<div class="row">
	<ol class="breadcrumb">
		<li><a href="Default.aspx">
			<em class="fa fa-home"></em>
		</a></li>
		<li class="active">Agency</li>
	</ol>
</div>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header">Agency</h1>
	</div>
</div>
<div class ="row">
    <div class="col-md-12">
        <div class="panel panel-primary">
	        <div class="panel-heading">New Sign Up Agencies
		        <%--<span class="pull-right clickable panel-toggle"><em class="fa fa-toggle-up"></em></span>--%>
	        </div>
	        <div class="panel-body">
                <asp:UpdatePanel runat="server" ID="agencyPanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:UpdateProgress runat="server" ID ="agencyUpdateProgress">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Repeater runat ="server" ID ="agencyRepeater">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID ="hiddenAgencyID" Value = '<%# DataBinder.Eval(Container, "DataItem.agencyID")%>' />
                                <table>
                                    <tr>
                                        <td><b>Company Name:</b>&nbsp;</td><td><%# DataBinder.Eval(Container, "DataItem.companyName")%>&nbsp;</td>
                                        <td><b>License:</b>&nbsp;<td><%# DataBinder.Eval(Container, "DataItem.companyLicense")%></td></td>
                                    </tr>
                                    <tr>
                                        <td><b>Agent Name:</b>&nbsp;</td><td><%# DataBinder.Eval(Container, "DataItem.agentNameEn")%>&nbsp;<%# DataBinder.Eval(Container, "DataItem.agentNameTc")%></td>
                                    </tr>
                                    <tr>
                                        <td><b>License:</b>&nbsp;</td><td><%# DataBinder.Eval(Container, "DataItem.agentLicense")%>&nbsp;</td>
                                        <td><b>Gender:</b>&nbsp;</td><td><%# DataBinder.Eval(Container, "DataItem.gender")%></td>
                                    </tr>
                                    <tr>
                                        <td><b>Email:</b>: </td><td><%# DataBinder.Eval(Container, "DataItem.email")%>&nbsp;</td>
                                        <td><b>Mobile:</b>: </td><td><%# DataBinder.Eval(Container, "DataItem.mobile")%></td>
                                        
                                    </tr>
                                    <tr>
                                        <td><b>Office:</b>: </td><td><%# DataBinder.Eval(Container, "DataItem.officePhone").ToString() == "0" ? "" : DataBinder.Eval(Container, "DataItem.officePhone").ToString()%>&nbsp;</td>
                                        <td><b>Fax:</b>: </td><td><%# DataBinder.Eval(Container, "DataItem.fax").ToString() == "0" ? "" : DataBinder.Eval(Container, "DataItem.fax").ToString()%></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Button runat="server" ID ="approveBtn" Text="Approve" CssClass="btn btn-block" /></td>
                                    </tr>
                                </table>
                                <hr />
                            </ItemTemplate>
                        </asp:Repeater>                            
                    </ContentTemplate>
                    <Triggers>
                        
                    </Triggers>
                </asp:UpdatePanel>
	        </div>
        </div>
    </div>
</div>

</asp:Content>

