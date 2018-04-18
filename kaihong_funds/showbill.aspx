<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showbill.aspx.cs" Inherits="kaihong_funds.showbill" %>
<%@ Register Src="~/publicHTML/headbar.ascx" TagPrefix="uc1" TagName="headbar" %>

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
                    <div class="span9">
                        <div class="content">
                            <div class ="module message">
                                <div class="module-body table">
                                    <table class="table-message table  table-bordered">
                                        <tr class="heading " ><td>单据信息</td></tr>
                                        <tr><td style="">
                                            <div runat="server" id="ZP" class="form-horizontal row-fluid">
                                            <div class="control-group">
                                            <span class="help-inline">
											付款单位:<asp:Label runat="server" ID="zp_fkdw"></asp:Label>
                                            </span>
											</div>
                                            <div class="control-group">
											<span class="help-inline">付款账号：<asp:Label runat="server" ID="zp_fkzh"></asp:Label></span>
										    </div>
                                            <div class="control-group">
											<span class="help-inline">收款单位：<asp:Label runat="server" ID="zp_skdw"></asp:Label></span>
										    </div>
                                            <div class="control-group">
											<span class="help-inline">收款账号：<asp:Label runat="server" ID="zp_skzh"></asp:Label></span>
										    </div>
                                            <div class="control-group">
                                            <span class="help-inline">票面金额：<asp:Label runat="server" ID="zp_amount"></asp:Label></span>
										    </div>
                                            <div class="control-group">
											<span class="help-inline">开票人：<asp:Label runat="server" ID="zp_maker"></asp:Label></span>
										    </div>
                                            <div class="control-group">
                                            <span class="help-inline">开票时间：<asp:Label runat="server" ID="zp_kprq"></asp:Label></span>
										    </div>
                                            </div>
                                            <div runat="server" id="CD" class="form-horizontal row-fluid">

											<div class="control-group">
											<span class="help-inline"> 存款单位：<asp:Label runat="server" ID="cd_ckdw"></asp:Label></span>
                                            </div>
                                            <div class="control-group">
                                            <span class="help-inline">存款账号： <asp:Label runat="server" ID="cd_ckzh"></asp:Label> </span>
                                            </div>
                                            <div class="control-group">
											<span class="help-inline">票面金额：<asp:Label runat="server" ID="cd_amount"></asp:Label> </span>
										    </div>
                                            <div class="control-group">
											<span class="help-inline">开票人：<asp:Label runat="server" ID="cd_maker"></asp:Label> </span>
										    </div>
                                            <div class="control-group">
											<span class="help-inline">开票日期：<asp:Label runat="server" ID="cd_kpsj"></asp:Label> </span>
										    </div>
                                            </div>
                                            </td></tr>
                                    </table>
                                    <table class="table-message table  table-bordered">
                                        <tr class="heading " ><td>审批信息</td></tr>
                                        <tr><td style="">

                                            </td></tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                   
                    <!--mainbody begin-->
                    <div class="span3">
                        <div class="content">
                            <div class ="module message">
                                <div class="module-body table">
                                    <table class="table-message table  table-bordered">
                                        <tr class="heading " ><td>操作</td></tr>
                                        <tr><td>
                                            
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="归档" ID="filed" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="返回" ID="pageback" OnClick="Unnamed_Click" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="回退" ID="flowback" OnClick="Unnamed_Click1" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="结束流程" ID="flowend" />
                                            </td></tr>
                                            <tr><td>
                                            <asp:DropDownList runat="server" ID="sigs" AutoPostBack="true" OnSelectedIndexChanged="sigs_SelectedIndexChanged"></asp:DropDownList>
                                            <div>
                                            <asp:Image ID="img" runat="server" Width="150" Height="150" BorderColor="Black" BorderStyle="Inset" BorderWidth="1"/>
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="审批通过" OnClick="Unnamed_Click2" ID="saveop"/>
                                            </div>
                                            
                                            </td></tr>
                                        <tr><td>备注：
                                            <asp:TextBox runat ="server" ID="summary" Rows="6" TextMode="MultiLine" ></asp:TextBox></td></tr>
                                    </table>
                                </div>
                            </div>
                        </div>

                      </div>
                    <!--mainbody end-->
                </div>
            </div>
        </div>


        <!--insert footer begin-->
        <!--#include file="publicHTML/footer.aspx"-->
        <!--insert footer end-->
    </form>
</body>
</html>
