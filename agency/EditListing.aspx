<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="EditListing.aspx.cs" Inherits="agency_EditListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script>
    var totalFile = 0;


    function ValidateListingType(source, args) {
        var chkListModules = document.getElementById('<%= listingTypeCb.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        var countTrue = 0;
        for (var i = 0; i < chkListinputs.length; i++) {
            if (chkListinputs[i].checked) {
                countTrue++;
            }
        }
        if (countTrue == 0) {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function salePriceValidator(source, args) {
        var chkListModules = document.getElementById('<%= listingTypeCb.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        var salePrice = document.getElementById('<%= salePrice.ClientID %>');
        if (chkListinputs[0].checked && salePrice.value == '') {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function rentPriceValidator(source, args) {
        var chkListModules = document.getElementById('<%= listingTypeCb.ClientID %>');
        var chkListinputs = chkListModules.getElementsByTagName("input");
        var rentPrice = document.getElementById('<%= rentPrice.ClientID %>');
        if (chkListinputs[1].checked && rentPrice.value == '') {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function priceCompare(source, args) {
        var size = document.getElementById('<%= size.ClientID %>').value;
        var netSize = document.getElementById('<%= netSize.ClientID %>').value;

        if (parseInt(netSize) > parseInt(size)) {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function validatenumerics(key) {
        var keycode = (key.which) ? key.which : key.keyCode;
        if (keycode > 31 && (keycode < 48 || keycode > 57)) {
            return false;
        }
        else return true;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager runat="server" ID="smanager"  EnablePageMethods="true" EnableViewState="true"/>
<div class="row">
	<ol class="breadcrumb">
		<li><a href="<%=CommonFunc.GetAgencyDomain() %>home/">
			<em class="fa fa-home"></em>
		</a></li>
		<li>
            <a href="<%=CommonFunc.GetAgencyDomain() %>listing/"><asp:Literal ID="Literal6" runat = "server" meta:resourceKey="listingBreadcrumb"></asp:Literal></a>
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
            <asp:UpdatePanel runat="server" ID ="wallPanel" UpdateMode ="Conditional" ChildrenAsTriggers ="true">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="listID" />
		            <div class="form-group">
                        <asp:HiddenField runat="server" ID ="areaID" />
                        <b><asp:Label runat ="server" ID="Label1" meta:resourceKey ="area"></asp:Label></b>
                        <asp:Label runat ="server" ID="area"></asp:Label>
		            </div>
		            <div class="form-group">
                         <asp:HiddenField runat="server" ID ="districtID" />
                        <b><asp:Label runat ="server" ID="Label2" meta:resourceKey ="district"></asp:Label></b>
                        <asp:Label runat ="server" ID="district"></asp:Label>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label3" meta:resourceKey ="buildingNameEn"></asp:Label></b>
			            <asp:TextBox runat="server" ID="titleEn" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="v3" ControlToValidate="titleEn" ForeColor="Red"
                            Display="Dynamic" meta:resourceKey="buildingNameEnError"></asp:RequiredFieldValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label4" meta:resourceKey ="buildingNameTc"></asp:Label></b>
			            <asp:TextBox runat="server" ID="titleTc" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="v4" ControlToValidate="titleTc" ForeColor="Red"
                            Display="Dynamic" meta:resourceKey="buildingNameTcError"></asp:RequiredFieldValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label5" meta:resourceKey ="subTitleEn"></asp:Label></b>
			            <asp:TextBox runat="server" ID="subTitleEn" CssClass="form-control"></asp:TextBox>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label6" meta:resourceKey ="subTitleTc"></asp:Label></b>
			            <asp:TextBox runat="server" ID="subTitleTc" CssClass="form-control"></asp:TextBox>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label7" meta:resourceKey ="roomNum"></asp:Label></b>
			            <asp:DropDownList runat="server" ID ="roomDDL" CssClass="form-control">
                            <asp:ListItem Value="0" meta:resourceKey ="openRoom"></asp:ListItem>
                            <asp:ListItem Value="1" Text ="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text ="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text ="3"></asp:ListItem>
                            <asp:ListItem Value="4" Text ="4"></asp:ListItem>
                            <asp:ListItem Value="5" Text ="5"></asp:ListItem>
                            <asp:ListItem Value="6" Text ="6"></asp:ListItem>
                            <asp:ListItem Value="7" Text ="7"></asp:ListItem>
                            <asp:ListItem Value="8" Text ="8"></asp:ListItem>
                            <asp:ListItem Value="9" Text ="9"></asp:ListItem>
                            <asp:ListItem Value="10" Text ="10+"></asp:ListItem>
			            </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="v5" ControlToValidate="roomDDL" Display="Dynamic"
                            ForeColor ="Red" meta:resourceKey="roomNumError"></asp:RequiredFieldValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label8" meta:resourceKey ="bathroomNum"></asp:Label></b>
			            <asp:DropDownList runat="server" ID ="bathroomDDL" CssClass="form-control">
                           
                            <asp:ListItem Value="1" Text ="1"></asp:ListItem>
                            <asp:ListItem Value="2" Text ="2"></asp:ListItem>
                            <asp:ListItem Value="3" Text ="3"></asp:ListItem>
                            <asp:ListItem Value="10" Text ="4+"></asp:ListItem>
			            </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID ="v6" ControlToValidate="bathroomDDL" Display="Dynamic"
                            ForeColor="Red" meta:resourceKey="bathroomNumError"></asp:RequiredFieldValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label9" meta:resourceKey ="size"></asp:Label></b>
			            <asp:TextBox runat="server" ID="size" CssClass="form-control" onkeypress="return validatenumerics(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="v7" Display="Dynamic" ForeColor="Red"
                             ControlToValidate="size" meta:resourceKey="sizeError"></asp:RequiredFieldValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label10" meta:resourceKey ="netSize"></asp:Label></b>
			            <asp:TextBox runat="server" ID="netSize" CssClass="form-control" onkeypress="return validatenumerics(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="v8" Display="Dynamic" ForeColor="Red"
                             ControlToValidate="netSize" meta:resourceKey="netSizeError"></asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server" ID="CustomValidator1" Display="Dynamic" ForeColor="Red" ClientValidationFunction="priceCompare"
                            meta:resourceKey="sizeLarge"></asp:CustomValidator>
		            </div>
		            <div class="form-group">
                        
			            <asp:CheckBoxList runat="server" ID ="listingTypeCb" RepeatDirection="Horizontal" CssClass="form-control">
                            <asp:ListItem Value="1" meta:resourceKey ="sale"></asp:ListItem> 
                            <asp:ListItem Value="2" meta:resourceKey ="rent"></asp:ListItem>
			            </asp:CheckBoxList>
                        <asp:CustomValidator runat="server" ID="v9" Display="Dynamic" ForeColor="Red" ClientValidationFunction="ValidateListingType"
                            meta:resourceKey="listingTypeError"></asp:CustomValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label11" meta:resourceKey ="salePrice"></asp:Label></b>
			            <asp:TextBox runat="server" ID="salePrice" CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator runat="server" ID="v10" Display="Dynamic" ForeColor="Red" ClientValidationFunction="salePriceValidator"
                          meta:resourceKey="salePriceError"></asp:CustomValidator>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label12" meta:resourceKey ="rentPrice"></asp:Label></b>
			            <asp:TextBox runat="server" ID="rentPrice" CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator runat="server" ID="v11" Display="Dynamic" ForeColor="Red" ClientValidationFunction="rentPriceValidator"
                            meta:resourceKey="rentPriceError"></asp:CustomValidator>
		            </div>
		            <div class="form-group">
                        Youtube ID</b>
			            <asp:TextBox runat="server" ID="youtubeID" CssClass="form-control"></asp:TextBox>
		            </div>
		            <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label13" meta:resourceKey ="descEn"></asp:Label></b>
			            <asp:TextBox runat="server" ID="descEn" CssClass="form-control" TextMode="MultiLine" Height="180"></asp:TextBox>
		            </div>
                    <div class="form-group">
                        <b><asp:Label runat="server" ID ="Label14" meta:resourceKey ="descTc"></asp:Label></b>
			            <asp:TextBox runat="server" ID="descTc" CssClass="form-control" TextMode="MultiLine" Height="180"></asp:TextBox>
		            </div>
                    <div class="form-group">
                        <asp:Literal runat="server" ID="testMsg"></asp:Literal>
                        <asp:Repeater runat="server" ID="photoRepeater">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID ="photoID" Value = '<%# DataBinder.Eval(Container, "DataItem.photoID")%>' />
                                <asp:HiddenField runat="server" ID="photoPath" value ='<%# DataBinder.Eval(Container, "DataItem.photoPath")%>' />
                                <asp:Image ID="Image1" runat="server" height="60" ImageUrl ='<%# CommonFunc.ImageUrl() + DataBinder.Eval(Container, "DataItem.photoPath")%>'/>
                                <asp:Button runat="server" ID ="delPhotoButton" meta:resourceKey="removePhoto" OnClick = "delPhotoButton_Click" CssClass="btn btn-danger"/>
                                 <hr />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="availablePhotoRepeater">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID ="index" Value = '<%# Eval("index")%>' />
                                
                                <asp:FileUpload runat="server" ID ="fileUpload" />
                                <hr />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Button runat="server" ID="saveBtn" meta:resourceKey="saveBtn" OnClick="saveBtn_Click" CssClass="btn btn-block btn-primary"/>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
</asp:Content>

