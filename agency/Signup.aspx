<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="agency_signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>House Dreaming Agency Login</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/datepicker3.css" rel="stylesheet">
	<link href="css/styles.css" rel="stylesheet">
	<!--[if lt IE 9]>
	<script src="js/html5shiv.js"></script>
	<script src="js/respond.min.js"></script>
	<![endif]-->

    <script type="text/javascript" language="javascript">
        function validatenumerics(key) {
            var keycode = (key.which) ? key.which : key.keyCode;
            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                return false;
            }
            else return true;
        }
    </script>
</head>
<body>
    
	<div class="row">
		<div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
            <a href ="/"><img src = "../images/logo.png" /></a>
            
			<div class="login-panel panel panel-default">
				<div class="panel-heading">
                     <asp:Literal ID="Literal7" runat = "server" meta:resourceKey="heading"></asp:Literal>
				</div>
				<div class="panel-body">
                    <div runat="server" id ="thanks">
                        <b><asp:Literal ID="Literal1" runat = "server" meta:resourceKey="thanks"></asp:Literal></b>
                    </div>
					<form id="form1" runat="server" role="form">
						<fieldset>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="companyName" cssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate ="companyName" Display="Dynamic" meta:resourceKey="companyNameError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
                           <div class="form-group">
                                <asp:TextBox runat="server" ID="companyLicense" cssClass="form-control" />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate ="companyLicense" Display="Dynamic" meta:resourceKey="companyLicenseError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="agentNameEn" cssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate ="agentNameEn" Display="Dynamic" meta:resourceKey="agentNameEnError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="agentNameTc" cssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate ="agentNameTc" Display="Dynamic" meta:resourceKey="agentNameEnError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="agentLicense" cssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate ="agentLicense" Display="Dynamic" meta:resourceKey="agentLicenseError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="email" type="email" cssClass="form-control" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate ="email" Display="Dynamic" meta:resourceKey="emailEmpty" ForeColor="Red"></asp:RequiredFieldValidator>
                               
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="mobile" cssClass="form-control" onkeypress="return validatenumerics(event);"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate ="mobile" Display="Dynamic" meta:resourceKey="mobileError" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate ="gender" Display="Dynamic" meta:resourceKey="genderError" ForeColor="Red"></asp:RequiredFieldValidator>
							</div>
                            <asp:Button runat="server" ID="signupBtn" CssClass ="btn btn-block btn-primary"  meta:resourceKey="login" OnClick="signupBtn_Click" />
						</fieldset>
					</form>
				</div>
			</div>
           
		</div><!-- /.col-->
	</div><!-- /.row -->	
    <script src="js/jquery-1.11.1.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
</body>
</html>
