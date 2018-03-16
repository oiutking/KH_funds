<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dep.aspx.cs" Inherits="kaihong_funds.dep" %>
<%@ Register Src="~/publicHTML/headbar.ascx" TagPrefix="uc1" TagName="headbar" %>
<%@ Register Src="~/publicHTML/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                                    <h3>
                                        <asp:Label ID="ymbt" runat="server" Text="Unkown"></asp:Label> 
                                    </h3>
                                </div>
                                <div runat="server" id="new_dep_div" class="modal-body form-horizontal row-fluid">
										<div class="control-group">
											<label class="control-label" for="basicinput">单位名称：</label>
											<div class="controls">
                                                <asp:TextBox ID="no_name" runat="server" placeholder="名称..." CssClass="span6"></asp:TextBox>
												<span class="help-inline">必填项</span>
											</div>
										</div>
                                        <div class="control-group">
											<label class="control-label" for="basicinput">单位账号：</label>
											<div class="controls">
                                                <asp:TextBox ID="no" runat="server" placeholder="账号..." CssClass="span6"></asp:TextBox>
												<span class="help-inline">必填项</span>
											</div>
										</div>
                                        <div class="control-group">
                                    	<label class="control-label" for="basicinput">账号性质：</label>
											<div class="controls">
                                                <asp:TextBox ID="summary" runat="server" placeholder="性质..." CssClass="span6"></asp:TextBox>
												<span class="help-inline">必填项</span>
											</div>
										</div>
                                    	
                                        <div class="control-group " runat="server" id="ErrDiv" >
											<label class="control-label span6" for="basicinput">
                                                <asp:Label runat="server" ID="ErrStr" Text ="" ForeColor="#FF3300"></asp:Label>
											</label>
										</div>
                                        <div class="control-group ">
                                            <div class="controls pull-right span6">
                                            <asp:Button runat="server" Text="取消" ID="cancel" class="btn-danger" OnClick="cancel_Click"/>
                                            <asp:Button runat="server" Text="保存" ID="savenew" class="btn-success" OnClick="savenew_Click"/>

                                            </div>
										</div>
                                
                                </div>
                                <div runat="server" id="list_tab">
                                <div class="module-option clearfix">
                                    <div class="pull-left">
                                        
                                        <div class="pull-left span3"><asp:TextBox ID="search" runat="server" placeholder="账号名称或账号" class="span3" ></asp:TextBox></div>
                                        <div class="pull-left"><asp:Button ID="Button1" runat="server" Text="查询"  class="btn btn-primary " OnClick="Button1_Click"/></div>
                                        <div class="pull-left span1"><asp:Button runat="server" ID="ref" CssClass="btn btn-success"  Text="恢复查看" OnClick="ref_Click" /></div>
                                    </div>
                                    <div class="pull-right">
                                        <asp:Button ID="newdep" runat="server" Text="新建账号"  OnClick="newdep_Click" CssClass="btn btn-primary" />
                                        
                                    </div>
                                </div>
                                <div class="module-body table" >                                    
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-message">
                                                        <tbody>
                                                            <tr class="heading">
                                                                <td class="span4">
                                                                 账号名称
                                                                </td>
                                                                <td class="sapn4">
                                                                 账号
                                                                </td>
                                                                <td class="sapn3">
                                                                 账号性质
                                                                </td>
                                                                <td class="cell-time">
                                                                状态
                                                                </td>
                                                                <td class="cell-time align-right">
                                                                操作
                                                                </td>
                                                            </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="unread">
                                                        <td class="span4">
                                                            <%#Eval("no_name") %>
                                                        </td>

                                                        <td class="sapn4">
                                                           <%#Eval("no") %>

                                                        </td>
                                                        
                                                        <td class="sapn3">
                                                           <%#Eval("summary") %>
                                                        </td>

                                                        <td class="cell-time">
                                                            <%#Eval("state").ToString()=="True"?"启用":"停用"%>
                                                        </td>
                                                        <td class="cell-time align-right">
                                                            <asp:Button ID="stop" OnClick="stop_Click" runat="server" CommandArgument=<%#Eval("no_id") %> Text=<%#Eval("state").ToString()=="True"?"停用":"启用"%> cssClass=<%#Eval("state").ToString()=="True"?"btn-danger":"btn-success"%>  />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                                  </table>    
                                                </FooterTemplate>
                                            </asp:Repeater>       
                                </div>
                                </div>
                                <div class="module-foot">
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
