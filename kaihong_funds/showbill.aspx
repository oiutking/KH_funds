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
                                        <tr class="heading " ><td>单据预览</td></tr>
                                        <tr><td style=""><div style="min-height:500px">
                                                <embed src="preview.aspx"  style="min-height:500px;width:100%"/>
                                                </div></td></tr>
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
                                            
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="归档" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="返回" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="回退" />
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="结束流程" />
                                            </td></tr>
                                            <tr><td>
                                            <asp:DropDownList runat="server" ID="sigs" AutoPostBack="true"></asp:DropDownList>
                                            <div>
                                            <img src="" style="width:150px;height:150px;border:1px solid #808080;" /> 
                                            <asp:Button runat="server" CssClass="btn btn-primary small" Text="审批通过" />
                                            </div>
                                            
                                            </td></tr>
                                        <tr><td>备注：
                                            <asp:TextBox runat ="server" ID="summary" Rows="6" TextMode="MultiLine" ></asp:TextBox></td></tr>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="content">
                            <div class ="module message">
                                <div class="module-body table">
                                    <table class="table-message table  table-bordered">
                                        <tr class="heading " ><td>审批详情</td></tr>
                                        <tr><td>123</td></tr>
                                        <tr><td>123</td></tr>
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
