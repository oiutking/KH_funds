<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showcount.aspx.cs" Inherits="kaihong_funds.showcount" %>
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

                   
                    <!--mainbody begin-->
                    <div class="span9">
                        <div class="content">
                            <div class="module message" >
                                <div class="module-head">                                    
                                    <h3 >
                                      查询统计
                                    </h3> 
                                 </div>

                                
                                <div class="modal-body form-horizontal row-fluid" >
											<div class="control-group">
											<label class="control-label" for="basicinput">付款单位：</label>
											<div class="controls">
                                                <asp:TextBox ID="sear_dep_txt" runat="server"  CssClass="span8" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="dep_list" runat="server" CssClass="span8" OnTextChanged="dep_list_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                                <span class="help-inline">
                                                <asp:Button ID="sear_dep_btn" runat="server" Text="查找" CssClass="btn-primary btn" OnClick="sear_dep_btn_Click" /></span>
											</div>
										    </div>

                                            <div class="control-group">
											<label class="control-label" for="basicinput">起止时间：</label>
											<div class="controls">
                                                <asp:Button ID="Button1" runat="server" Text="选择开始时间" CssClass="btn btn-primary" OnClick="Button1_Click"/> <asp:TextBox ID="str_date_s" runat="server" ReadOnly="true" Visible="false" CssClass="span2"></asp:TextBox><asp:Calendar runat="server" ID="date_s" Visible="false" OnSelectionChanged="date_s_SelectionChanged" ></asp:Calendar> 至 
                                                <asp:Button ID="Button2" runat="server" Text="选择开始时间" CssClass="btn btn-primary" OnClick="Button2_Click"/> <asp:TextBox ID="str_date_e" runat="server" ReadOnly="true" Visible="false"  CssClass="span2"></asp:TextBox><asp:Calendar runat="server" ID="date_e" Visible="false" OnSelectionChanged="date_e_SelectionChanged" ></asp:Calendar>
                                             </div>
										    </div>

                                            <div class="control-group">
											<label class="control-label" for="basicinput">票据类型：</label>
											<div class="controls">
                                                <asp:DropDownList ID="bill_type" runat="server" CssClass="span8" >
                                                    <asp:ListItem Selected="True" Value="0">全部类型</asp:ListItem>
                                                    <asp:ListItem Value="1">存单</asp:ListItem>
                                                    <asp:ListItem Value="2">支票</asp:ListItem>
                                                </asp:DropDownList>
                                             </div>
										    </div>
                                    
                                            <div class="control-group">
											<label class="control-label" for="basicinput">付款账号：</label>
											<div class="controls">
                                                <asp:TextBox ID="sear_payfrom_no_txt" runat="server"  CssClass="span8" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="sear_payfrom_no_list" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline">
                                                    <asp:Button ID="sear_payfrom_no_btn" runat="server" Text="查找" CssClass="btn-primary btn" OnClick="sear_payfrom_no_btn_Click"/></span>
											</div>
										    </div>

                                            <div class="control-group">
											<label class="control-label" for="basicinput">收款单位：</label>
											<div class="controls">
                                                <asp:TextBox ID="sear_exc_dep_txt" runat="server"  CssClass="span8" Visible="false"></asp:TextBox>
                                                <asp:DropDownList ID="sear_exc_dep_list" runat="server" CssClass="span8" ></asp:DropDownList>
                                                <span class="help-inline">
                                                <asp:Button ID="sear_exc_dep_btn" runat="server" Text="查找" CssClass="btn-primary btn" OnClick="sear_exc_dep_btn_Click"/></span>
											</div>
										    </div>
                
                                            <div class="control-group ">
                                                <div class="controls pull-right span6">
                                                
											    <asp:Button runat="server" Text="查询明细" ID="search_btn"   class="btn-primary btn" OnClick="search_btn_Click"/>
                                                </div>
										    </div>
                                </div>
                             </div>
                        </div>
                        <!--/.content-->
                    </div>
                    <!--mainbody end-->
                </div>
            </div>
        </div>


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
