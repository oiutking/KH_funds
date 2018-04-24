<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="kaihong_funds.index1" %>
<%@ Register Src="~/publicHTML/headbar.ascx" TagPrefix="uc1" TagName="headbar" %>
<%@ Register Src="~/publicHTML/menu.ascx" TagPrefix="uc1" TagName="menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                            <div class="btn-controls">
                                <div class="btn-box-row row-fluid">
                                    <a href="#" class="btn-box big span4"><i class="  icon-money"></i><b><asp:Label runat="server" ID="sz_lab"></asp:Label></b>
                                        <p class="text-muted">本月收支
                                            </p>
                                    </a><a href="showMstate.aspx" class="btn-box big span4"><i class="icon-adjust"></i><b><asp:Label runat="server" ID="yj_lab"></asp:Label></b>
                                        <p class="text-muted">
                                         月结信息   </p>
                                    </a><a href="#" class="btn-box big span4"><i class="icon-bullhorn"></i><b><asp:Label runat="server" ID="dbsx_lal"></asp:Label></b>
                                        <p class="text-muted">待办事项
                                            </p>
                                    </a>
                                </div>
                                <div class="btn-box-row row-fluid">

                                     <div class="span8">
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <a href="#" class="btn-box small span4"><i class="icon-signin"></i><b>本月收入：<asp:Label runat="server" ID="bysr_lab"></asp:Label></b>
                                                </a><a href="#" class="btn-box small span4"><i class="icon-signout"></i><b>本月支出：<asp:Label runat="server" ID="byzc_lab"></asp:Label><asp:Label runat="server" ID="Label2"></asp:Label></b>
                                                </a><a href="#" class="btn-box small span4"><i class="icon-exchange"></i><b>在用账户：<asp:Label runat="server" ID="zyzh_lab"></asp:Label></b>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <a href="#" class="btn-box small span4"><i class="icon-table"></i><b>往来单位：<asp:Label runat="server" ID="wldw_lab"></asp:Label></b>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                                                        <ul class="widget widget-usage unstyled span4">
                                        <li>
                                            <p>
                                              <a href="showfiled.aspx"  ><strong>可打印票据</strong> <span class="pull-right small muted"><asp:Label runat="server" ID="dy_lab"></asp:Label></span></a>
                                            </p>
                                            <div class="progress tight">
                                                <asp:Label runat="server" ID="dy_img"></asp:Label>
                                            </div>
                                        </li>
                                        <li>
                                            <p>
                                                <a href="review.aspx"> <strong>待审批事项</strong> <span class="pull-right small muted"><asp:Label runat="server" ID="sp_lab"></asp:Label></span></a>
                                            </p>
                                            <div class="progress tight">
                                                <asp:Label runat="server" ID="sp_img"></asp:Label>
                                            </div>
                                        </li>
                                        <li>
                                            <p>
                                                <a href="review.aspx"> <strong>可归档</strong> <span class="pull-right small muted"><asp:Label runat="server" ID="gd_lab"></asp:Label></span></a>
                                            </p>
                                            <div class="progress tight">
                                                <asp:Label runat="server" ID="gd_img"></asp:Label>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <!--/#btn-controls-->
                                                    
                            <!--/.module-->
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
