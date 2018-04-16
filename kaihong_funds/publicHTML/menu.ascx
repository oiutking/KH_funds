<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="kaihong_funds.publicHTML.menu" %>
<div class="sidebar">
    <ul class="widget widget-menu unstyled">
        <li class="active">
            <a href="index.aspx">
                <i class="menu-icon icon-dashboard"></i>工作桌面
            </a>
        </li>
        <li>
            <a href="task.html">
                <i class="menu-icon icon-tasks"></i>统计查询
            </a>
        </li>
           
        <li>
            <a class="collapsed" data-toggle="collapse" href="#pj">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>票据
            </a>
            <ul id="pj" class="collapse unstyled">
                <li><a href="fillposit.aspx"><i class="icon-inbox"></i>填写存单 </a></li>
                <li><a href="fillcheck.aspx"><i class="icon-inbox"></i>填写支票</a></li>
                <li><a href="review.aspx"><i class="icon-inbox"></i>票据审批</a></li>
                <li><a href="other-user-listing.html"><i class="icon-inbox"></i>票据查询</a></li>
            </ul>
        </li>
        <li>
            <a class="collapsed" data-toggle="collapse" href="#yj">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>月末操作
            </a>
            <ul id="yj" class="collapse unstyled">
                <li><a href="mstate.aspx"><i class="icon-inbox"></i>发起月结</a></li>
                <li><a href="showMstate.aspx"><i class="icon-inbox"></i>查看月结</a></li>
            </ul>
        </li>
        <li>
            <a class="collapsed" data-toggle="collapse" href="#zh">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>账户管理
            </a>
            <ul id="zh" class="collapse unstyled">
                <li><a href="dep.aspx"><i class="icon-inbox"></i>本部门账户管理</a></li>
                <li><a href="excdep.aspx"><i class="icon-inbox"></i>往来单位账户管理</a></li>
            </ul>
        </li>
    </ul>
    <!--/.widget-nav-->

    <!--/.widget-nav-->
    <ul class="widget widget-menu unstyled" runat="server" id="admin">
        <li class="active">
            <a href="useradmin.aspx">
                <i class="menu-icon icon-dashboard"></i>用户管理
            </a>
        </li>
        <li class="active">
            <a href="sigadmin.aspx">
                <i class="menu-icon icon-dashboard"></i>印章管理
            </a>
        </li>
    </ul>
</div>