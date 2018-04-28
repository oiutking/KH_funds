<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review.aspx.cs" Inherits="kaihong_funds.review" %>
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

                   
                    <!--mainbody begin-->
                    <div class="span9">
                        <div class="content">
                            <div class="module message" >
                                <div class="module-head">                                    
                                    <h3 >
                                      <asp:Label ID="ymbt" runat="server" Text="票据列表"></asp:Label> 
                                      <span class="pull-right">
                                          <asp:Button runat="server" Text="条件查询" CssClass="btn-primary btn" id="show_sear_btn" OnClick ="show_sear_btn_Click"/>
                                          <asp:Button runat="server" Text="恢复列表" CssClass="btn-primary btn" ID="renew_list_btn" OnClick="renew_list_btn_Click" />
                                      </span>  
                                    </h3> 
                                 </div>

                                
                                <div runat="server" id="search_div" class="modal-body form-horizontal row-fluid" visible="false">
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

                                            <div class="control-group">
											    <label class="control-label" for="basicinput">票据金额：</label>
											    <div class="controls">
                                                    <asp:TextBox ID="sear_amount" runat="server" placeholder="单据金额..." CssClass="span8"></asp:TextBox>
											    </div>
										    </div>
                  
                                            <div class="control-group " runat="server" id="ErrDiv" >
											    <label class="control-label span6" for="basicinput">
                                                    <asp:Label runat="server" ID="ErrStr" Text ="" ForeColor="#FF3300"></asp:Label>
											    </label>
										    </div>
                                            <div class="control-group ">
                                                <div class="controls pull-right span6">
                                                <asp:Button runat="server" Text="返回" ID="back_btn"  class="btn-primary btn" OnClick="back_btn_Click"/>
											    <asp:Button runat="server" Text="查询" ID="search_btn"   class="btn-primary btn" OnClick="search_btn_Click"/>
                                                </div>
										    </div>
                                </div>

                                <div runat="server" id="list_tab">
                                <div class="module-body table" >                                    
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-message">
                                                        <tbody>
                                                            <tr class="heading">
                                                                <td class="span4">
                                                                 单位信息
                                                                </td>
                                                                <td class="cell-icon">
                                                                 类别
                                                                </td>
                                                                <td class="sapn5">
                                                                 详情
                                                                </td>
                                                                <td class="cell-time">
                                                                当前环节
                                                                </td>
                                                                <td class="span2">
                                                                操作
                                                                </td>
                                                            </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="unread">
                                                            <td class="span3">
                                                                 <%#(Eval("dep_name").ToString()).Length>20?(Eval("dep_name").ToString()).Substring(0,20)+"...":Eval("dep_name").ToString() %>
                                                                </br>
                                                                开户行：<%#Eval("no_name") %><br/>
                                                                账号：<%#Eval("no") %>
                                                                </td>
                                                                <td class="cell-icon">
                                                                 <%#Eval("bill_type").ToString()=="1"?"存单":"支票" %>
                                                                </td>
                                                                <td class="sapn6">
                                                                 金额：<%#Eval("Amount") %>
                                                               
                                                                 <%#Eval("bill_type").ToString()=="2"?"</br> 收款单位："+Eval("edep_name"):"" %>
                                                                 <%#Eval("bill_type").ToString()=="2"?"</br> 收款账号："+Eval("edep_no"):"" %>                                                                    
                                                                </td>
                                                                <td class="cell-icon">
                                                                <%#Eval("op").ToString()=="5"?"待归档":""+Eval("op")+"审" %>
                                                                </td>
                                                                <td class="span2 ">
                                                                <asp:Button runat="server" CommandArgument=<%#Eval("bill_id") %> Text="删除" Enabled=<%#Eval("op").ToString()=="1"?true:false %> CssClass="btn-danger btn" OnClick="Unnamed_Click" />
                                                                <asp:Button runat="server" CommandArgument=<%#Eval("bill_id")%> Text="查看" CssClass="btn-success btn"  OnClick="Unnamed_Click1"/>
                                                                </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                                  </table>    
                                                </FooterTemplate>
                                            </asp:Repeater>       
                                </div>

                                <div class="module-foot clearfix">
                                    <asp:Button runat="server" CssClass="btn-primary btn small" Text="首页" id="start" OnClick="start_Click"/>
                                    <asp:Button runat="server" CssClass="btn-primary btn small" Text="上一页" ID="goback" OnClick="goback_Click" />
                                    <asp:Label runat="server" ID="front" Visible="false">...</asp:Label>
                                        <asp:Repeater runat="server" ID="pagestr">
                                            <ItemTemplate>
                                            <asp:Button runat="server" CssClass=<%#Container.DataItem.ToString()==hide.Value?"btn-danger btn samll":"btn-primary btn small" %> Text="<%#Container.DataItem%>" ID="pageno" OnClick="pageno_Click"/>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    <asp:Label runat="server" ID="back" Visible="false">...</asp:Label>
                                    <asp:Button runat="server" CssClass="btn-primary btn small" Text="下一页" id="next" OnClick="next_Click"/>
                                    <asp:Button runat="server" CssClass="btn-primary btn small" Text="尾页" ID="end" OnClick="end_Click"/>
                                    <asp:HiddenField runat="server" ID="hide" Value="1" />
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
        <script src="scripts/myAlert.js" type="text/javascript"></script>

    </form>
</body>
</html>
