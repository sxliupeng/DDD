<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CompanyName.ProductName.Mvc.Common.IPagedViewDataList<CompanyName.ProductName.Modules.Forum.Website.ViewData.SectionViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Subject
            </th>
            <th>
                Enabled
            </th>
            <th>
                GroupId
            </th>
            <th>
                GroupSubject
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink(item.Subject, "Details", new { id = item.Id })%> |
                <%: Html.ActionLink("Edit", "Edit", new { id = item.Id })%> |
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Subject %>
            </td>
            <td>
                <%: item.Enabled %>
            </td>
            <td>
                <%: item.GroupId %>
            </td>
            <td>
                <%: item.GroupSubject %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New Section", "Create") %>
    </p>
    <div>
        <%: Html.ActionLink("Back to Group List", "Index", "Group", null, null) %>
    </div>

</asp:Content>

