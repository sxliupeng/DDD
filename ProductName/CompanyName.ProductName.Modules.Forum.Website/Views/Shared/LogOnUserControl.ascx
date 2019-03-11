<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%: Html.ActionLink("首页", "Index", "Home")%>
<%
    if (Request.IsAuthenticated) {
%>
        欢迎您:<b><%: Page.User.Identity.Name %></b>!
        <%: Html.ActionLink("控制面板", "Index", "ControlPanel")%>
        <%: Html.ActionLink("注销", "LogOff", "Account")%>
<%
    }
    else {
%> 
        <%: Html.ActionLink("注册", "Register", "Account")%>
        <%: Html.ActionLink("登陆", "LogOn", "Account")%>
<%
    }
%>
