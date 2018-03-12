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
                <li><a href="other-login.html"><i class="icon-inbox"></i>制存单 </a></li>
                <li><a href="other-user-profile.html"><i class="icon-inbox"></i>制支票</a></li>
                <li><a href="other-user-listing.html"><i class="icon-inbox"></i>审批</a></li>
                <li><a href="other-user-listing.html"><i class="icon-inbox"></i>查询</a></li>
            </ul>
        </li>

        <li>
            <a class="collapsed" data-toggle="collapse" href="#msg">
                <i class="menu-icon icon-inbox">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>消息
            </a>
            <ul id="msg" class="collapse unstyled">
                <li><a href="other-login.html"><i class="icon-inbox"></i>发送消息 </a></li>
                <li><a href="other-user-profile.html"><i class="icon-inbox"></i>收件箱
                    <b class="label green pull-right">
                    11
                </b></a>

                </li>
            </ul>
        </li>

        <li>
            <a class="collapsed" data-toggle="collapse" href="#yj">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>月末操作
            </a>
            <ul id="yj" class="collapse unstyled">
                <li><a href="other-login.html"><i class="icon-inbox"></i>发起月结</a></li>
                <li><a href="other-user-profile.html"><i class="icon-inbox"></i>查询月结</a></li>
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
        <li>
            <a class="collapsed" data-toggle="collapse" href="#yhgl">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>用户管理
            </a>
            <ul id="yhgl" class="collapse unstyled">
                <li><a href="other-login.html"><i class="icon-inbox"></i>用户管理</a></li>
                <li><a href="other-user-profile.html"><i class="icon-inbox"></i>用户列表</a></li>
            </ul>
        </li>
        <li>
            <a class="collapsed" data-toggle="collapse" href="#yzgl">
                <i class="menu-icon icon-cog">
                </i><i class="icon-chevron-down pull-right"></i><i class="icon-chevron-up pull-right">
                </i>印章管理
            </a>
            <ul id="yzgl" class="collapse unstyled">
                <li><a href="other-login.html"><i class="icon-inbox"></i>印章管理</a></li>
                <li><a href="other-user-profile.html"><i class="icon-inbox"></i>印章列表</a></li>
            </ul>
        </li>
    </ul>
</div>