<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Mvc.Common.IPagedViewDataList<CompanyName.ProductName.Modules.Forum.Website.ViewData.GroupViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Forum Group List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <% foreach (var group in Model) { %>
            <li>
                <%= Html.ActionLink(group.Subject, "Details", new { id = group.Id })%>
                <%= Html.ActionLink("Edit", "Edit", new { id = group.Id })%>
                <%= Html.ActionLink("Sections", "Index", "Section", new { groupId = group.Id }, null)%>
            </li>
        <% } %>
    </ul>
    <p>
        <%: Html.ActionLink("Create New Group", "Create") %>
    </p>
</asp:Content>
