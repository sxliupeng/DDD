<%@ Control language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="head090114">
<%--    <p class="logo"><a href="<%= SiteUrls.Instance.Home %>"><img src="img.ashx?fileurl=images/logo_bbs.gif" alt="" border="0" /></a></p>
--%>    <div class="rInfo">
        <p>
            <% Html.RenderPartial("LogOnUserControl"); %>
        </p>
        <p><span>&nbsp;</span></p>
    </div>
</div>