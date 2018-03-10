<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="excdep.aspx.cs" Inherits="kaihong_funds.excdep" %>
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
                            <div class="module message">
                                <div class="module-head">
                                    <h3>
                                        往来单位管理
                                    </h3>
                                </div>
                                <div class="module-option clearfix">
                                    <div class="pull-left">
                                        
                                        <div class="pull-left span3"><asp:TextBox ID="search" runat="server" placeholder="请输入单位名称" class="span3" ></asp:TextBox></div>
                                        <div class="pull-left"><asp:Button ID="Button1" runat="server" Text="查询"  class="btn btn-primary"/></div>    
                                    </div>
                                    <div class="pull-right">

                                        <a href="#" class="btn btn-primary">新建单位</a>
                                    </div>
                                </div>
                                <div class="module-body table">
                                    
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-message">
                                                        <tbody>
                                                            <tr class="heading">
                                                                <td class="span3">
                                                                 单位名称
                                                                </td>
                                                                <td class="sapn5">
                                                                 详细情况
                                                                </td>
                                                                <td class="cell-icon hidden-phone hidden-tablet">
                                                                状态
                                                                </td>
                                                                <td class="cell-time align-right">
                                                                操作
                                                                </td>
                                                            </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="unread">
                                                        <td class="span3">
                                                            <%#Eval("edep_name") %>
                                                        </td>

                                                        <td class="sapn5">
                                                            账号：<%#Eval("edep_no") %>
                                                            <br/>
                                                            说明：<%#Eval("summary") %>
                                                        </td>
                                                        <td class="cell-icon hidden-phone hidden-tablet">
                                                            <%#Eval("state").ToString()=="True"?"启用":"停用"%>
                                                        </td>
                                                        <td class="cell-time align-right">
                                                            <asp:Button ID="stop" runat="server" OnCommand ="stop_Command" CommandArgument=<%#Eval("edep_id") %> Text=<%#Eval("state").ToString()=="True"?"停用":"启用"%> cssClass=<%#Eval("state").ToString()=="True"?"btn-danger":"btn-success"%>  />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                                  </table>    
                                                </FooterTemplate>
                                            </asp:Repeater>       
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
