<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headbar.ascx.cs" Inherits="kaihong_funds.publicHTML.headbar" %>
<div class="navbar navbar-fixed-top">
    <div class="navbar-inner">
        <div class="container">
            <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-inverse-collapse">
                <i class="icon-reorder shaded"></i>
            </a><a class="brand" href="index.aspx">货币资金管理系统</a>
            <div class="nav-collapse collapse navbar-inverse-collapse">               
                
                <ul class="nav pull-right ">
                    <li><a ><asp:Label ID="lg_date" runat="server" Text="Unkown"></asp:Label></a></li>
                    <li><a><asp:Label ID="dep_name" runat="server" Text="Unkown"></asp:Label></a></li>
                    <li class="nav-user dropdown">
                        <a  class="dropdown-toggle" data-toggle="dropdown">
                            <asp:Label ID="uer_name" runat="server" Text="Unkown"></asp:Label>
                            <b class="caret"></b>
                        </a>
                        <ul class="dropdown-menu">
                            <li><a href="#">用户设置</a></li>
                            <li><asp:LinkButton ID="quit" runat="server" OnClick="quit_Click">退出登录</asp:LinkButton></li>
                        </ul>

                    </li>
                   
                </ul>
            </div>
        </div>
    </div>
</div>