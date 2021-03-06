﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminKEY.aspx.cs" Inherits="kaihong_funds.AdminKEY" %>
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
								<h3>KEY管理</h3>
							</div>
							<div class="module-body">
									   <div class="form-horizontal row-fluid">
										   

										<div class="control-group">
											<label class="control-label" for="basicinput">Key列表</label>
											<div class="controls">
                                                <asp:ListBox runat="server" ID="KEY_list" CssClass="span8" Rows="5" AutoPostBack="true" OnSelectedIndexChanged="KEY_list_SelectedIndexChanged"></asp:ListBox>
                                                <span class="help-inline">
                                                  </span>
											</div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">查找Key</label>
											<div class="controls">
                                                <asp:TextBox ID="key_name_txtb" runat="server"  CssClass="span8"></asp:TextBox>
                                                <span class="help-inline">
                                                    <asp:Button ID="search_text_btn" runat="server" Text="查找Key" CssClass="btn-primary btn" OnClick="search_text_btn_Click" />
                                                                                      </span>
											</div>
										</div>

                                        <div class="control-group">
											<label class="control-label" for="basicinput">KEY状态</label>
											<div class="controls">
                                                <asp:DropDownList ID="state" runat="server" CssClass="span8">
                                                    <asp:ListItem Value="1">启用</asp:ListItem>
                                                    <asp:ListItem Value="0">停用</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="help-inline"></span>
                                            </div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">绑定用户</label>
											<div class="controls">
                                                <asp:ListBox runat="server" ID="u_list" CssClass="span8" Rows="5" AutoPostBack="true" ></asp:ListBox>

                                                <span class="help-inline "></span>
                                            </div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">查找用户</label>
											<div class="controls">
                                                <asp:TextBox ID="ser_uer_txt" runat="server"  CssClass="span8"></asp:TextBox>
                                                <span class="help-inline">
                                                    <asp:Button ID="ser_uer_btn" runat="server" Text="查找用户" CssClass="btn-primary btn" OnClick="ser_uer_btn_Click"/>
                                                                                      </span>
											</div>
										</div>     	
                                        <div class="control-group">
											<label class="control-label" for="basicinput"></label>
											<div class="controls">
                                               <asp:Button runat="server" ID="save" Text="保存修改" CssClass=" btn btn-primary" OnClick="save_Click"/>
                                                <span class="help-inline"></span>
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
    </form>
</body>
</html>
