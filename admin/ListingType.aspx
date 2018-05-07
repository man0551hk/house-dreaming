<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="ListingType.aspx.cs" Inherits="admin_ListingType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" EnableViewState="true"/>
<div class="row">
	<ol class="breadcrumb">
		<li><a href="<%=CommonFunc.GetMasterDomain() %>home/">
			<em class="fa fa-home"></em>
		</a></li>
		<li class="active">Listing Type</li>
	</ol>
</div>
<div class="row">
	<div class="col-lg-12">
		<h1 class="page-header">Listing Type</h1>
	</div>
</div>
<div class ="row">
    <div class="col-md-12">
        <div class="panel panel-primary">
	        <div class="panel-body">
                <asp:UpdatePanel runat="server" ID="listingTypePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:UpdateProgress runat="server" ID ="listingTypeUpdateProgress">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <table>
                            <tr>
                                <td>Name En</td><td>Name Tc</td><td>Name Sc</td>
                                <td>Price</td>
                            </tr>                       
                        <asp:Repeater runat ="server" ID ="listingTypeRepeater">
                            <HeaderTemplate>

                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID ="hiddenTypeID" Value = '<%# DataBinder.Eval(Container, "DataItem.typeID")%>' />
                                    <tr>
                                        <td><asp:TextBox runat="server" ID ="nameEn" value ='<%# DataBinder.Eval(Container, "DataItem.typeNameEn")%>' CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox runat="server" ID ="nameTc" value ='<%# DataBinder.Eval(Container, "DataItem.typeNameTc")%>' CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox runat="server" ID ="nameSc" value ='<%# DataBinder.Eval(Container, "DataItem.typeNameSc")%>' CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox runat="server" ID ="price" value ='<%# DataBinder.Eval(Container, "DataItem.price")%>' CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
     
                            </FooterTemplate>
                        </asp:Repeater>   
                            <tr>
                                <td><asp:TextBox runat="server" ID ="newNameEn"  CssClass="form-control"></asp:TextBox></td>
                                <td><asp:TextBox runat="server" ID ="newNameTc"  CssClass="form-control"></asp:TextBox></td>
                                <td><asp:TextBox runat="server" ID ="newNameSc"  CssClass="form-control"></asp:TextBox></td>
                                <td><asp:TextBox runat="server" ID ="newPrice"  CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="4" align ="right">
                                    <asp:Button runat="server" ID ="updBtn" OnClick="updBtn_Click" Text ="Update" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                       </table>                         
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="updBtn" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
	        </div>
        </div>
    </div>
</div>

</asp:Content>

