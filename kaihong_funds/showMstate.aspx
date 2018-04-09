<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showMstate.aspx.cs" Inherits="kaihong_funds.showMstate" %>
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
								<h3>查看月结</h3>
							</div>
							<div class="module-body">
									   <div class="form-horizontal row-fluid">
										   

										<div class="control-group">
											<label class="control-label" for="basicinput">选择年度</label>
											<div class="controls">
                                                <asp:DropDownList runat="server" ID="years" AutoPostBack="true" OnSelectedIndexChanged="years_SelectedIndexChanged"></asp:DropDownList>
                                                <span class="help-inline">
                                                  </span>
											</div>
										</div> 
                                       <div class="control-group">
											
                                               <table class="table">
								                  <thead>
									                <tr>
									                  <th>账号</th>
									                  <th>账期</th>
									                  <th>期初余额</th>
									                  <th>本期收入</th>
                                                      <th>本期支出</th>
                                                      <th>期末余额</th>
									                </tr>
								                  </thead>
                                                  <asp:Repeater runat="server" ID="m_info">
                                                      <ItemTemplate>
                                                          <tr>
                                                              <td><%#Eval("no") %></td>
                                                              <td><%#Convert.ToDateTime(Eval("ms_date")).Year+"年"+Convert.ToDateTime(Eval("ms_date")).Month+"月" %></td>
                                                              <td><%#Eval("qcye") %></td>
                                                              <td><%#Eval("bqsr") %></td>
                                                              <td><%#Eval("bqzc") %></td>
                                                              <td><%#Eval("qmye") %></td>
                                                          </tr>
                                                      </ItemTemplate>
                                                  </asp:Repeater>
                                              </table>            
                                            <span class="help-inline">
                                            </span>
											
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
    </form>
</body>
</html>
