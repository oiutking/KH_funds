<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sigadmin.aspx.cs" Inherits="kaihong_funds.sigadmin" %>
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
								<h3>印章管理</h3>
							</div>
							<div class="module-body">
									   <div class="form-horizontal row-fluid">
										   

										<div class="control-group">
											<label class="control-label" for="basicinput">印章列表</label>
											<div class="controls">
                                                <asp:ListBox runat="server" ID="sig_list" CssClass="span8" Rows="9"></asp:ListBox>
                                                <img src="" style="width:150px;height:150px;border:1px solid #808080;" /> 
                                                <span class="help-inline">
                                                  </span>
											</div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">查找印章</label>
											<div class="controls">
                                                <asp:TextBox ID="TextBox1" runat="server"  CssClass="span8"></asp:TextBox>
                                              
                                               
                                                <span class="help-inline">
                                                    <asp:Button ID="Button1" runat="server" Text="查找印章" CssClass="btn-primary btn" /></span>
											</div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">所属单位</label>
											<div class="controls">
                                                <asp:TextBox ID="payto_search_txt" runat="server"  CssClass="span8" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="payto_saerch_list" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline">
                                                    <asp:Button ID="search_btn" runat="server" Text="查找单位" CssClass="btn-primary btn"  /></span>
											</div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">印章状态</label>
											<div class="controls">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline"></span>
                                            </div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">印章类型</label>
											<div class="controls">
                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline"></span>
                                            </div>
										</div>                                        
                                        <div class="control-group">
											<label class="control-label" for="basicinput">授权级别</label>
											<div class="controls">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline"></span>
                                            </div>
										</div>     	
                                        <div class="control-group">
											<label class="control-label" for="basicinput"></label>
											<div class="controls">
                                               <asp:Button runat="server" ID="save" Text="保存修改" CssClass=" btn btn-primary" />
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
