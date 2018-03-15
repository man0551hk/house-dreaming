<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/agency/AgentMasterPage.master"  CodeFile="ChangePassword.aspx.cs" Inherits="agency_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="login-panel panel panel-default">
		<div class="panel-heading">
            <asp:Literal ID="Literal7" runat = "server" meta:resourceKey="heading" ></asp:Literal>
		</div>
		<div class="panel-body">
            <div runat="server" id="successForm">
                <asp:Literal ID="Literal1" runat = "server" meta:resourceKey="successPassword" ></asp:Literal>
            </div>

			<form id="form1" runat="server" role="form">
				<fieldset>
					<div class="form-group">
                        <asp:TextBox runat="server" ID="oldPassword" type="password" autofocus=""  class="form-control" />
                        <asp:RequiredFieldValidator runat ="server" ID="validator1" ControlToValidate="oldPassword"
                            ForeColor ="Red" Display="Dynamic" meta:resourceKey="passwordError"></asp:RequiredFieldValidator>
					</div>
					<div class="form-group">
                        <asp:TextBox runat="server" ID="newPassword" type="password" class="form-control" MaxLength="12" />
                        <asp:RequiredFieldValidator runat ="server" ID="RequiredFieldValidator1" ControlToValidate="newPassword"
                            ForeColor ="Red" Display="Dynamic" meta:resourceKey="newPasswordError"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valPassword" runat="server"
                           ControlToValidate="newPassword" meta:resourceKey="passwordLengthError"
                           ValidationExpression=".{8}.*" ForeColor ="Red"  />
					</div>
					<div class="form-group">
                        <asp:TextBox runat="server" ID="confirmPassword" type="password" autofocus=""  class="form-control" MaxLength="12" />
                        <asp:CompareValidator ID="compareValidator1" runat="server"
                            ControlToValidate="newPassword" 
                            ControlToCompare="confirmPassword" ForeColor ="Red" 
                            Type="String" meta:resourceKey="confirmPasswordError"></asp:CompareValidator>
					</div>
                    <asp:Button runat="server" ID="confirmBtn" CssClass ="btn btn-primary" meta:resourceKey="confirmBtn" OnClick="confirmBtn_Click"/>
				</fieldset>
			</form>
		</div>
	</div>
</asp:Content>
