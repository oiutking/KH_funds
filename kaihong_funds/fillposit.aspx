<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fillposit.aspx.cs" Inherits="kaihong_funds.fillposit" %>
<%@ Register Src="~/publicHTML/headbar.ascx" TagPrefix="uc1" TagName="headbar" %>
<%@ Register Src="~/publicHTML/menu.ascx" TagPrefix="uc1" TagName="menu" %>
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
         <link href="css/myAlert.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!--insert head begin-->
        <uc1:headbar runat="server" id="headbar" />
        <!--insert head end-->
        <div class="wrapper">
            <div class="container">
                <div class="row">
                    <div class="span3">

                         <!--insert menu begin-->                         
                         <uc1:menu runat="server" id="menu" />
                         <!--insert menu end-->
                    </div>
                    <div class="span9">
					<div class="content">

						<div class="module">
							<div class="module-head">
								<h3>填写存单</h3>
							</div>
							<div class="module-body">

									<div class="form-horizontal row-fluid">
										<div class="control-group">
											<label class="control-label" for="basicinput">存款单位</label>
											<div class="controls">
												<asp:TextBox ID="Payfrom" runat="server"  CssClass="span8" ReadOnly="true"></asp:TextBox>
												<span class="help-inline"></span>
											</div>
										</div>

										<div class="control-group">
											<label class="control-label" for="basicinput">存款账号</label>
											<div class="controls">
                                                <asp:TextBox ID="ser_no_txt" runat="server"  CssClass="span8" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="No" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline">
                                                    <asp:Button ID="ser_no" runat="server" Text="查找账号" CssClass="btn-primary btn" OnClick="ser_no_Click" /></span>
											</div>
										</div>

                                        <div class="control-group">
											<label class="control-label" for="basicinput">记账日期</label>
											<div class="controls">
                                                <asp:Button ID="make_date_select_btn" runat="server" Text="选择开票时间" CssClass="btn btn-primary pan2" OnClick="make_date_select_btn_Click" />  &nbsp;
                                                <asp:TextBox runat="server" ID="make_date_txt" CssClass="span6" ReadOnly="true"></asp:TextBox>
                                                <asp:Calendar runat="server" ID="make_date_cale" Visible="false" OnSelectionChanged="make_date_cale_SelectionChanged"></asp:Calendar>
											</div>
										</div>

										<div class="control-group">
											<label class="control-label" for="basicinput">存款金额</label>
											<div class="controls">
												<asp:TextBox runat="server" ID="Amount" CssClass="span8"></asp:TextBox>
											</div>
										</div>

										<div class="control-group">
											<label class="control-label" for="basicinput">说明</label>
											<div class="controls">
												
													<asp:TextBox runat="server" ID="Summary" CssClass="span8" TextMode="MultiLine" Rows="6"></asp:TextBox>     
												
											</div>
										</div>
									
										<div class="control-group">
											<div class="controls span8">
												<asp:Button runat="server" ID="OK" CssClass="btn-primary btn pull-right" Text="保存" OnClick="OK_Click" />
											</div>
										</div>
									</div>
							</div>
						</div>

						
						
					</div><!--/.content-->
				</div><!--/.span9-->
			</div>
		</div><!--/.container-->
	</div><!--/.wrapper-->



        <!--insert footer begin-->
        <!--#include file="publicHTML/footer.aspx"-->
        <!--insert footer end-->

        <script src="scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
        <script src="scripts/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
        <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="scripts/flot/jquery.flot.js" type="text/javascript"></script>
        <script src="scripts/flot/jquery.flot.resize.js" type="text/javascript"></script>
        <script src="scripts/datatables/jquery.dataTables.js" type="text/javascript"></script>
        <script src="scripts/common.js" type="text/javascript"></script>
        <script src="scripts/myAlert.js" type="text/javascript"></script>
    </form>
</body>
</html>
