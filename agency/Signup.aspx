<%@ Page Language="C#" MasterPageFile="~/agency/AgentMasterPage.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="agency_signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function validatenumerics(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                return false;
            }
            else return true;
        }
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=acceptCb.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="login-panel panel panel-default">
	<div class="panel-heading">
            <asp:Literal ID="Literal7" runat = "server" meta:resourceKey="heading"></asp:Literal>
	</div>
	<div class="panel-body">
        <div runat="server" id ="thanks">
            <b><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="thanks"></asp:Literal></b>
        </div>
		<form id="form1" runat="server" role="form">
            <div class="alert bg-danger" role="alert" runat="server" id="errorDiv"><em class="fa fa-lg fa-warning">&nbsp;</em> <asp:Literal runat="server" ID="errorMsg" meta:resourceKey="errorDiv"></asp:Literal></div>
            
			<fieldset>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="companyNameEn" cssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate ="companyNameEn" Display="Dynamic" meta:resourceKey="companyNameError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="companyNameTc" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="companyNameTc" Display="Dynamic" meta:resourceKey="companyNameError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="companyLicense" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate ="companyLicense" Display="Dynamic" meta:resourceKey="companyLicenseError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="agentNameEn" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate ="agentNameEn" Display="Dynamic" meta:resourceKey="agentNameError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="agentNameTc" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate ="agentNameTc" Display="Dynamic" meta:resourceKey="agentNameError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
                <div class="form-group">
                    <asp:TextBox runat="server" ID="agentLicense" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate ="agentLicense" Display="Dynamic" meta:resourceKey="agentLicenseError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="email" type="email" cssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate ="email" Display="Dynamic" meta:resourceKey="emailEmpty" ForeColor="Red"></asp:RequiredFieldValidator>
                               
				</div>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="mobile" cssClass="form-control" onkeypress="return validatenumerics(event);"  />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate ="mobile" Display="Dynamic" meta:resourceKey="mobileError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="officePhone" cssClass="form-control" onkeypress="return validatenumerics(event);"  />
				</div>
				<div class="form-group">
                    <asp:TextBox runat="server" ID="fax" cssClass="form-control" onkeypress="return validatenumerics(event);"  />
				</div>
                <div class="form-group">
                    <asp:DropDownList runat ="server" ID ="gender" CssClass="form-control">
                        <asp:ListItem value = "" meta:resourceKey="gender" selected disabled hidden></asp:ListItem>
                        <asp:ListItem value = "M" meta:resourceKey="male"></asp:ListItem>
                        <asp:ListItem value = "F" meta:resourceKey="female"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate ="gender" Display="Dynamic" meta:resourceKey="genderError" ForeColor="Red"></asp:RequiredFieldValidator>
				</div>
				<div class="checkbox">
					<label>
                        <asp:CheckBox runat="server" ID="acceptCb" meta:resourceKey="accept" />
                        <asp:CustomValidator runat="server" ID ="custCheck" ClientValidationFunction = "ValidateCheckBox" meta:resourceKey="acceptError" ForeColor="Red"></asp:CustomValidator>
					</label>
				</div>
                <asp:Button runat="server" ID="signupBtn" CssClass ="btn btn-block btn-primary"  meta:resourceKey="login" OnClick="signupBtn_Click" />
			</fieldset>
		</form>
	</div>
</div>
</asp:Content>
