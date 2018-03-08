<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="kaihong_funds.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<title>货币资金管理系统</title>
	<link type="text/css" href="bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
	<link type="text/css" href="bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet"/>
	<link type="text/css" href="css/theme.css" rel="stylesheet"/>
	<link type="text/css" href="images/icons/css/font-awesome.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
<div class="navbar navbar-fixed-top">
		<div class="navbar-inner">
			<div class="container">
				<a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-inverse-collapse">
					<i class="icon-reorder shaded"></i>
				</a>

			  	<a class="brand" href="login.aspx">
			  		货币资金管理系统
			  	</a>

				<div class="nav-collapse collapse navbar-inverse-collapse">
				
					<ul class="nav pull-right">					

						<li><a href="#">
							忘记密码?
						</a></li>
					</ul>
				</div><!-- /.nav-collapse -->
			</div>
		</div><!-- /navbar-inner -->
	</div><!-- /navbar -->



	<div class="wrapper">
		<div class="container">
			<div class="row">
				<div class="module module-login span4 offset4">
					
						<div class="module-head">
							<h3>登录系统</h3>
						</div>
						<div class="module-body">
							<div class="control-group">
								<div class="controls row-fluid">
                                    <asp:TextBox ID="uer_no" runat="server" class="span12"  placeholder="请输入工号"></asp:TextBox>
								</div>
							</div>
							<div class="control-group">
								<div class="controls row-fluid">
							    <asp:TextBox ID="uer_psw" runat="server" class="span12 "  placeholder="请输入密码" TextMode="Password"></asp:TextBox>
								</div>
							</div>
                            <div class="control-group">
								<div class="controls row-fluid">
                                    <div class="span3 ">
                                    <asp:ImageButton ID="Valcode" runat="server" ImageUrl="ValCode.aspx" OnClick="Valcode_Click"  />
                                    </div>
                                    <asp:TextBox ID="valcode_input" runat="server" class="span9  pull-right"  placeholder="请输入验证码" OnTextChanged="TextBox2_TextChanged" MaxLength="4"></asp:TextBox>
								</div>
							</div>
						</div>
						<div class="module-foot">
							<div class="control-group">
								<div class="controls clearfix">									
                                    <asp:Button ID="ok" runat="server" Text="登录" class="btn btn-primary pull-right" OnClick="ok_Click" />
                                    <asp:Label ID="warning" runat="server" Text="" ForeColor="#FF4D4D"></asp:Label>
								</div>

							</div>
						</div>

				</div>
			</div>
		</div>
	</div><!--/.wrapper-->

	<div class="footer">
		<div class="container">
			 

			<b class="copyright">&copy; 2018 Edmin - EGrappler.com </b> All rights reserved.
		</div>
	</div>
	<script src="scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
	<script src="scripts/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
	<script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    </form>
</body>
</html>
