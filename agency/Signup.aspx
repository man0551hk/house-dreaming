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
</head>
<body>
    
	<div class="row">
		<div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
            <img src = "../images/logo.png" />
            
			<div class="login-panel panel panel-default">
				<div class="panel-heading">
                     <asp:Literal ID="Literal7" runat = "server" meta:resourceKey="heading"></asp:Literal>
				</div>
				<div class="panel-body">
					<form id="form1" runat="server" role="form">
						<fieldset>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="companyName" cssClass="form-control" />
							</div>
                           <div class="form-group">
                                <asp:TextBox runat="server" ID="companyLicense" cssClass="form-control" />
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="agentName" cssClass="form-control" />
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="agentLicense" cssClass="form-control" />
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="email" type="email" cssClass="form-control" />
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="mobile" cssClass="form-control" />
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="officePhone" cssClass="form-control" />
							</div>
							<div class="form-group">
                                <asp:TextBox runat="server" ID="fax" cssClass="form-control" />
							</div>
                            <div class="form-group">
                                <asp:DropDownList runat ="server" ID ="gender" CssClass="form-control">
                                    <asp:ListItem value = "" meta:resourceKey="gender" selected disabled hidden></asp:ListItem>
                                    <asp:ListItem value = "M" meta:resourceKey="male"></asp:ListItem>
                                    <asp:ListItem value = "F" meta:resourceKey="female"></asp:ListItem>
                                </asp:DropDownList>
							</div>
                            <asp:Button runat="server" ID="signupBtn" CssClass ="btn btn-block btn-primary"  meta:resourceKey="login" />
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
