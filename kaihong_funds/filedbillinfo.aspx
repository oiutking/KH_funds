<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filedbillinfo.aspx.cs" Inherits="kaihong_funds.filedbillinfo" %>
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
                        <div class="span12">
                        <div class="content">
                            <div class ="module message">
                                <div class="module-body table">
                                    <table class="table table-bordered">
                                    <thead>
									<tr>
									  <th>操作</th>
									</tr>
								    </thead>
                                        <tr>
                                            <td>
                                            <asp:Button runat="server" Text="返回" CssClass="btn btn-primary" ID="back" OnClick="back_Click" />
									        <asp:Button runat="server" Text="打印"  CssClass="btn btn-primary" ID="print" OnClick="print_Click"/>
									        <asp:Button runat="server" Text="刷新"  CssClass="btn btn-primary" ID="ref"  OnClick="ref_Click"/>

                                            </td>
                                        </tr>
                                  </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <div class="span12">
                        <div class="content">
                            <div class ="module message">
                                <div class="module-body table ">
                                    <table class="table table table-bordered ">
                                        <thead>
									<tr>
									  <th>票据信息</th>
									</tr>
								  </thead>
                                        <tr><td style="">
                                            <div runat="server" id="ZP" class="">
                                            <div class="control-group  span8  ">票据编号：
                                            <span class="help-inline">
											<asp:Label runat="server" ID="zp_pjbh"></asp:Label>
                                            </span>
											</div>
                                            <div class="control-group  span8 ">付款单位：
                                            <span class="help-inline">
											<asp:Label runat="server" ID="zp_fkdw"></asp:Label>
                                            </span>
											</div>
                                            <div class="control-group  span8 ">付款账号：
											<span class="help-inline"><asp:Label runat="server" ID="zp_fkzh"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">收款单位：
											<span class="help-inline"><asp:Label runat="server" ID="zp_skdw"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">收款账号：
											<span class="help-inline"><asp:Label runat="server" ID="zp_skzh"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">票面金额：
                                            <span class="help-inline"><asp:Label runat="server" ID="zp_amount"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">开票人：
											<span class="help-inline"><asp:Label runat="server" ID="zp_maker"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">记账日期：
                                            <span class="help-inline"><asp:Label runat="server" ID="zp_jzrq"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">开票日期：
                                            <span class="help-inline"><asp:Label runat="server" ID="zp_kprq"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 ">备注：
                                            <span class="help-inline"><asp:Label runat="server" ID="zp_bz"></asp:Label></span>
										    </div>
                                            <div class="control-group  span8 span8 ">打印次数：
                                            <span class="help-inline"><asp:Label runat="server" ID="zp_dycs"></asp:Label></span>
                                            </div>
                                            </div>
                                            <div runat="server" id="CD" class="">
											<div class="control-group  span8 ">票据编号：
											<span class="help-inline"> <asp:Label runat="server" ID="cd_pjbh"></asp:Label></span>
                                            </div>
											<div class="control-group  span8 ">存款单位：
											<span class="help-inline"> <asp:Label runat="server" ID="cd_ckdw"></asp:Label></span>
                                            </div>
                                            <div class="control-group  span8 ">存款账号：
                                            <span class="help-inline"> <asp:Label runat="server" ID="cd_ckzh"></asp:Label> </span>
                                            </div>
                                            <div class="control-group  span8 ">票面金额：
											<span class="help-inline"><asp:Label runat="server" ID="cd_amount"></asp:Label> </span>
										    </div>
                                            <div class="control-group  span8 ">开票人：
											<span class="help-inline"><asp:Label runat="server" ID="cd_maker"></asp:Label> </span>
										    </div>
                                            <div class="control-group  span8 ">记账日期：
											<span class="help-inline"><asp:Label runat="server" ID="cd_jzrq"></asp:Label> </span>
										    </div>
                                            <div class="control-group  span8 ">开票日期：
											<span class="help-inline"><asp:Label runat="server" ID="cd_kpsj"></asp:Label> </span>
										    </div>
                                            <div class="control-group  span8 ">备注：
											<span class="help-inline"><asp:Label runat="server" ID="cd_bz"></asp:Label> </span>
										    </div>
                                            <div class="control-group  span8 ">打印次数：
                                            <span class="help-inline"><asp:Label runat="server" ID="cd_dycs"></asp:Label></span>
                                            </div>
                                            </div>
                                            </td></tr>
                                    </table>
                                    
                                    
                                </div>
                            </div>
                        </div>
                    </div>




                </div>
            </div>
        </div>


        <!--insert footer begin-->
        <!--#include file="publicHTML/footer.aspx"-->
        <!--insert footer end-->
    </form>
</body>
</html>
