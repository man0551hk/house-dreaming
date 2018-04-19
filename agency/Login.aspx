<%@ Page Language="C#" MasterPageFile="~/agency/AgentMasterPage.master" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="agency_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="login-panel panel panel-default">
		<div class="panel-heading">
            <asp:Literal ID="Literal7" runat = "server" meta:resourceKey="heading"></asp:Literal>
            <b style="float:right;"><a href ="<%=CommonFunc.GetAgencyDomain() %>Signup/"><asp:Literal ID="Literal2" runat = "server" meta:resourceKey="signUp"></asp:Literal></a></b>
		</div>
		<div class="panel-body">
			<form id="form1" runat="server" role="form">
                <div class="alert bg-danger" role="alert" runat="server" id="errorDiv">
                    <em class="fa fa-lg fa-warning">&nbsp;</em> 
                    <asp:Literal runat="server" ID="errorMsg" meta:resourceKey="errorDiv"></asp:Literal>
                </div>
            
				<fieldset>
					<div class="form-group">
                        <asp:TextBox runat="server" ID="email" type="email" autofocus=""  class="form-control" />
                        <asp:RequiredFieldValidator runat ="server" ID="validator1" ControlToValidate="email"
                            ForeColor ="Red" Display="Dynamic" meta:resourceKey="emailError"></asp:RequiredFieldValidator>
					</div>
					<div class="form-group">
                        <asp:TextBox runat="server" ID="password" type="password" autofocus=""  class="form-control" />
                        <asp:RequiredFieldValidator runat ="server" ID="RequiredFieldValidator1" ControlToValidate="password"
                            ForeColor ="Red" Display="Dynamic" meta:resourceKey="passwordError"></asp:RequiredFieldValidator>
					</div>
					<div class="checkbox">
						<label>
                            <asp:CheckBox runat="server" ID="rememberMe"  meta:resourceKey="rememberMe" />
						</label>
					</div>
                    <asp:Button runat="server" ID="loginBtn" CssClass ="btn btn-primary"  meta:resourceKey="login" OnClick="loginBtn_Click" />
                    <a href ="forgetPassword/"><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="forgetPassword"></asp:Literal></a>
				</fieldset>
			</form>
		</div>
	</div>
</asp:Content>
