﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="countinfo.aspx.cs" Inherits="kaihong_funds.countinfo" %>
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
                        <div class="span12" id="op">
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
                                            <asp:Button runat="server" Text="返回" CssClass="btn btn-primary" ID="back"  OnClick="back_Click" />
									        <asp:Button runat="server" Text="刷新"  CssClass="btn btn-primary" ID="ref" OnClick="ref_Click"/>
                                            <input type="button"  value="打印" onclick="prnt()" class="btn btn-primary" />
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
                                <!--startprint-->
                                    <table class="table table table-bordered " id="print">
                                        <caption><h3>查询汇总表</h3></caption>
                                        <thead>
									<tr>
									  <th>单位</th>
                                      <th>账号</th>
                                      <th>类型</th>
                                      <th>收款单位</th>
                                      <th>收款账号</th>
                                      <th>金额</th>
                                      <th>日期</th>
                                      <th>打印次数</th>
									</tr>
								  </thead>

                                      <asp:Repeater runat="server" Id="list">
                                          <ItemTemplate>
                                              <tr>
                                              <td><%# Eval("dep_name") %></td>
                                              <td><%# Eval("no") %></td>
                                              <td><%# Eval("bill_type").ToString()=="1"?"存单":"支票" %></td>
                                              <td><%# Eval("edep_name")==null?"/": Eval("edep_name")%></td>
                                              <td><%# Eval("edep_no") %></td>
                                              <td><%# Eval("amount") %></td>
                                              <td><%#Convert.ToDateTime( Eval("make_date")).ToShortDateString() %></td>
                                              <td><%# Eval("prnt") %></td> </tr>
                                          </ItemTemplate>
                                      </asp:Repeater>
                                              <tr>
                                                  <td colspan="9">
                                                      <asp:Label runat="server" ID="info_table" Text=" "></asp:Label>
                                                  </td>

                                              </tr>
                                  </table>
                                   <!--endprint-->
                                    
                                </div>
                            </div>
                        </div>
                    </div>
 



                </div>
            </div>
        </div>
    <script type="text/javascript">
        function prnt() {

                bdhtml = window.document.body.innerHTML;//获取当前页的html代码 
                sprnstr = "<!--startprint-->";//设置打印开始区域 
                eprnstr = "<!--endprint-->";//设置打印结束区域 
                prnhtml = bdhtml.substring(bdhtml.indexOf(sprnstr) + 18); //从开始代码向后取html 
                prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));//从结束代码向前取html 
                window.document.body.innerHTML = prnhtml;
                window.print();
                window.document.body.innerHTML = bdhtml;
        }
    </script>


        <!--insert footer begin-->
        <!--#include file="publicHTML/footer.aspx"-->
        <!--insert footer end-->
    </form>
</body>
</html>
